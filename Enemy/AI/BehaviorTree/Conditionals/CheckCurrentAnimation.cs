using BehaviorDesigner.Runtime.Tasks;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCurrentAnimation : ConditionalBase
{
    [SerializeField] private string aniTag;

    public override TaskStatus OnUpdate()
    {
        if(_animator.Value.CheckAnimationTag(aniTag))
            return TaskStatus.Success;
        return TaskStatus.Failure;
    }
}
