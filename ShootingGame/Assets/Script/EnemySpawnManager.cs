using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private MonsterTable monsterTable;
    [SerializeField]
    private Dictionary<string, MonsterClass> monsterDate = new Dictionary<string, MonsterClass>();

    [SerializeField]
    private List<Transform> spawnTrans;
    [SerializeField]
    private float spawnDelta;
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

    GameObject bossHPBar;//수정해야됨

    int waveCount;
    int bossCount;
    private void Awake()
    {
        SetDictionary();
        waveCount = 0;
        bossCount = -1;
        StartWave();
    }
    private void SetDictionary()
    {
        for(int i = 0; i < monsterTable.Monster.Count; i++)
        {
            monsterDate.Add(monsterTable.Monster[i].monsterName, monsterTable.Monster[i]);
        }
    }
    public void StartWave()
    {
        bossHPBar.SetActive(false);
        currentCount = 0;
        StartCoroutine("SpawnEvent");
    }
    private GameObject spawnObj;
    private MonsterClass data;
    private string stageName;
    IEnumerator SpawnEvent()
    {
        waveCount++;
        stageName = "stage_" + waveCount;
        if(!monsterDate.TryGetValue(stageName, out data))
        {
            Debug.Log("몬스터 데이터 테이블 참조 실패 " + stageName);
        }
        while(true)
        {
            yield return YieldInstructionCache.WaitForSeconds(spawnDelta);
            currentCount++;
            for (int i = 0; i < 5; i++)
            {
                spawnObj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Enemy_01].Pop();
                spawnObj.transform.position = spawnTrans[i].position;
                spawnObj.transform.rotation = spawnTrans[i].rotation;
                if(spawnObj.TryGetComponent<EnemyChar>(out EnemyChar enemy))
                {
                    enemy.SetEnemyLevel(data.monsterHP, data.monsterScore);
                }
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
        bossCount++;
        textWarning.SetActive(true);
        yield return YieldInstructionCache.WaitForSeconds(3f);
        bossName.SetActive(true);
        SoundManager.Inst.ChangeBGM(BGM_Type.BGM_BOSS01);
        textWarning.SetActive(false);
        bossObjects[bossCount].GetComponent<Boss>().Init(monsterTable.Boss[bossCount].bossName, monsterTable.Boss[bossCount].bossHP);
    }
}
