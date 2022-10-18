using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : PoolLabel
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerController>(out PlayerController pc))
        Debug.Log(collision.gameObject.name + "메테오에 맞았다");
    }
}
