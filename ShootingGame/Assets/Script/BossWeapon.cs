using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    AT_CircleFire = 0,
}
public class BossWeapon : MonoBehaviour
{
    public void StartFiring(AttackType attackType)
    {
        StartCoroutine(attackType.ToString());
    }
    public void StopFiring(AttackType attackType)
    {
        StopCoroutine(attackType.ToString());
    }
    private GameObject obj;
    private float angle;
    private Vector2 dir;
    private IEnumerator AT_CircleFire()
    {
        float attackRate = 0.5f;
        int count = 30;
        int intervalAngle = 360 / count;
        float weightAngle = 0;

        while(true)
        {
            for(int i = 0; i < count; i++)
            {
                obj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Projectile_02].Pop();
                obj.transform.position = transform.position;
                angle = weightAngle + intervalAngle * i;
                dir.x = Mathf.Cos(angle * Mathf.Deg2Rad);
                dir.y = Mathf.Sin(angle * Mathf.Deg2Rad);
                obj.GetComponent<Movement2D>().MoveTo(dir);
            }
        }
    }
}
