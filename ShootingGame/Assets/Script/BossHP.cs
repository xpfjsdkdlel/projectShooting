using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    private string bossName;
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int currentHP;

    private bool isAlive;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Image imgFill;
    [SerializeField]
    private TextMeshProUGUI bossNameText;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void InitState()
    {
        currentHP = maxHP;
        sr.color = Color.white;
        isAlive = true;
        bossNameText.text = bossName;
    }
    public void TakeDamage(int damage)
    {
        if(isAlive)
        {
            currentHP -= damage;
            StopCoroutine("HitColor");
            StartCoroutine("HitColor");
            imgFill.fillAmount = Mathf.Clamp((float)currentHP / maxHP, 0, 1);
            if(currentHP <= 0)
            {
                OnDie();
            }
        }
    }
    private void OnDie()
    {
        DropItem();
        isAlive = false;
        gameObject.SetActive(false);
        transform.position = new Vector3(0f, 7f, 0f);
    }
    private IEnumerator HitColor()
    {
        sr.color = Color.red;
        yield return YieldInstructionCache.WaitForSeconds(0.05f);
        if (gameObject.activeSelf)
            sr.color = Color.white;
    }
    private GameObject obj;
    private void DropItem()
    {
        for (int i = 0; i < 5; i++)
        {
            obj = ObjectPoolManager.Instance.pools[(int)ObjectType.ObjT_Item_01].Pop();
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
        }
    }
}
