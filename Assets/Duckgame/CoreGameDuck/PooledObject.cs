using UnityEngine;
public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;
    public ObjectPool Pool { get => pool; set => pool = value; }
    public void ReturnToPool()
    {
        pool.ReturnToPool(this);
    }
}