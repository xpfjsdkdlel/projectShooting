using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertLine : PoolLabel
{
    Animation anim;
    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
    public override void Init()
    {
        base.Init();
        anim.Play();
        Invoke("SpawnMeteo", 3f);
    }
    private GameObject obj;
    private Vector3 pos;
    private void SpawnMeteo()
    {
        pos = transform.position;
        pos.y = 7.0f;

        obj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Meteorite_01].Pop();
        obj.transform.position = pos;
        Push();
    }
}