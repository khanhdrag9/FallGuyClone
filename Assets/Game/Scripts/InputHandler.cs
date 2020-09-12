using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
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

    bool CanInput()
    {
        return true;
    }
}
