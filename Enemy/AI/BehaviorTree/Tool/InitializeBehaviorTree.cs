using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UGG.Move;
using UGG.Combat;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class InitializeBehaviorTree : Action
{
    [SerializeField] SharedAnimator animator;
    [SerializeField] ShareAIMovement movement;
    [SerializeField] ShareAICombatSystem aiCombatSystem;

    public override void OnAwake()
    {
        animator.Value = transform.GetComponentInChildren<Animator>();
        movement.Value = GetComponent<AIMovement>();
        aiCombatSystem.Value = transform.GetComponentInChildren<AICombatSystem>();
        Debug.Log("行为树初始化成功！");

    }
}

[System.Serializable]
public class SharedAnimator : SharedVariable<Animator>
{
    public static implicit operator SharedAnimator(Animator value) { return new SharedAnimator 
                                                                                                                            { 
                                                                                                                                    Value = value }; 
                                                                                                                            }
}

[System.Serializable]
public class ShareAIMovement : SharedVariable<AIMovement>
{
    public static implicit operator ShareAIMovement(AIMovement value) { return new ShareAIMovement { Value = value }; }
}

[System.Serializable]
public class ShareAICombatSystem : SharedVariable<AICombatSystem>
{
    public static implicit operator ShareAICombatSystem(AICombatSystem value) { return new ShareAICombatSystem { Value = value }; }
}