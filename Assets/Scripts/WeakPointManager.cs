using UnityEngine;
using System.Collections.Generic;

public class WeakPointManager : MonoBehaviour
{
    public List<GameObject> weakpoints = new List<GameObject>();

    //on start
    private void Start()
    {
        //find all weakpoints in the scene
        GameObject[] weakpointsInScene = GameObject.FindGameObjectsWithTag("WeakPoint");

        //add all weakpoints to the list
        foreach (GameObject weakpoint in weakpointsInScene)
        {
            AddWeakPoint(weakpoint);
        }
    }

    public void AddWeakPoint(GameObject weakpoint)
    {
        if (!weakpoints.Contains(weakpoint))
        {
            weakpoints.Add(weakpoint);
        }
    }

    public void RemoveWeakPoint(GameObject weakpoint)
    {
        if (weakpoints.Contains(weakpoint))
        {
            weakpoints.Remove(weakpoint);
        }
        CheckForWin();
    }

    private void CheckForWin()
    {
        if (weakpoints.Count == 0)
        {
            //Get the player Object and set the State to RobotChase
            GameObject.Find("Robot").GetComponent<RobotStateController>().SetStateToChase();
        }
    }
}