using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

/// <summary>
/// 找范围内的玩家，找到返回true，找不到返回false
/// </summary>
public class FindThePlayer : Conditional
{
    Collider[] colliders = new Collider[1];
    public SharedTransform targetTransform;

    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private LayerMask bosLayer;
    [SerializeField] private float minmumDetectionAngle;
    public override void OnStart()
    {
        
    }
    public override TaskStatus OnUpdate()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders,detectionLayer);


        if (count > 0)
        {
            Vector3 targetDir = transform.position - colliders[0].transform.position;
            float viewableAngle = Vector3.Angle(targetDir,transform.forward);
            //Debug.Log(viewableAngle);

            if (!Physics.Raycast((transform.root.position + transform.root.up * .5f), (colliders[0].transform.position - transform.root.position).normalized, out var hit, Vector3.Distance(transform.position,colliders[0].transform.position), bosLayer))
            {
  
                if (viewableAngle > minmumDetectionAngle)
                {
                    targetTransform.Value = colliders[0].transform;
                    return TaskStatus.Success;
                }
            }

        }
        colliders[0] = null;
        return TaskStatus.Failure;
    }
}
