using UnityEngine;

public class ShieldBreak : MonoBehaviour
{
    public Animator objectAnimator;
    public GameObject robot;

    //On Collider Enter
    public void OnTriggerEnter(Collider collision){
        Debug.Log("ShieldBreak: " + collision.gameObject.tag);

        if(collision.gameObject.tag == "Player"){
            Debug.Log("Shield Break");

            robot.GetComponent<EndGame>().ShieldBroke = true;   

            DestroySelf();
        }
        
    }

    public void DestroySelf(){
        Destroy(gameObject);
    }
}
