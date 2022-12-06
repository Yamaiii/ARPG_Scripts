
using UnityEngine;

public static class UnitExpandingFunction
{

    /// <summary>
    /// 检测动画标签
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="tagName"></param>
    /// <param name="animationIndex"></param>
    /// <returns></returns>
    public static bool CheckAnimationTag(this Animator animator, string tagName, int animationIndex = 0)
    {

        return animator.GetCurrentAnimatorStateInfo(animationIndex).IsTag(tagName);
    }
    /// <summary>
    /// 检测动画片段名称
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="animationName"></param>
    /// <param name="animationIndex"></param>
    /// <returns></returns>
    public static bool CheckAnimationName(this Animator animator, string animationName, int animationIndex = 0)
    {
        return animator.GetCurrentAnimatorStateInfo(animationIndex).IsName(animationName);
    }

    /// <summary>
    /// 判断tag动画是否结束
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="tagName">传进来的动画的tag</param>
    /// <returns></returns>
    public static bool IsEndOfPlay(this Animator animator,string tagName)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag(tagName))
            return true;
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f - 0.001f)
            return true;
        return false;
    }

    
    /// <summary>
    /// 锁定目标方向
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="target"></param>
    /// <param name="self"></param>
    /// <param name="lerpTime"></param>
    /// <returns></returns>
    public static Quaternion LockOnTarget(this Transform transform, Transform target,Transform self,float lerpTime)
    {
        if (target == null) return self.rotation;

        Vector3 targetDirection = (target.position - self.position).normalized;
        targetDirection.y = 0;
        Quaternion newRotation = Quaternion.LookRotation(targetDirection);
        
        return  Quaternion.Lerp(self.rotation,newRotation,lerpTime * Time.deltaTime);
    }
}
