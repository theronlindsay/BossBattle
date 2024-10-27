using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RobotState{

    protected RobotStateController rsc;
    
    public abstract void CheckTransitions();
    public abstract void Act();
    public virtual void OnStateEnter(){}

    public virtual void OnStateExit(){}

    public RobotState(RobotStateController rsc){
        this.rsc = rsc;
    }
}
