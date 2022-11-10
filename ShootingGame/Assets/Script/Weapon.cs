using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireType
{
    FT_Single,
    FT_Double,
    FT_Triple,
}

public class Weapon : MonoBehaviour
{
    private bool isInit = false;
    private GameObject projectilePrefab;
    private float attackRate;
    private FireType fireType;

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

        if (0 < PlayerPrefs.GetInt(Skill_Type.ST_Gold006.ToString()))
        {
            fireType = FireType.FT_Triple;
        }
        else if (0 < PlayerPrefs.GetInt(Skill_Type.ST_Gold003.ToString()))
        {
            fireType = FireType.FT_Double;
        }
        else if (0 < PlayerPrefs.GetInt(Skill_Type.ST_Gold001.ToString()))
        {
            fireType = FireType.FT_Single;
        }

        if (0 < PlayerPrefs.GetInt(Skill_Type.ST_Gold004.ToString()))
        {
            attackRate *= 0.3f;
        }
        else if (0 < PlayerPrefs.GetInt(Skill_Type.ST_Gold002.ToString()))
        {
            attackRate *= 0.6f;
        }
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
    GameObject projectObjt;
    private IEnumerator TryAttack()
    {
        while(true && gameObject.activeSelf)
        {
            switch(fireType)
            {
                case FireType.FT_Single:
                    projectObjt = ObjectPoolManager.Instance.pools[0].Pop();
                    projectObjt.transform.position = transform.position;
                    projectObjt.transform.rotation = Quaternion.identity;
                    break;
                case FireType.FT_Double:
                    projectObjt = ObjectPoolManager.Instance.pools[0].Pop();
                    projectObjt.transform.position = transform.position + new Vector3(-0.1f, 0f, 0f);
                    projectObjt.transform.rotation = Quaternion.identity;
                    projectObjt = ObjectPoolManager.Instance.pools[0].Pop();
                    projectObjt.transform.position = transform.position + new Vector3(0.1f, 0f, 0f);
                    projectObjt.transform.rotation = Quaternion.identity;
                    break;
                case FireType.FT_Triple:
                    projectObjt = ObjectPoolManager.Instance.pools[0].Pop();
                    projectObjt.transform.position = transform.position;
                    projectObjt.transform.rotation = Quaternion.identity;
                    projectObjt = ObjectPoolManager.Instance.pools[0].Pop();
                    projectObjt.transform.position = transform.position + new Vector3(-0.1f, 0f, 0f);
                    projectObjt.transform.rotation = Quaternion.identity;
                    projectObjt = ObjectPoolManager.Instance.pools[0].Pop();
                    projectObjt.transform.position = transform.position + new Vector3(0.1f, 0f, 0f);
                    projectObjt.transform.rotation = Quaternion.identity;
                    break;
            }

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
