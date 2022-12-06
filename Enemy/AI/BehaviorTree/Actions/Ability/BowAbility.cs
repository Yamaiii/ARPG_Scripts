using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalAbility", menuName = "Ability/BowAbility")]

public class BowAbility : CombatabilityBase
{
    public override bool InvokeAbility(float distance)
    {
        if (distance > abilityDistance || !IsAbilityDone())
            return false;
        UseAbility();
        return true;
    }
    
}
