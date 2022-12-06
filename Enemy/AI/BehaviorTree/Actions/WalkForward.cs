using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class WalkForward : ActionsBase
{
    [SerializeField] private bool isRun;
    [SerializeField] private float speed;

    float temp = 0;
    [SerializeField,Header("AIº”ÀŸ∂»")] float a=1.5f;

    public override void OnStart()
    {
        temp = _animator.Value.GetFloat(_movement.Value.runID);
    }
    public override TaskStatus OnUpdate()
    {
        if (isRun)
        {
            if(temp<1)
                temp += a*Time.deltaTime;
            _animator.Value.SetFloat(_movement.Value.runID, temp);
        }
        else
        {
            if (temp > 0)
                temp -= a * Time.deltaTime;
            else
                temp = 0;
            _animator.Value.SetFloat(_movement.Value.runID, temp);
        }

        LockOnTarget();
        _movement.Value.CharacterMoveInterface(_movement.Value.transform.forward, speed, true);
        _animator.Value.SetFloat(_movement.Value.verticalID, 1f, 0.23f, Time.deltaTime);
        _animator.Value.SetFloat(_movement.Value.horizontalID, 0f, 0.1f, Time.deltaTime);

        return TaskStatus.Running;
    }

    public override void OnEnd()
    {

    }
}
