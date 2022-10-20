using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    private void Update()
    {
        transform.position += moveSpeed * moveDirection * Time.deltaTime;
    }
    public void MoveTo(Vector2 dir)
    {
        moveDirection = dir;
    }
}
