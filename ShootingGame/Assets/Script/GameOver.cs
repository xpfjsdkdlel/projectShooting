using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject title;
    [SerializeField]
    public GameObject popupBack;
    [SerializeField]
    public GameObject homeBtn;
    [SerializeField]
    public GameObject killCount;
    [SerializeField]
    public GameObject BossCount;
    [SerializeField]
    public GameObject star1, star2, star3;
    private void Awake()
    {
        
    }
    public void SetGameOverUI()
    {
        LeanTween.scale(title, new Vector3(1f, 1f, 1f), 2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete(LevelComplete);
        LeanTween.moveLocal(title, new Vector3(0f, 350f, 0f), 0.5f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic);
    }
    public void LevelComplete()
    {
        LeanTween.moveLocal(popupBack, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutCirc);
        LeanTween.scale(homeBtn, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(killCount, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(BossCount, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
    }
    public void StarOn()
    {
        LeanTween.scale(star3, new Vector3(1f, 1f, 1f), 2).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star2, new Vector3(1f, 1f, 1f), 2).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star1, new Vector3(1.3f, 1.3f, 1.3f), 2).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
    }
    [SerializeField]
    private FadeInOut fadeScr;
    public void ReturnToLobby_Btn()
    {
        GameManager.Inst.SaveScore();
        fadeScr.Fade_InOut(false, 3f);
        Invoke("LoadScene", 3f);
    }
    private void LoadScene()
    {
        PlayerPrefs.SetString(SAVE_TYPE.SAVE_Scene.ToString(), SCENE_NAME.Lobby.ToString());
        SceneManager.LoadScene(SCENE_NAME.Loading.ToString());
    }
}
