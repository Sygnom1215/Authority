using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private Poolable poolObj;
    [SerializeField]
    private int allocateCount;

    private Stack<Poolable> poolStack = new Stack<Poolable>();

    void Start()
    {
        Allocate();
    }

    public void Allocate()
    {
        for(int i = 0; i < allocateCount; i++)
        {
            Poolable allocateObj = Instantiate(poolObj, this.gameObject.transform);
            allocateObj.Create(this);
            poolStack.Push(allocateObj);
        }
    }

    public GameObject Pop()
    {
        Poolable obj = poolStack.Pop();
        obj.gameObject.SetActive(true);
        return obj.gameObject;
    }
    public void Push(Poolable obj)
    {
        obj.gameObject.SetActive(false);
        poolStack.Push(obj);
    }
}
