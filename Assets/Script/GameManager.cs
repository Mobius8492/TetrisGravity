using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject gameOver;

    private ScoreManager outBlockCount;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Title")
        {
            pause.SetActive(false);
            gameOver.SetActive(false);
            outBlockCount = FindObjectOfType<ScoreManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<ScoreManager>().ScoreSave();
            UnityEngine.Application.Quit();
        }

        if(SceneManager.GetActiveScene().name == "Playing")
        {
            PauseCreate();

            GameoverCreate();
        }
    }

    private void GameoverCreate()
    {
        if(gameOver.activeSelf == false && outBlockCount.getOutBlocks() >= 10)
        {
            gameOver.SetActive(true);
            FindObjectOfType<ScoreManager>().ScoreSave();
            Time.timeScale = 0.0f;
        }

    }

    private void PauseCreate()
    {
        if (gameOver.activeSelf == false)
        {
            if (pause.activeSelf == false && Input.GetMouseButtonDown(1))
            {
                pause.SetActive(true);
                Time.timeScale = 0;
            }
            else if (pause.activeSelf == true && Input.GetMouseButtonDown(1))
            {
                pause.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

}
