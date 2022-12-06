using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckDistance : Conditional
{
    [SerializeField] private float thresholdDis;
    [SerializeField] private SharedTransform target;
    [SerializeField, Header("�Ƿ��жϴ���")] private bool isGreat;

    public override TaskStatus OnUpdate()
    {
        float dis = Vector3.Distance(target.Value.position,transform.position);
        if (isGreat)
        {
            if(dis < thresholdDis)
                return TaskStatus.Failure;
            return TaskStatus.Success;
        }
        else
        {
            if (dis < thresholdDis)
                return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
