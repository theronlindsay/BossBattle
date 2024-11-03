using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private TMP_Text text;
    public Button  restartButton;
    [SerializeReference] private int health = 3;
    public void TakeDamage(int damage){
        health -= damage;
        text.text = "Health: " + health;
        if(health <= 0){
            Die();
        }
    }

    private void Die(){
        Debug.Log("Player has died");
        Camera.main.backgroundColor = Color.black;
        GetComponent<PlayerController>().enabled = false;
        restartButton.gameObject.SetActive(true);
    }
}
