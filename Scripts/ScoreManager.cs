using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance=null;
    public int currentScore=0;
    public Text currentScoreUI;
    public int bestScore=0;
    public Text bestScoreUI;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreUI.text = "Best Score : " + bestScore;
    }
    public void SetScore(int value)
    {
        
        currentScore = value;
        currentScoreUI.text = "Score : " + value;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            bestScoreUI.text = "Best Score : " + bestScore;
        }
        
    }
    public int GetScore()
    {
        return currentScore;
    }
}
