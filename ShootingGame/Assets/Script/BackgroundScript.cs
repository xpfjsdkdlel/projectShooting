using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 3.0f;
    [SerializeField]
    private Vector3 startPos;

    private void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        if (transform.position.y <= -12.75f)
            transform.position = startPos;
    }
}
