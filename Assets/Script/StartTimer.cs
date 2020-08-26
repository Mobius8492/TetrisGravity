using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    public Text timerText;
    private float gameStartTimer;

    // Start is called before the first frame update
    void Start()
    {
        gameStartTimer = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;

        gameStartTimer -= Time.unscaledDeltaTime;
        timerText.text = gameStartTimer.ToString("0");

        if (gameStartTimer <= 0.6f)
        {
            timerText.text = "START!!";
        }
        if (gameStartTimer <= -0.5)
        {
            Time.timeScale = 1;
            Destroy(timerText.gameObject);
        }
    }
}
