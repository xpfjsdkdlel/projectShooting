using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool isInit = false;
    private GameObject projectilePrefab;
    private float attackRate;

    private int boom;
    public int BoomCount
    {
        get { return boom; }
        set 
        { 
            boom = value;
            GameManager.Inst.ChangeBoomText(boom);
        }
    }
    private void Awake()
    {
        BoomCount = 3;
    }
    public void Init(GameObject projectile, float rate)
    {
        isInit = true;
        projectilePrefab = projectile;
        attackRate = rate;
    }
    private bool isFireing;
    public bool IsFireing
    {
        set
        {
            isFireing = value;
            if (isFireing)
                StartCoroutine("TryAttack");
            else
                StopCoroutine("TryAttack");
        }
    }
    private IEnumerator TryAttack()
    {
        while(true)
        {
            GameObject obj = ObjectPoolManager.Instance.pools[0].Pop();
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            SoundManager.Inst.PlaySFX(sfx_Type.sfx_PlayerFire);
            yield return YieldInstructionCache.WaitForSeconds(attackRate);
        }
    }
    private GameObject obj;
    public void LunchBoom()
    {
        if(BoomCount > 0)
        {
            obj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_PlayerBoom_01].Pop();
            obj.transform.position = transform.position;
            BoomCount--;
        }
    }
}
