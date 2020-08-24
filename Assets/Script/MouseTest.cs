using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    private Vector2 position;
    private Vector2 screenToWorldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = Input.mousePosition;

        screenToWorldPosition = Camera.main.ScreenToWorldPoint(position);

        gameObject.transform.position = screenToWorldPosition;
        
    }
}
