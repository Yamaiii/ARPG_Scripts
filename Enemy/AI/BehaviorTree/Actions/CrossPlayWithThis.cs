using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;


public class CrossPlayWithThis : ActionsBase
{
    [SerializeField] private string aniName;

    bool first = true;

    public override void OnStart()
    {
        _animator.Value.CrossFade(aniName,0.05f);
    }
    public override TaskStatus OnUpdate()
    {
        if (first)
        {
            if (_animator.Value.CheckAnimationTag(tag_A2D))
                first = false;

            return TaskStatus.Running;
        }

        if (_animator.Value.CheckAnimationTag(tag_A2D))
            return TaskStatus.Running;
        return TaskStatus.Success;
    }

    public override void OnEnd()
    {
        first = true;
    }
}
