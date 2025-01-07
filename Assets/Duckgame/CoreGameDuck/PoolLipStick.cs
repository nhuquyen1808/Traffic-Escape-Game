using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public class PoolLipStick : MonoBehaviour
    {
        [SerializeField] private uint initPoolSize;
        public uint InitPoolSize => initPoolSize;

        // PooledObject prefab
        [SerializeField] private LipStickPooled objectToPool;

        // store the pooled objects in stack1
        private Stack<LipStickPooled> stack1;

        private void Start()
        {
            SetupPool();
        }

        private void SetupPool()
        {
            if (objectToPool == null)
            {
                return;
            }
            stack1 = new Stack<LipStickPooled>();
            LipStickPooled instance = null;
            for (int i = 0; i < initPoolSize; i++)
            {
                instance = Instantiate(objectToPool);
                instance.Pool = this;
                instance.gameObject.SetActive(false);
                instance.transform.SetParent(this.gameObject.transform, true);
                stack1.Push(instance);
            }
        }

        // returns the first active GameObject from the pool
        public LipStickPooled GetPooledObject(Vector2 pos, Quaternion rotation)
        {
            if (objectToPool == null)
            {
                return null;
            }
            if (stack1.Count == 0)
            {
                LipStickPooled newInstance = Instantiate(objectToPool);
                newInstance.Pool = this;
                newInstance.transform.SetParent(this.gameObject.transform, true);
                return newInstance;
            }
            // otherwise, just grab the next one from the list
            LipStickPooled nextInstance = stack1.Pop();
            nextInstance.gameObject.transform.position = pos;
            nextInstance.gameObject.transform.rotation = rotation;
            nextInstance.gameObject.SetActive(true);
            return nextInstance;
        }

        public void ReturnToPool(LipStickPooled pooledObject)
        {
            stack1.Push(pooledObject);
            pooledObject.gameObject.SetActive(false);
        }
    }
}
