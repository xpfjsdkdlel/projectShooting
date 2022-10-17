using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnTrans;

    private void Awake()
    {
        StartCoroutine("SpawnEvent");
    }
    private GameObject spawnObj;
    IEnumerator SpawnEvent()
    {
        while(true)
        {
            yield return YieldInstructionCache.WaitForSeconds(2.0f);
            for (int i = 0; i < 5; i++)
            {
                spawnObj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Enemy_01].Pop();
                spawnObj.transform.position = spawnTrans[i].position;
                spawnObj.transform.rotation = spawnTrans[i].rotation;
            }
        }
    }
}
