using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Skill_Type
{
    ST_Gold001,
    ST_Gold002,
    ST_Gold003,
    ST_Gold004,
    ST_Gold005,
    ST_Gold006,
}
public enum EnchantState
{
    ES_Learn, // �̹� ������ ��ų
    ES_Enable, // ���� �ִ� ����
    ES_Disable, // ������ ���� ����
}
public class SkillButton : MonoBehaviour
{
    [SerializeField]
    private Image blockImg;
    [SerializeField]
    private Image subBlockImg;

    [SerializeField]
    private SkillButton prevButton;
    [SerializeField]
    private SkillButton nextButton;

    private EnchantState cState;
    public EnchantState STATE
    {
        get { return cState; }
        set { cState = value; }
    }
    [SerializeField]
    private Skill_Type cType;
    public Skill_Type TYPE
    {
        get { return cType; }
    }
    [SerializeField]
    private int upgradeGroupLevel;
    public void InitBtn(bool isLearn, int playerLevel)
    {
        subBlockImg.gameObject.SetActive(false);
        blockImg.gameObject.SetActive(false);
        STATE = EnchantState.ES_Disable;
        if(isLearn)
        {
            subBlockImg.gameObject.SetActive(false);
            blockImg.gameObject.SetActive(false);
            STATE = EnchantState.ES_Learn;
        }
        else
        {
            if(prevButton != null)
            {
                if(playerLevel >= upgradeGroupLevel && prevButton.STATE == EnchantState.ES_Learn)
                {
                    subBlockImg.gameObject.SetActive(false);
                    STATE = EnchantState.ES_Enable;
                }
            }
            else if(playerLevel >= upgradeGroupLevel) // ���ེų�� ���°��
            {
                subBlockImg.gameObject.SetActive(true);
                STATE = EnchantState.ES_Enable;
            }
        }
    }
    [SerializeField]
    private GameObject toolTip;
    public void OnClickBtn()
    {
        toolTip.SetActive(true);
        toolTip.transform.parent = transform;
        toolTip.transform.localPosition = new Vector3(270f, 0f, 0f);
        toolTip.GetComponent<ToolTip>().InitToolTip(this, 100);
    }

    public void Upgrade()
    {
        PlayerPrefs.SetInt(TYPE.ToString(), 1);
        InitBtn(true, 10);
        if(nextButton != null)
        {
            nextButton.InitBtn(false, 10);
        }
    }
}
