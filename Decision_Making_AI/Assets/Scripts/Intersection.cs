using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    public int currentCars = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Car car = collision.GetComponent<Car>();
        if(car != null )
        {
            currentCars++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Car car = collision.GetComponent<Car>();
        if( car != null )
        {
            currentCars--;
        }
    }
}
