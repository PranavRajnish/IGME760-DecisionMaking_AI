using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarStateManager : StateManager<CarStateManager.CarState>
{

    public float CarSpeed = 10f;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public BoxCollider2D carCollider;

    public Intersection currentIntersection;
    public BoxCollider2D brakeZone;

    [HideInInspector] public float carHeight;

    public enum CarState
    {
        Driving,
        Braking,
        Stopped
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        carCollider = GetComponent<BoxCollider2D>();
        carHeight = carCollider.bounds.size.y;

        currentState = new DrivingState(CarState.Driving, this);
        states.Add(CarState.Driving, currentState);
        states.Add(CarState.Braking, new BrakingState(CarState.Braking, this));
        states.Add(CarState.Stopped, new StoppedState(CarState.Stopped, this));

        currentState.EnterState();
    }

   protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Intersection intersection = collision.gameObject.GetComponent<Intersection>();
        if (intersection != null)
        {
            currentIntersection = intersection;
        }

        currentState.OnTriggerEnter(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        Intersection intersection = collision.gameObject.GetComponent<Intersection>();
        if (intersection != null && currentIntersection == intersection)
        {
            currentIntersection = null;
        }

        currentState.OnTriggerExit(collision);
    }
}
