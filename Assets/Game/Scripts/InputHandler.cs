using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class InputHandler : NetworkBehaviour
{
    public float GetVertical()
    {
        if (CanInput()) return Input.GetAxis("Vertical");
        return 0;
    }

    public float GetHorizontal()
    {
        if (CanInput()) return Input.GetAxis("Horizontal");
        return 0;
    }

    public bool GetJumpDelta(out float delta)
    {
        delta = 0;
        if (!CanInput()) 
            return false;

        delta = Input.GetAxis("Jump");
        return delta != 0;
    }

    public float GetMouseX()
    {
        if(CanInput()) return Input.GetAxis("Mouse X");
        return 0;
    } 
    
    public float GetMouseY()
    {
        if(CanInput()) return Input.GetAxis("Mouse Y");
        return 0;
    }


    bool canInput = true;
    bool CanInput()
    {
        return canInput && isLocalPlayer;
    }

    private void Update()
    {
        if (!isLocalPlayer) return;

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Home");
            return;
        }

        //Enable/Disable CanInput InGameplay
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    canInput = !canInput;
        //}

        //if (canInput)
        //    Cursor.lockState = CursorLockMode.Locked;
        //else
        //    Cursor.lockState = CursorLockMode.None;
    }
}
