using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum SAVE_TYPE
{
    SAVE_Name,
    SAVE_Level,
    SAVE_EXP,
    SAVE_GOLD,
    SAVE_Scene,
    SAVE_SFX,
    SAVE_BGM,
}
public enum SCENE_NAME
{
    PlayScene,
    Lobby,
    Loading,
}
public class UserInfo
{
    public string userID;
    public List<int> nList;
}
public class LoginMgr : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;
    private bool haveUserInfo;
    [SerializeField]
    private TextMeshProUGUI text;

    
    private void Awake()
    {
        InitLoginScene();

    }
    private void InitLoginScene()
    {
        if (PlayerPrefs.GetString(SAVE_TYPE.SAVE_Name.ToString()).Length < 2)
        {
            text.gameObject.SetActive(false);
            inputField.gameObject.SetActive(true);
            haveUserInfo = false;
        }
        else
        {
            text.text = PlayerPrefs.GetString(SAVE_TYPE.SAVE_Name.ToString()) + "님 환영합니다.";
            text.gameObject.SetActive(true);
            haveUserInfo = true;
        }
    }
    private void CreateUserData(string userName)
    {
        PlayerPrefs.SetString(SAVE_TYPE.SAVE_Name.ToString(), inputField.text);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_Level.ToString(), 0);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_EXP.ToString(), 0);
        PlayerPrefs.SetFloat(SAVE_TYPE.SAVE_BGM.ToString(),1f);
        PlayerPrefs.SetFloat(SAVE_TYPE.SAVE_SFX.ToString(), 1f);
        PlayerPrefs.SetInt(Skill_Type.ST_Gold001.ToString(), 0);
        PlayerPrefs.SetInt(Skill_Type.ST_Gold002.ToString(), 0);
        PlayerPrefs.SetInt(Skill_Type.ST_Gold003.ToString(), 0);
        PlayerPrefs.SetInt(Skill_Type.ST_Gold004.ToString(), 0);
        PlayerPrefs.SetInt(Skill_Type.ST_Gold005.ToString(), 0);
        PlayerPrefs.SetInt(Skill_Type.ST_Gold006.ToString(), 0);
    }
    public void LoginBtn()
    {
        if(!haveUserInfo)
        {
            if (inputField.text.Length > 2)
            {
                PlayerPrefs.SetString(SAVE_TYPE.SAVE_Name.ToString(), inputField.text);
                haveUserInfo = true;
            }
            else
                Debug.Log("입력한 아이디가 짧습니다.");
        }
        if(haveUserInfo)
        {
            PlayerPrefs.SetString(SAVE_TYPE.SAVE_Scene.ToString(), SCENE_NAME.Lobby.ToString());
            SceneManager.LoadScene(SCENE_NAME.Loading.ToString());
        }
    }
    public void InitUserData()
    {
        PlayerPrefs.DeleteAll();
    }
}
