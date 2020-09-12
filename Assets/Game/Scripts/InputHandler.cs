using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class InputHandler : NetworkBehaviour
{
    public bool GetFire(out float delta)
    {
        delta = GetDeltaWithName("Fire1");
        return delta != 0;
    }

    public float GetVertical()
    {
        return GetDeltaWithName("Vertical");
    }

    public float GetHorizontal()
    {
        return GetDeltaWithName("Horizontal");
    }

    public bool GetJump(out float delta)
    {
        delta = GetDeltaWithName("Jump");
        return delta != 0;
    }

    public float GetMouseX()
    {
        return GetDeltaWithName("Mouse X");
    } 
    
    public float GetMouseY()
    {
        return GetDeltaWithName("Mouse Y");
    }

    float GetDeltaWithName(string name)
    {
        return CanInput() ? Input.GetAxis(name) : 0f;
    }


    bool canInput = true;
    bool CanInput()
    {
        return canInput && isLocalPlayer;
    }

    private void Update()
    {
        if (!isLocalPlayer) return;

        if(Input.GetKeyUp(KeyCode.Backspace))
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
