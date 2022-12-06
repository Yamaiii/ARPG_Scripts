using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGG.Combat
{
    public class PlayerCombatSystem : CharacterCombatSystemBase
    {
        
        //Speed
        [SerializeField, Header("攻击移动速度倍率"), Range(.1f, 10f)]
        private float attackMoveMult;
        
        //检测
        [SerializeField, Header("检测敌人")] private Transform detectionCenter;
        [SerializeField, Header("当前敌人")] private Transform currentTarget;
        [SerializeField] private float detectionRang;

        //缓存
        private Collider[] detectionedTarget = new Collider[1];
        
        private void Update()
        {
            PlayerAttackAction();
            DetectionTarget();
            ActionMotion();
            UpdateCurrentTarget();
        }

        private void LateUpdate()
        {
            OnAttackActionAutoLockOn();
        }

        private void PlayerAttackAction()
        {
            if (_characterInputSystem.playerRAtk)
            {
                if (_characterInputSystem.playerLAtk)
                {
                    _animator.SetTrigger(lAtkID);

                }
            }
            else
            {
                if (_characterInputSystem.playerLAtk)
                {
                    _animator.SetTrigger(lAtkID);
                }
            }

            _animator.SetBool(sWeaponID, _characterInputSystem.playerRAtk);
        }

        /// <summary>
        /// 自动锁敌
        /// </summary>
        private void OnAttackActionAutoLockOn()
        {
            if(CanAttackLockOn())
                if (_animator.CheckAnimationTag(aniTag_Attack) || _animator.CheckAnimationTag(aniTag_GSAttack))
                {
                    transform.root.rotation = transform.LockOnTarget(currentTarget,transform.root.transform,50f);
                }
        }


        [SerializeField, Header("AnimationTag")] private string aniTag_Attack = "Attack";
        [SerializeField, Header("AnimationTag")] private string aniTag_GSAttack = "GSAttack";
        /// <summary>
        /// 动画移动
        /// </summary>
        private void ActionMotion()
        {
            if (_animator.CheckAnimationTag(aniTag_Attack)||_animator.CheckAnimationTag(aniTag_GSAttack))
            {
                _characterMovementBase.CharacterMoveInterface(transform.forward,_animator.GetFloat(animationMoveID) * attackMoveMult,true);
            }
        }

        #region 动作检测
        
        /// <summary>
        /// 攻击状态是否允许自动锁定敌人
        /// </summary>
        /// <returns></returns>
        private bool CanAttackLockOn()
        {
            if (_animator.CheckAnimationTag(aniTag_Attack) || _animator.CheckAnimationTag(aniTag_GSAttack))
            {
                if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.75f)
                {
                    return true;
                }
            }
            return false;
        }


        private void DetectionTarget()
        {
            int targetCount = Physics.OverlapSphereNonAlloc(detectionCenter.position, detectionRang, detectionedTarget,
                enemyLayer);
            
            if (targetCount > 0)
            {
                SetCurrentTarget(detectionedTarget[0].transform);
            }
        }

        private void SetCurrentTarget(Transform target)
        {
            if (currentTarget == null || currentTarget != target)
            {
                currentTarget = target; 
            }
        }

        private string aniTag_Motion = "Motion";
        private void UpdateCurrentTarget()
        {
            if (_animator.CheckAnimationTag(aniTag_Motion))
            {
                if (_characterInputSystem.playerMovement.sqrMagnitude > 0)
                {
                    currentTarget = null;
                }

            }
        }

        #endregion

        #region 连击判定
        private void OpenCombo()
        {
            _animator.SetBool(canComboID,true);
        }
        private void CloseCombo()
        {
            _animator.SetBool(canComboID,false);
        }
        #endregion
    }
}

