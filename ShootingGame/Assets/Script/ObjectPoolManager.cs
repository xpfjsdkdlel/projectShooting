using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    ObjT_Projectile_01,
    ObjT_Projectile_02,
    ObjT_Projectile_03,
    ObjT_Projectile_04,
    ObjT_Projectile_05,
    ObjT_Projectile_06,
    ObjT_Enemy_01,
    ObjT_Enemy_02,
    ObjT_Enemy_03,
    ObjT_Effect_01
}
public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager instance;
    public static ObjectPoolManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;
    }
    public List<ObjectPool> pools;
}
