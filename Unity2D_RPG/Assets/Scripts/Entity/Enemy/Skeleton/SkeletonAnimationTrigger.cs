using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationTrigger : MonoBehaviour
{
    private Skeleton skeleton => GetComponentInParent<Skeleton>();

    private void AnimationTrigger()
    {
        skeleton.AnimationFinishTrigger();
    }

   private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(skeleton.attackCheck.position, skeleton.attackCheckRadius);

        foreach(var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
                hit.GetComponent<Player>().Damage();
        }
   }

    protected void OpenCounterWindow() => skeleton.OpenCounterAttackWindow();

    protected void CloseCounterWindow() => skeleton.CloseCounterAttackWindow();
}
