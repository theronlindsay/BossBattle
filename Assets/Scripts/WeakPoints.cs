using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoints : MonoBehaviour
{
    //on collision, destroy the object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //remove self from WeakPointManager
            GameObject.Find("WeakPoints").GetComponent<WeakPointManager>().RemoveWeakPoint(gameObject);

            Destroy(gameObject);
        }
    }
}
