using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppedState : BaseState<CarStateManager.CarState>
{
    CarStateManager carStateManager;

    private bool bStartDriving = false;

    public StoppedState(CarStateManager.CarState carState, CarStateManager carStateManager) : base(carState) 
    { 
        this.carStateManager = carStateManager;
    }

    public override void EnterState()
    {
        Debug.Log("Entering Stopped State");
        bStartDriving = false;
        carStateManager.rb.velocity = Vector2.zero;

        if(carStateManager.brakeZone != null)
        {
            carStateManager.brakeZone = null; 
        }
    }

    public override void ExitState()
    {
        
    }

    public override CarStateManager.CarState GetNextState()
    {
        if(bStartDriving)
        {
            return CarStateManager.CarState.Driving;
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
       if(carStateManager.currentIntersection.currentCars == 0)
        {
            bStartDriving = true;
        }
    }
}
