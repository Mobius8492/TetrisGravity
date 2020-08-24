using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPosition : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        gameObject.transform.position = new Vector2(0 , 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 moveDirection = new Vector2(x, 0).normalized;

        GetComponent<Rigidbody2D>().velocity = moveDirection * speed;

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
}
