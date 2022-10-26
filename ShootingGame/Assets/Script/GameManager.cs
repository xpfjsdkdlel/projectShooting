using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Inst
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
    [SerializeField]
    private List<GameObject> heartImage;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI boomText;

    public void ChangeBoomText(int count)
    {
        boomText.text = "X " + count.ToString();
    }
    public void ChangeHeart(bool isHealing, int heartPoint)
    {
        if (isHealing)
            heartImage[heartPoint - 1].SetActive(true);
        else
            heartImage[heartPoint].SetActive(false);
    }
    private int score = 0;
    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "SCORE : " + this.score.ToString();
    }
}
