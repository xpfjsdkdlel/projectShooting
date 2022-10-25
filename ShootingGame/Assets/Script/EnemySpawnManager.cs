using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnTrans;

    [SerializeField]
    private int nextWaveCount = 10;
    [SerializeField]
    private int currentCount = 0;
    [SerializeField]
    private GameObject textWarning;
    [SerializeField]
    private GameObject bossName;
    [SerializeField]
    private List<GameObject> bossObjects;
    private void Awake()
    {
        InitSpawnManager(1);
    }
    private void InitSpawnManager(int level)
    {
        currentCount = 0;
        StartCoroutine("SpawnEvent");
    }
    private GameObject spawnObj;
    IEnumerator SpawnEvent()
    {
        while(true)
        {
            yield return YieldInstructionCache.WaitForSeconds(2.0f);
            currentCount++;
            for (int i = 0; i < 5; i++)
            {
                spawnObj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Enemy_01].Pop();
                spawnObj.transform.position = spawnTrans[i].position;
                spawnObj.transform.rotation = spawnTrans[i].rotation;
            }
            if(currentCount == nextWaveCount)
            {
                StopCoroutine("SpawnEvent");
                StartCoroutine("SpawnBoss");
            }
        }
    }
    IEnumerator SpawnBoss()
    {
        textWarning.SetActive(true);
        yield return YieldInstructionCache.WaitForSeconds(3f);
        bossName.SetActive(true);
        SoundManager.Inst.ChangeBGM(BGM_Type.BGM_BOSS01);
        textWarning.SetActive(false);
        bossObjects[0].GetComponent<Boss>().Init();
    }
}
