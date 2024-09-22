using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationTrigger : MonoBehaviour
{
    private Skeleton skeleton => GetComponentInParent<Skeleton>();

    public void AnimationTrigger()
    {
        skeleton.AnimationFinishTrigger();
    }
}
