using BehaviorDesigner.Runtime.Tasks;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBack : ActionsBase
{
    public override void OnStart()
    {
        _animator.Value.Play("Roll_B", 0, 0.02f);
    }

    public override TaskStatus OnUpdate()
    {
        UpdateAnimationMove();
        if(_animator.Value.IsEndOfPlay(tag_Roll))
            return TaskStatus.Success;
        return TaskStatus.Running;
    }
}
