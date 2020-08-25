using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefficultSelect : MonoBehaviour
{
    public void OnClickDebug()
    {
        FadeManager.Instance.LoadScene("test", 0.3f);
    }

    public void OnClickEasy()
    {
        SceneManager.sceneLoaded += LoadEasy;
        FadeManager.Instance.LoadScene("Playing", 0.3f);
    }

    private void LoadEasy(Scene next, LoadSceneMode mode)
    {
        var nextObject = FindObjectOfType<BallShotTest>();
        nextObject.rotateZSpeed = 1;
        nextObject.shotTiming = 15;
        SceneManager.sceneLoaded -= LoadEasy;
    }

    public void OnClickNormal()
    {
        SceneManager.sceneLoaded += LoadNormal;
        FadeManager.Instance.LoadScene("Playing", 0.3f);
    }

    private void LoadNormal(Scene next, LoadSceneMode mode)
    {
        var nextObject = FindObjectOfType<BallShotTest>();
        nextObject.rotateZSpeed = 2;
        nextObject.shotTiming = 7;
        SceneManager.sceneLoaded -= LoadNormal;
    }

    public void OnClickHard()
    {
        SceneManager.sceneLoaded += LoadHard;
        FadeManager.Instance.LoadScene("Playing", 0.3f);
    }

    private void LoadHard(Scene next, LoadSceneMode mode)
    {
        var nextObject = FindObjectOfType<BallShotTest>();
        nextObject.rotateZSpeed = 5;
        nextObject.shotTiming = 5;
        SceneManager.sceneLoaded -= LoadHard;
    }
    public void OnClickVeryard()
    {
        SceneManager.sceneLoaded += LoadVeryhard;
        FadeManager.Instance.LoadScene("Playing", 0.3f);
    }

    private void LoadVeryhard(Scene next, LoadSceneMode mode)
    {
        var nextObject = FindObjectOfType<BallShotTest>();
        nextObject.rotateZSpeed = 10;
        nextObject.shotTiming = 3;
        SceneManager.sceneLoaded -= LoadVeryhard;
    }
}
