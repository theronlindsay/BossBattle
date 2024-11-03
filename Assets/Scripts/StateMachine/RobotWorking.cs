using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RobotWorking : RobotState
{

    private float cooldown = 5f;
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
                if(cooldown > 0){
                    cooldown -= Time.deltaTime;
                    return;
                } else {
                    cooldown = 5f;
                    rsc.SetState(new RobotSleeping(rsc));
                }
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

        public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Bullet"){
            //Take damage
            //Debug.Log("Robot Hit: " + collision.gameObject.GetComponent<bullet>().damage + " Health: " + robotHealth);  
            float damage = collision.gameObject.GetComponent<bullet>().damage;
            rsc.robotHealth -= damage;
            rsc.healthBar.value = rsc.robotHealth;
            if(rsc.robotHealth <= 16 && rsc.robotHealth > 0){
                rsc.SetState(new RobotFrozen(rsc));    
            } else {
                rsc.SetState(new RobotChase(rsc));
            }
        }
    }

    public override void OnStateExit()
    {
    }
}
