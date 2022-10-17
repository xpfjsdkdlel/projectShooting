using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject poolObj;
    [SerializeField]
    private int allocatecount;
    private Stack<PoolLabel> poolStack = new Stack<PoolLabel>();

    private int objMaxCount;
    private int objActiveCount;
    private void Awake()
    {
        objMaxCount = 0;
        objActiveCount = 0;
        Allocate();
    }
    private GameObject allocateobj;
    void Allocate()
    {
        for (int i = 0; i < allocatecount; i++)
        {
            allocateobj = Instantiate(poolObj, this.transform);
            allocateobj.GetComponent<PoolLabel>().Create(this);
            poolStack.Push(allocateobj.GetComponent<PoolLabel>());
            objMaxCount++;
        }
    }
    public GameObject Pop()
    {
        if (objActiveCount >= objMaxCount)
            Allocate();
        PoolLabel label = poolStack.Pop();
        label.Init();
        label.gameObject.SetActive(true);
        objActiveCount++;
        return label.gameObject;
    }
    public void Push(PoolLabel obj)
    {
        if (obj.gameObject.activeSelf)
        {
            obj.gameObject.SetActive(false);
            poolStack.Push(obj);
            objActiveCount--;
        }
    }
}
