using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UGG.Move;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public abstract class ActionsBase : Action
{
    protected SharedAnimator _animator;
    protected ShareAIMovement _movement;
    protected SharedTransform target;
    protected ShareAICombatSystem _combatSystem;

    //ÒÆ¶¯ËÙ¶È
    protected float runSpeed = 9;
    protected float walkSpeed = 1.5f;

    //AnimationID
    protected int lockOnID = Animator.StringToHash("LockOn");

    //AnimationTag
    protected string tag_Roll = "Roll";
    protected string tag_Motion = "Motion";
    protected string tag_Attack = "Attack";
    protected string tag_Skill = "SP";
    protected string tag_A2D = "A2D";
    public override void OnAwake()
    {
        _animator = (SharedAnimator)GetComponent<BehaviorTree>().GetVariable("_animator");
        _movement = (ShareAIMovement)GetComponent<BehaviorTree>().GetVariable("_movement");
        target = (SharedTransform)GetComponent<BehaviorTree>().GetVariable("target");
        _combatSystem = (ShareAICombatSystem)GetComponent<BehaviorTree>().GetVariable("_aiCombatSystem");
    }

    protected void LockOnTarget()
    {
        if (_animator.Value.CheckAnimationTag("Motion") && target.Value != null)
        {
            _animator.Value.SetFloat(lockOnID,1f);
            transform.root.rotation = transform.LockOnTarget(target.Value,transform.root.transform,50);
        }
        else
        {
            _animator.Value.SetFloat(lockOnID,0f);
        }
    }


    protected void UpdateAnimationMove()
    {
        //if (_animator.Value.CheckAnimationTag(aniTag))
        //{
            _movement.Value.CharacterMoveInterface(transform.root.forward,_animator.Value.GetFloat(_movement.Value.animationMoveID),true);
        //}
    }
}
