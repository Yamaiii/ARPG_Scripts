using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class WalkBack : ActionsBase
{
    public override TaskStatus OnUpdate()
    {
        LockOnTarget();
        _movement.Value.CharacterMoveInterface(-_movement.Value.transform.forward , 1.5f , true);
        _animator.Value.SetFloat(_movement.Value.verticalID,-1f,0.23f, Time.deltaTime);
        _animator.Value.SetFloat(_movement.Value.horizontalID, 0f,0.1f, Time.deltaTime);

        return TaskStatus.Running;
    }
}
