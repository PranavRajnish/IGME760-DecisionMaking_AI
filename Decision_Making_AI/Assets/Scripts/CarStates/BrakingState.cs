using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrakingState : BaseState<CarStateManager.CarState>
{
    private CarStateManager carStateManager;
    private float YStopCoord;
    private float stopDistance = 0.2f;
    private bool bIsStopped = false;

    public BrakingState(CarStateManager.CarState carState, CarStateManager carStateManager) : base(carState) 
    {
        this.carStateManager = carStateManager;
    }

    public override void EnterState()
    {
        Debug.Log("Entering Braking State");
        bIsStopped = false;
        if (carStateManager.brakeZone != null )
        {
            YStopCoord = carStateManager.brakeZone.bounds.center.y + carStateManager.brakeZone.bounds.size.y/2 - carStateManager.carHeight/2;
        }
    }

    public override void ExitState()
    {
        
    }

    public override CarStateManager.CarState GetNextState()
    {
        if(bIsStopped)
        {
            return CarStateManager.CarState.Stopped;
        }

        return stateKey;
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        
    }

    public override void OnTriggerExit(Collider2D collision)
    {

    }

    public override void OnTriggerStay(Collider2D collision)
    {
       
    }

    public override void UpdateState()
    {
        float distanceToStopPoint = YStopCoord - carStateManager.transform.position.y;
        carStateManager.rb.velocity = Vector2.up * (carStateManager.CarSpeed * (distanceToStopPoint / (carStateManager.brakeZone.bounds.size.y - carStateManager.carHeight/2)) * Time.deltaTime);

        if(distanceToStopPoint < stopDistance)
        {
            bIsStopped = true;
        }
    }

}
