using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public abstract class ConditionalBase : Conditional
{
    protected SharedAnimator _animator;

    public override void OnAwake()
    {
        _animator = (SharedAnimator)GetComponent<BehaviorTree>().GetVariable("_animator");

    }
}
