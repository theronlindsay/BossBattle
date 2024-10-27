using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotSleeping : RobotState
{
    public RobotSleeping(RobotStateController rsc) : base(rsc){}

    public override void OnStateEnter()
    {
        rsc.scanner.GetComponent<Renderer>().material = rsc.blue;
    }

    // AI Should only transition when the player is nearby
    // Currently the AI will ignore the player if they are in sight, but not if they are close
    public override void CheckTransitions(){
        float dist = Vector3.Distance(rsc.transform.position, rsc.player.transform.position);
        if(dist < 5f){
            rsc.SetState(new RobotWorking(rsc)); 
        }
    }

    public override void Act()
    {
        rsc.GetComponent<NavMeshAgent>().isStopped = true;
    }

    public override void OnStateExit()
    {
    }
}
