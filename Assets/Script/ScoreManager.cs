using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text Score;
    public Text HighScore;
    public Text OutBlocks;

    private int intScore;
    private int intHighScore;
    private int intOutBlocks;

    private string HighScoreKey = "highScore";

    // Start is called before the first frame update
    void Start()
    {
        intScore = 0;
        intHighScore = PlayerPrefs.GetInt(HighScoreKey,0);
        intOutBlocks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (intHighScore < intScore)
        {
            intHighScore = intScore;
        }

        Score.text = intScore.ToString("0000000");
        HighScore.text = intHighScore.ToString("0000000");
        OutBlocks.text = intOutBlocks.ToString("00");

        if (SceneManager.GetActiveScene().name == "test")
        {
            intOutBlocks = 0;
        }
    }

    public void AddScore(int point)
    {
        intScore += point;
    }

    public void AddOutBlocks(int outBlock)
    {
        intOutBlocks += outBlock;
    }

    public int getOutBlocks()
    {
        return intOutBlocks;
    }

    public void ScoreSave()
    {
        PlayerPrefs.SetInt(HighScoreKey, intHighScore);
        PlayerPrefs.Save();
    }
}
