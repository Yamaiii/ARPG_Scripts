using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class NormalAttack : ActionsBase
{
    bool first = true;
    public override TaskStatus OnUpdate()
    {
        if (first)
        {
            _animator.Value.SetTrigger(_combatSystem.Value.lAtkID);
            if(_animator.Value.CheckAnimationTag(tag_Attack))
                first = false;

            return TaskStatus.Running;
        }
        transform.root.rotation = transform.LockOnTarget(target.Value.transform.root.transform, transform.root.transform, 50f);

        UpdateAnimationMove();
        if (_animator.Value.CheckAnimationTag(tag_Attack))
            return TaskStatus.Running;
        //Debug.Log(_animator.Value.CheckAnimationTag(tag_Attack));
        return TaskStatus.Success;  
    }

    public override void OnEnd()
    {
        first = true;
    }
}
