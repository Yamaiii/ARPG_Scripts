using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGG.Health
{
    public class PlayerHealthSystem : CharacterHealthSystemBase
    {
        string tag_Defense = "Defense";
        string tag_A2D = "A2D";
        public override void TakeDamager(float damagar, string hitAnimationName, Transform attacker)
        {
            if (_animator.CheckAnimationTag(tag_Defense))
                _animator.Play("GS_Defence_01");
            else if (_animator.CheckAnimationTag(tag_A2D))
            {
                _animator.CrossFade("Parry_0",0.2f);
                attacker.GetComponentInChildren<Animator>().CrossFade("Rebound_0",0.2f);
            }
            else
                _animator.Play(hitAnimationName, 0, 0f);
            SetAttacker(attacker);
            GameAssets.Instance.PlaySoundEffect(_audioSource, SoundAssetsType.hit);
            transform.rotation = transform.LockOnTarget(attacker, transform, 50f);
        }
    }
}

