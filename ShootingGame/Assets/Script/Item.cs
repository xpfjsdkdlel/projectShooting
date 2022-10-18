using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : PoolLabel
{
    private Rigidbody2D rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private Vector2 dir;
    public override void Init()
    {
        base.Init();
        dir.x = Random.Range(-1, 1f);
        dir.y = Random.Range(3f, 4f);
        rig.velocity = dir;
    }
}
