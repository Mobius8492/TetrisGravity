using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private GameObject clone;

    public float shooterSpeed;
    public float shotSpeed;
    float rotateZ;

    private float canShot;
    private bool nextCreate;

    // Start is called before the first frame update
    void Start()
    {
        shooterSpeed = 5.0f;
        shotSpeed = 10.0f;
        nextCreate = true;
        gameObject.transform.position = new Vector2(0, 4.4f);
        rotateZ = 0;
        canShot = 0;
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

        clone.transform.rotation = Quaternion.Euler(0, 0, rotateZ);
        rotateZ += 2;
        clone.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
        }

        ShotPositionMove();
    }

    void ShotPositionMove()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 moveDirection = new Vector2(x, 0).normalized;

        GetComponent<Rigidbody2D>().velocity = moveDirection * shooterSpeed;

        MoveLimit();
    }

    void MoveLimit()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 pos = gameObject.transform.position;

        pos.x = Mathf.Clamp(pos.x, min.x + 2, max.x - 2);

        gameObject.transform.position = pos;
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
                clone = Instantiate(Ball, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;
            case 5:
                clone = Instantiate(BigSquare, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;
            case 6:
                clone = Instantiate(Dango, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;
            case 7:
                clone = Instantiate(HBlock, transform.position, Quaternion.Euler(0f, 0f, randomRotation));
                break;
        }

    }

}
