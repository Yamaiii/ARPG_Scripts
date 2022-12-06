using BehaviorDesigner.Runtime.Tasks;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ActionsBase
{
    [SerializeField] private NormalAbility ability;

    bool first = true;
    bool canUse = false;
    public override void OnStart()
    {
        if (ability.InvokeAbility(Vector3.Distance(target.Value.position, transform.position)))
            canUse = true;
    }
    public override TaskStatus OnUpdate()
    {
        if (first)
        {
            if(!canUse)
                return TaskStatus.Failure;
            if (_animator.Value.CheckAnimationTag(tag_Skill))
                first = false;

            return TaskStatus.Running;
        }
        transform.root.rotation = transform.LockOnTarget(target.Value.transform.root.transform, transform.root.transform, 50f);
        UpdateAnimationMove();
        if (_animator.Value.CheckAnimationTag(tag_Skill))
            return TaskStatus.Running;
        return TaskStatus.Success;
    }

    public override void OnEnd()
    {
        first = true;
        canUse = false;
    }
}
