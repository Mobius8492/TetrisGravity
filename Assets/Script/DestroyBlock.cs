using System.Collections;
using System.Collections.Generic;

using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class DestroyBlock : MonoBehaviour
{
    private List<GameObject> objtest;

    private SpriteRenderer spriteRenderer;
    private bool canDestroy;

    public Text blockCount;

    // Start is called before the first frame update
    void Start()
    {
        objtest = new List<GameObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        canDestroy = true;

        if (SceneManager.GetActiveScene().name == "test")
        {
            blockCount.gameObject.SetActive(true);
        }
        else
        {
            blockCount.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        blockCount.text = objtest.Count().ToString();

        if (canDestroy == true && objtest.Count >= 12)
        {
            Time.timeScale = 0.2f;

            StartCoroutine("DestroyAnimation");

            for (int i = objtest.Count() - 1; 0 <= i; i--)
            {
                FindObjectOfType<ScoreManager>().AddScore(objtest[i].GetComponent<BallTest>().getScore());
                Destroy(objtest[i]);
            }
            canDestroy = false;
            FindObjectOfType<ScoreManager>().AddDeleteLines();
            objtest.Clear();
        }

        if (SceneManager.GetActiveScene().name == "test" && Input.GetKeyDown(KeyCode.X))
        {
            for (int i = objtest.Count() - 1; 0 <= i; i--)
            {
                Destroy(objtest[i]);
            }
            objtest.Clear();
        }
    }

    IEnumerator DestroyAnimation()
    {
        gameObject.transform.localScale = new Vector2(7, 0.6f);
        spriteRenderer.color = new Color(255, 0, 0, 255);

        yield return new WaitForSeconds(0.5f);

        gameObject.transform.localScale = new Vector2(7, 0.1f);
        spriteRenderer.color = new Color(0, 0, 0, 0);
        Time.timeScale = 1.0f;

        yield return new WaitForSeconds(0.2f);

        canDestroy = true;
    }

    public bool getCanDestroy()
    {
        return canDestroy;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        objtest.Add(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        objtest.Remove(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }
}
