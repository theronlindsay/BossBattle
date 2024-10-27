using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotFrozen : RobotState
{
public RobotFrozen(RobotStateController rsc) : base(rsc){}

    public override void OnStateEnter()
    {
        rsc.scanner.GetComponent<Renderer>().material = rsc.red;
        rsc.GetComponent<NavMeshAgent>().isStopped = false;

        //Turn of gravity and robot collider
        rsc.GetComponent<Rigidbody>().useGravity = false;
        rsc.robotCollider.enabled = false;

        //Get the FloatingPlatform script and RunScene()
        rsc.floatingPlatforms.GetComponent<FloatingPlatforms>().RunScene();

    }

    public override void CheckTransitions(){
    }

    public override void Act()
    {
    }

    public override void OnStateExit()
    {
    }

    public void Exit(){
        rsc.SetState(new RobotChase(rsc));
    }
}
