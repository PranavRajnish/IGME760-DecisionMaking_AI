using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCars : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Car>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
