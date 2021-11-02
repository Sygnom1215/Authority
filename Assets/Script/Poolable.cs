using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    protected Pool pool;

    public virtual void Create(Pool pool)
    {
        this.pool = pool;
        gameObject.SetActive(false);
    }
    public virtual void Push()
    {
        pool.Push(this);
    }
}
