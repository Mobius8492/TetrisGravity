using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public void InTitleStartClick()
    {
        FadeManager.Instance.LoadScene("Playing", 0.3f);
    }

    public void ClickDebug()
    {
        FadeManager.Instance.LoadScene("test", 0.3f);
    }

    public void OnClickInPlayingToContinue()
    {
        FindObjectOfType<ScoreManager>().ScoreSave();
        Time.timeScale = 1.0f;
        FadeManager.Instance.LoadScene("Playing", 0.3f);
    }

    public void OnClickInPlayingToTitle()
    {
        FindObjectOfType<ScoreManager>().ScoreSave();
        Time.timeScale = 1.0f;
        FadeManager.Instance.LoadScene("Title", 0.3f);
    }
}
