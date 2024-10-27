    using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RobotStateController : MonoBehaviour
{

    public GameObject player;
    public GameObject scanner;
    public RobotState currentState;
    public List<Transform> destinations = new List<Transform>();

    public NavMeshAgent robot;
    public Collider robotCollider;
    public float robotHealth;
    public Slider healthBar;
    public Transform currentDestination;
    public Material red;
    public Material blue;
    public Material black;

    public GameObject floatingPlatforms;    


    public bool debug = false;

    // Start is called before the first frame update
    void Start()
    {
        robot = GetComponent<NavMeshAgent>();
        robotCollider = GetComponent<Collider>();
        currentDestination = RandomDestination(); 
       
        SetState(new RobotWorking(this));
    }

    public Transform RandomDestination(){
        if(destinations.Count == 0){
            return null;
        }
        return destinations[Random.Range(0, destinations.Count)];
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Bullet"){
            //Take damage
            Debug.Log("Robot Hit: " + collision.gameObject.GetComponent<bullet>().damage + " Health: " + robotHealth);  
            float damage = collision.gameObject.GetComponent<bullet>().damage;
            robotHealth -= damage;
            healthBar.value = robotHealth;
            if(robotHealth <= 25 && robotHealth > 5){
                SetState(new RobotFrozen(this));    
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentState.CheckTransitions();
        currentState.Act();
        if(debug){
            Debug.Log("Current Destination: " + currentDestination);
        }
    }

    public void SetState(RobotState rs){
        if(currentState != null){
            currentState.OnStateExit();
        }
        currentState = rs;

        if(debug){
            Debug.Log("Current State: " + currentState);
        }
        
        if(currentState != null){
            currentState.OnStateEnter();
        }
    }

    public void Attack(){
        player.GetComponent<PlayerHealth>().TakeDamage(1);

        //If the player is still alive, go back to chasing
        SetState(new RobotChase(this));
    }
}
