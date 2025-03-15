using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

namespace DevDuck
{
    public static class ManagerSpine 
    {
        public static void PlaySpineAnimation(SkeletonAnimation skeleton, string animationName,bool loop)
        {
            skeleton.AnimationState.SetAnimation(0, animationName, loop);
        }
    }
}
