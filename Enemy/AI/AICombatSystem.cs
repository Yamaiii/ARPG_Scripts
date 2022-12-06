using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UGG.Combat;

public class AICombatSystem : CharacterCombatSystemBase
{
    [SerializeField, Header("攻击移动速度倍率"), Range(.1f, 10f)]
    private float attackMoveMult;

    [SerializeField,Header("技能搭配")] public List<CombatabilityBase> abilityList = new List<CombatabilityBase>();

    private void Start()
    {
        InitAllAbility();
    }

    private void Update()
    {
        ActionMotion();
    }

    [SerializeField, Header("AnimationTag")] private string aniTag_Attack = "Attack";
    [SerializeField, Header("AnimationTag")] private string aniTag_GSAttack = "GSAttack";
    /// <summary>
    /// 动画移动
    /// </summary>
    private void ActionMotion()
    {
        if (_animator.CheckAnimationTag(aniTag_Attack) || _animator.CheckAnimationTag(aniTag_GSAttack))
        {
            _characterMovementBase.CharacterMoveInterface(transform.forward, _animator.GetFloat(animationMoveID) * attackMoveMult, true);
        }
    }

    #region 技能
    private void InitAllAbility()
    {
        if (abilityList.Count == 0) return;

        foreach (var ability in abilityList)
        {
            ability.InitAbility(_animator,this,_characterMovementBase);

            if(!ability.IsAbilityDone())
                ability.ResetCD();
        }
    }

    public CombatabilityBase GetAnDoneAbility()
    {
        foreach (var ability in abilityList)
        {
            if(ability.IsAbilityDone())
                return ability;
        }
        return null;
    }

    public CombatabilityBase GetAbilityWithName(string name)
    {
        foreach (var ability in abilityList)
        {
            if (ability.GetAbilityName().Equals(name))
                return ability;
        }
        return null;
    }

    public CombatabilityBase GetAbilityWithID(string id)
    {
        foreach (var ability in abilityList)
        {
            if (ability.GetAbilityID().Equals(id))
                return ability;
        }
        return null;
    }


    #endregion

    private void OpenCombo()
    {

    }

    private void CloseCombo()
    {

    }

}
