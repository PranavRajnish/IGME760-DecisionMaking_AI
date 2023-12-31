using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState<EState> where EState : Enum
{
    public EState stateKey { get; private set; }

    public BaseState(EState key)
    {
        stateKey = key;
    }
    
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();

    public abstract void OnTriggerEnter(Collider2D collision);
    public abstract void OnTriggerStay(Collider2D collision);
    public abstract void OnTriggerExit(Collider2D collision);

}
