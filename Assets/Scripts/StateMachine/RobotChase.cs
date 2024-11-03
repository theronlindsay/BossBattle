using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class RobotChase : RobotState
{
public RobotChase(RobotStateController rsc) : base(rsc){}

    public override void OnStateEnter()
    {
        rsc.scanner.GetComponent<Renderer>().material = rsc.red;
        rsc.GetComponent<NavMeshAgent>().isStopped = false;

        //Deactive the shield
        rsc.shield.SetActive(false);

    }
    
    public override void CheckTransitions(){
        //If the player is not in sight, go back to working
        RaycastHit hit;
        Debug.DrawLine(rsc.scanner.transform.position, rsc.scanner.transform.TransformDirection(Vector3.forward) * 100, Color.red);
        if(Physics.Raycast(rsc.scanner.transform.position, rsc.scanner.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
            if(hit.collider.gameObject.tag != "Player"){
                if(rsc.debug){
                    Debug.Log("Player is not in sight");
                }
                rsc.SetState(new RobotWorking(rsc));
            }
        }

        //If the player is too close, go to attacking
        float dist = Vector3.Distance(rsc.transform.position, rsc.player.transform.position);   
        if(dist < 2f){
            rsc.SetState(new RobotAttack(rsc));
        }
        else{
            rsc.GetComponent<NavMeshAgent>().SetDestination(rsc.player.transform.position);
        }

    }

    public override void Act()
    {
        //Move towards the player
        rsc.GetComponent<NavMeshAgent>().SetDestination(rsc.player.transform.position);
    }

    public override void OnStateExit()
    {
    }
}
