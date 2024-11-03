using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour
{

    public InputActionReference quitAction;
    public void Quit()
    {
        Application.Quit();
    }

    //onquit action
    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Quit();
        }
    }
}
