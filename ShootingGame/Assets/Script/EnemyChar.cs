using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChar : PoolLabel
{
    [SerializeField]
    private int currentHP;
    [SerializeField]
    private int MaxHP;
    private SpriteRenderer sr;
    private bool isAlive;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Player") && collision.GetComponent<Projectile>())
    //    {
    //        collision.GetComponent<Projectile>().Push();
    //        TakeDamage(1);
    //        if (currentHP <= 0)
    //            OnDie();
    //    }
    //}
    public override void Init()
    {
        sr = GetComponent<SpriteRenderer>();
        base.Init();
        currentHP = MaxHP;
        sr.color = Color.white;
        isAlive = true;
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        StopCoroutine("HitColor");
        StartCoroutine("HitColor");
        if (currentHP <= 0)
            OnDie();
    }
    GameObject effectObj;
    public void OnDie()
    {
        effectObj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Effect_01].Pop();
        effectObj.transform.position = transform.position;
        DropItem();
        isAlive = false;
        Push();
    }
    private IEnumerator HitColor()
    {
        sr.color = Color.red;
        yield return YieldInstructionCache.WaitForSeconds(0.05f);
        if(gameObject.activeSelf)
            sr.color = Color.white;
    }
    private GameObject obj;
    private void DropItem()
    {
        for(int i = 0; i < 5; i++)
        {
            obj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Item_01].Pop();
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
        }
    }
}
