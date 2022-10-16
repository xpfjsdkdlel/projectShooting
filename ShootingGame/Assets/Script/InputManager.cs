using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController controller;
    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if(controller == null)
        {
            Debug.Log("ĳ���� ��Ʈ�ѷ��� ã�� ���߽��ϴ�.");
        }
    }
    private void OnMouseDown()
    {
        controller.ISMOVE = true;
    }
    private void OnMouseUp()
    {
        controller.ISMOVE = false;
    }
}
