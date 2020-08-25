using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartClick : MonoBehaviour
{
    public Button easy;
    public Button normal;
    public Button hard;
    public Button veryhard;

    // Start is called before the first frame update
    void Start()
    {
        easy.gameObject.SetActive(false);
        normal.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
        veryhard.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        gameObject.SetActive(false);
        easy.gameObject.SetActive(true);
        normal.gameObject.SetActive(true);
        hard.gameObject.SetActive(true);
        veryhard.gameObject.SetActive(true);
    }
}
