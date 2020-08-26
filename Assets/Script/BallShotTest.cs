using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallShotTest : MonoBehaviour
{
    public GameObject Z;
    public GameObject RZ;
    public GameObject TSquare;
    public GameObject Stick;
    public GameObject Ball;
    public GameObject BigSquare;
    public GameObject HBlock;
    public GameObject Dango;
    public GameObject XBlock;
    public GameObject LBlock;
    public Text shotTimingCount;


    private GameObject clone;
    private ScoreManager score;

    public float shooterSpeed;
    public float shotSpeed;
    public float rotateZSpeed;
    private float rotateZ;

    private float canShot;
    private bool canAdd;
    private bool nextCreate;
    public float shotTiming;
    private float shotTiming2;

    // Start is called before the first frame update
    void Start()
    {
        shooterSpeed = 5.0f;
        shotSpeed = 10.0f;
        nextCreate = true;
        gameObject.transform.position = new Vector2(0, 4.4f);
        //rotateZSpeed = 1;
        canShot = 0;
        shotTiming2 = shotTiming;
        canAdd = true;
        score = FindObjectOfType<ScoreManager>();
    }

    private void FixedUpdate()
    {
        canShot += Time.deltaTime;

        if (nextCreate == true)
        {
            BlockCreate(UnityEngine.Random.Range(0, 8), UnityEngine.Random.Range(0, 90));

            int cloneCount = clone.transform.childCount;

            if (cloneCount != 0)
            {
                for (int i = 0; i < cloneCount; i++)
                {
                    clone.transform.GetChild(i).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }
            else
            {
                clone.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }

            nextCreate = false;
        }

        rotateZ += rotateZSpeed;
        clone.transform.rotation = Quaternion.Euler(0, 0, rotateZ);
        clone.transform.position = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        shotTiming -= Time.deltaTime;
        shotTimingCount.text = shotTiming.ToString("00");

        shotTimingCount.transform.position = transform.position - new Vector3(-2, 0);

        if(shotTiming <= -0.4f)
        {
            int cloneCount = clone.transform.childCount;

            if (cloneCount != 0)
            {
                for (int i = 0; i < cloneCount; i++)
                {
                    clone.transform.GetChild(i).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    clone.layer = 8;
                    clone.transform.GetChild(i).gameObject.layer = 8;
                }
            }
            else
            {
                clone.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                clone.layer = 8;
            }

            shotTiming = shotTiming2;
            canShot = 0;
            nextCreate = true;

        }

        if (canShot >= 0.5f && Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 shotForward = Vector2.Scale(mouseWorldPos - transform.position, new Vector2(1, 1));

            int cloneCount = clone.transform.childCount;

            if (cloneCount != 0)
            {
                for (int i = 0; i < cloneCount; i++)
                {
                    clone.transform.GetChild(i).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    clone.transform.GetChild(i).GetComponent<Rigidbody2D>().velocity = shotForward * shotSpeed / 3;
                    clone.layer = 8;
                    clone.transform.GetChild(i).gameObject.layer = 8;
                }
            }
            else
            {
                clone.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                clone.GetComponent<Rigidbody2D>().velocity = shotForward * shotSpeed / 3;
                clone.layer = 8;
            }

            canShot = 0;
            nextCreate = true;
            shotTiming = shotTiming2;
        }

        ShotPositionMove();

        MoveLimit();

        TimingAdd();

    }

    void TimingAdd()
    {
        int checkDeleteLines = score.getDeleteLines();
        Debug.Log(checkDeleteLines);
        Debug.Log(rotateZSpeed);
        Debug.Log(shotTiming2);

        if(checkDeleteLines != 0 && checkDeleteLines % 5 == 0)
        {
            if (canAdd)
            {
                rotateZSpeed += 1;
                if (shotTiming2 > 1)
                {
                    shotTiming2 -= 0.5f;

                }
                canAdd = false;
            }
        }
        else
        {
            canAdd = true;
        }
    }


    void ShotPositionMove()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 moveDirection = new Vector2(x, 0).normalized;

        GetComponent<Rigidbody2D>().velocity = moveDirection * shooterSpeed;
    }

    void MoveLimit()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 pos = gameObject.transform.position;

        pos.x = Mathf.Clamp(pos.x, min.x + 2, max.x - 2);

        gameObject.transform.position = pos;
        shotTimingCount.transform.position = pos - new Vector2(1.5f,0);
    }

    void BlockCreate(int randomShot, float randomRotation)
    {
        switch (randomShot)
        {
            case 0:
                clone = Instantiate(Z, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;

            case 1:
                clone = Instantiate(RZ, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;

            case 2:
                clone = Instantiate(TSquare, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;

            case 3:
                clone = Instantiate(Stick, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;
            case 4:
                clone = Instantiate(HBlock, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;
            case 5:
                if (score.getDeleteLines() >= 0)
                {
                    clone = Instantiate(LBlock, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                }
                else
                {
                    clone = Instantiate(BigSquare, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                }
                break;
            case 6:
                clone = Instantiate(Dango, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;
            case 7:
                if (score.getDeleteLines() >= 0)
                {
                    clone = Instantiate(XBlock, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                }
                else
                {
                    clone = Instantiate(Ball, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                }
                break;
        }

    }

}
