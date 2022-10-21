using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    AT_CircleFire = 0,
    AT_CircleFire2 = 0,
    AT_SingleFireToCenterPosition,
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
            weightAngle = Random.Range(-5f, 5f);
            yield return YieldInstructionCache.WaitForSeconds(attackRate);
        }
    }
    private IEnumerator AT_CircleFire2()
    {
        float attackRate = 0.05f;
        int count = 5;
        int intervalAngle = 360 / count;
        float weightAngle = 0;

        while (true)
        {
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < count; i++)
                {
                    obj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Projectile_02].Pop();
                    obj.transform.position = transform.position;
                    angle = weightAngle + intervalAngle * i;
                    dir.x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    dir.y = Mathf.Sin(angle * Mathf.Deg2Rad);
                    obj.GetComponent<Movement2D>().MoveTo(dir);
                }

                weightAngle += 5f;
                yield return YieldInstructionCache.WaitForSeconds(attackRate);
            }

            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < count; i++)
                {
                    obj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Projectile_02].Pop();
                    obj.transform.position = transform.position;
                    angle = weightAngle + intervalAngle * i;
                    dir.x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    dir.y = Mathf.Sin(angle * Mathf.Deg2Rad);
                    obj.GetComponent<Movement2D>().MoveTo(dir);
                }

                weightAngle -= 5f;
                yield return YieldInstructionCache.WaitForSeconds(attackRate);
            }
        }
    }
    private IEnumerator AT_SingleFireToCenterPosition()
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.2f;

        while (true)
        {
            obj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Projectile_02].Pop();
            obj.transform.position = transform.position;
            dir = targetPosition - transform.position;
            yield return YieldInstructionCache.WaitForSeconds(attackRate);
        }
    }
}
