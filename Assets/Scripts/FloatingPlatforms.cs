using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{

    public GameObject shield;
    public TMPro.TextMeshProUGUI text;

    public List<GameObject> platforms = new List<GameObject>();
    public GameObject gameMap;

    //Disable the game map;
    public void DisableGameMap(){
        gameMap.SetActive(false);
    }

    //DisableRigidbodies goes through each of the platforms and sets their rigidbodies to be kinematic
    public void DisableRigidbodies(){
        foreach(GameObject platform in platforms){
            platform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    //EnableRigidbodies goes through each of the platforms and sets their rigidbodies to not be kinematic
    public void EnableRigidbodies(){
        foreach(GameObject platform in platforms){
            platform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    //Level Platforms
    public void LevelPlatforms(){
        foreach(GameObject platform in platforms){
            platform.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    //Levitate Platforms
    public void LevitatePlatforms(){
        foreach(GameObject platform in platforms){
            platform.transform.position += new Vector3(0, 1, 0); // Adjust the Y value as needed
        }
    }

    //Make circle from platforms and animate to new positions (this is made by copilot)
    public void MakeCircle(){
        Invoke("MovePlatformsAnimation", 4);  
    }

    public void MovePlatformsAnimation(){

        //turn on shield
        shield.SetActive(true);

        Animator animator = GetComponent<Animator>();
        //Emable the animator
        animator.enabled = true;
        animator.SetBool("MovePlatforms", true);

        text = GameObject.Find("HUDText").GetComponent<TMPro.TextMeshProUGUI>();

        text.text = "Step on him!";

    }

    private IEnumerator AnimatePlatformsToCircle(){
        float duration = 5.0f; // Duration of the animation
        float elapsedTime = 0.0f;

        Vector3[] startPositions = new Vector3[platforms.Count];
        Vector3[] targetPositions = new Vector3[platforms.Count];

        for(int i = 0; i < platforms.Count; i++){
            startPositions[i] = platforms[i].transform.position;
            float angle = i * Mathf.PI * 2 / platforms.Count;
            targetPositions[i] = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * 5; // Adjust the 5 as needed
        }

        while(elapsedTime < duration){
            for(int i = 0; i < platforms.Count; i++){
                platforms[i].transform.position = Vector3.Lerp(startPositions[i], targetPositions[i], elapsedTime / duration);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        for(int i = 0; i < platforms.Count; i++){
            platforms[i].transform.position = targetPositions[i];
        }

        // Animate transforming up 1 unit
        elapsedTime = 0.0f;
        Vector3 upOffset = new Vector3(0, 2, 0); // Adjust the Y value as needed

        while(elapsedTime < duration){
            for(int i = 0; i < platforms.Count; i++){
                platforms[i].transform.position = Vector3.Lerp(targetPositions[i], targetPositions[i] + upOffset, elapsedTime / duration);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        for(int i = 0; i < platforms.Count; i++){
            platforms[i].transform.position = targetPositions[i] + upOffset;
        }
    }


    

    //Enable the Game Map
    public void EnableGameMap(){
        gameMap.SetActive(true);
    }

    //Run Scene
    public void RunScene(){
        DisableRigidbodies();
        LevitatePlatforms();
        LevelPlatforms();


        MakeCircle();

        Invoke("DisableGameMap", 8);    

    }
}
