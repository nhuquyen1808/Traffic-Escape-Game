using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public static class ManagerAnimator 
    {
        public static bool HasAnimation(Animator animator, string animName)
        {
            if (animator == null)
            {
                Debug.LogWarning("Animator is null!");
                return false;
            }

            int stateHash = Animator.StringToHash(animName);
            int layerCount = animator.layerCount; 

            for (int i = 0; i < layerCount; i++) 
            {
                if (animator.HasState(i, stateHash))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
