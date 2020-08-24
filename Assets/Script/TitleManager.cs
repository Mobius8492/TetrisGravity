using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public void OnClick()
    {
        FadeManager.Instance.LoadScene("Playing", 0.3f);
    }

    public void OnClickDebug()
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
