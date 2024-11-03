using UnityEngine;

public class EndGame : MonoBehaviour
{

    public Animator objectAnimator;

    public bool ShieldBroke = false;

    //On Trigger Enter
    public void OnTriggerEnter(Collider other){
        Debug.Log("EndGame: " + other.gameObject.tag);
        if(ShieldBroke){
            Debug.Log("SHIELD IS BROKEN");
                if(other.gameObject.tag == "Player"){
                objectAnimator.SetBool("MovePlatforms", false); 
                objectAnimator.SetBool("RobotSpike", true);
                Debug.Log("EndGame aniamtion");
                Invoke("DisableTrigger", 2);
            }
        } else {
            Debug.Log("not broken yet");
        }
        Debug.Log("EndGame: " + other.gameObject.tag);
    }

     //Disable Trigger
    public void DisableTrigger(){

        //Go to next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }
}
