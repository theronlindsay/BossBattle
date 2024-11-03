using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void Restart(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }   

    public void Die(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            Die();
        }
    }
}
