using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : PoolLabel
{
    private bool isSetTarget;
    private GameObject target;
    private float moveTime;

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
        isSetTarget = false;
    }
    private void Update()
    {
        moveTime += Time.deltaTime;
        if (isSetTarget)
            transform.position = Vector3.Lerp(transform.position, target.transform.position, moveTime / 1.5f);
    }
    public void SetTarget(GameObject obj)
    {
        isSetTarget = true;
        target = obj;
        moveTime = 0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // todo : »πµÊ¿∏∑Œ ¿Œ«— ¡°ºˆ ¡ı∞°
            Push();
        }
    }
}
