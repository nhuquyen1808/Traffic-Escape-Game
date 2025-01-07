using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{   // initial number of cloned objects
    [SerializeField] private uint initPoolSize;
    public uint InitPoolSize => initPoolSize;
    // PooledObject prefab
    [SerializeField] private PooledObject objectToPool;
    // store the pooled objects in stack1
    private Stack<PooledObject> stack;

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
        stack = new Stack<PooledObject>();
        PooledObject instance = null;
        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            instance.transform.SetParent(this.gameObject.transform, true);
            stack.Push(instance);
        }
    }
    // returns the first active GameObject from the pool
    public PooledObject GetPooledObject(Vector2 pos, Quaternion rotation)
    {
        if (objectToPool == null)
        {
            return null;
        }
        if (stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            newInstance.transform.SetParent(transform);
            newInstance.gameObject.transform.position = pos;

            return newInstance;
        }
        // otherwise, just grab the next one from the list
        PooledObject nextInstance = stack.Pop();
        nextInstance.gameObject.transform.position = pos;
        nextInstance.gameObject.transform.rotation = rotation;
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}
