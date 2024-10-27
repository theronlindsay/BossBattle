using UnityEngine;
using UnityEngine.AI;

public class RobotAttack : RobotState
{
public RobotAttack(RobotStateController rsc) : base(rsc){}

    public override void OnStateEnter()
    {
        rsc.scanner.GetComponent<Renderer>().material = rsc.black;
        rsc.GetComponent<NavMeshAgent>().isStopped = true;
        //Play the attack animation
        rsc.GetComponent<Animator>().Play("Attack");

        //Wait 1 second, then damage the player
        rsc.Invoke("Attack", 1f);

    }

    public override void CheckTransitions(){

    }

    public override void Act()
    {
        
    }

    public override void OnStateExit()
    {
    }
}
