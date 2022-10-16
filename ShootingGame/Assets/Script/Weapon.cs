using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool isInit = false;
    private GameObject projectilePrefab;
    private float attackRate;

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
            yield return YieldInstructionCache.WaitForSeconds(attackRate);
        }
    }
}
