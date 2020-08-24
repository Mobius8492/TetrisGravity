using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallTest : MonoBehaviour
{
    public int Score;
    public int OutBlockPoint;

    // Start is called before the first frame update
    void Start()
    {
        Score = 100;
        OutBlockPoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -7.0f || transform.position.x > 7.0f || transform.position.x < -7.0f)
        {
            Destroy(gameObject);
            FindObjectOfType<ScoreManager>().AddOutBlocks(OutBlockPoint);
        }
    }

    public int getScore()
    {
        return Score;
    }
}
