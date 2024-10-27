using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensitivitySlider : MonoBehaviour
{

    public GameObject player;
    public void OnValueChanged(float value)
    {
        Debug.Log("Sensitivity: " + value);
        player.GetComponent<PlayerController>().ChangeSensitivity(value);

    }   
}
