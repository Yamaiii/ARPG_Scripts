using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UGG.Move;

public abstract class CombatabilityBase : ScriptableObject
{
    [SerializeField] protected string abilityName;
    [SerializeField] protected int abilityID;
    [SerializeField] protected float abilityCD;
    [SerializeField] protected float abilityDistance;
    [SerializeField] private bool abilityDone;

    private Animator animator;
    private AICombatSystem combatSystem;
    private CharacterMovementBase movement;

    /// <summary>
    /// 调用技能
    /// </summary>
    public abstract bool InvokeAbility(float distance);

    protected void UseAbility()
    {
        animator.CrossFade(abilityName,0.05f,0);
        abilityDone = false;
        ResetCD();
    }

    public void ResetCD()
    {
        Timer.instance._Timer(abilityCD, () => { Debug.Log(abilityName + "冷却完成"); abilityDone = true; });

    }



    #region 接口

    public void InitAbility(Animator animator, AICombatSystem combat, CharacterMovementBase movement)
    {
        this.movement = movement;
        this.animator = animator;
        this.combatSystem = combat;
    }

    public string GetAbilityName() => abilityName;
    public int GetAbilityID() => abilityID;
    public bool IsAbilityDone() => abilityDone;
    public void SetAbilityDon(bool done)=> abilityDone = done;

    #endregion
}
