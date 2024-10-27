using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotWorking : RobotState
{
    public RobotWorking(RobotStateController rsc) : base(rsc){}

    public override void OnStateEnter()
    {
        rsc.scanner.GetComponent<Renderer>().material = rsc.red;
        rsc.GetComponent<NavMeshAgent>().isStopped = false;

    }

    public override void CheckTransitions(){
        rsc.scanner.transform.LookAt(rsc.player.transform.position);
        RaycastHit hit;
        Debug.DrawLine(rsc.scanner.transform.position, rsc.scanner.transform.TransformDirection(Vector3.forward) * 100, Color.red);
        if(Physics.Raycast(rsc.scanner.transform.position, rsc.scanner.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
            if(hit.collider.gameObject.tag != "Player"){
                if(rsc.debug){
                    Debug.Log("Player is not in sight");
                }
                rsc.SetState(new RobotSleeping(rsc));
            } else {
                if(rsc.debug){
                    Debug.Log("Player is in sight");
                }
                rsc.SetState(new RobotChase(rsc));
            }
        }
    }

    public override void Act()
    {
        float dist = Vector3.Distance(rsc.transform.position, rsc.currentDestination.position);
        if(dist <3f){
            rsc.currentDestination = rsc.RandomDestination();
        }
        else{
            rsc.robot.SetDestination(rsc.currentDestination.position);
        }


    }

    public override void OnStateExit()
    {
    }
}
