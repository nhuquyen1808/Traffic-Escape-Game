using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public class LipStickPooled : MonoBehaviour
    {
        private PoolLipStick pool;
        public PoolLipStick Pool { get => pool; set => pool = value; }
        public void ReturnToPool()
        {
            pool.ReturnToPool(this);
        }
    }
}
