using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RobotFrozen : RobotState
{

    TextMeshProUGUI text = GameObject.Find("HUDText").GetComponent<TMPro.TextMeshProUGUI>();

public RobotFrozen(RobotStateController rsc) : base(rsc){}

    public override void OnStateEnter()
    {
        text = GameObject.Find("HUDText").GetComponent<TMPro.TextMeshProUGUI>();

        text.text = "GET ON A GREEN PLATFORM!!!!";
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
        text.text = "Boss Health";
        rsc.scanner.GetComponent<Renderer>().material = rsc.black;
        rsc.GetComponent<Rigidbody>().useGravity = true;
        rsc.robotCollider.enabled = true;
    }

    public void Exit(){
        rsc.SetState(new RobotChase(rsc));
    }
}
