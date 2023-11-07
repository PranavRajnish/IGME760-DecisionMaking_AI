using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingState : BaseState<CarStateManager.CarState>
{
    bool bIsInBrakeZone;
    CarStateManager carStateManager;

    public DrivingState(CarStateManager.CarState carState, CarStateManager carStateManager) : base(carState) 
    {
        this.carStateManager = carStateManager;
    }

    public override void EnterState()
    {
        bIsInBrakeZone = false;
        Debug.Log("Entered Driving State");
    }

    public override void ExitState()
    {
        
    }

    public override CarStateManager.CarState GetNextState()
    {
        if (bIsInBrakeZone)
        {
            return CarStateManager.CarState.Braking;
        }
        return stateKey;
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BrakeCollider>() != null)
        {
            bIsInBrakeZone = true;
            carStateManager.brakeZone = collision as BoxCollider2D;
        }
    }

    public override void OnTriggerExit(Collider2D collision)
    {
        
    }

    public override void OnTriggerStay(Collider2D collision)
    {
        
    }

    public override void UpdateState()
    {
        carStateManager.rb.velocity = Vector2.up * carStateManager.CarSpeed * Time.deltaTime;
    }

}
