using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float Speed = 10f;
    
    public bool bIsGoingLeft;

    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        if(bIsGoingLeft)
        {
            rb.velocity = Vector2.left * Speed;
        }
        else
        {
            rb.velocity = Vector2.right * Speed;
        }
    }

    public void SetIsGoingLeft(bool isGoingLeft)
    {
        bIsGoingLeft = isGoingLeft;
        if(isGoingLeft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
