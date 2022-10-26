using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") && collision.TryGetComponent<Item>(out Item item))
        {
            collision.GetComponent<Item>().SetTarget(gameObject);
            Debug.Log(collision.name);
        }
    }
}
