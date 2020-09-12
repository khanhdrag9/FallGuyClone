using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float rotationSpeed;
    public Transform forVertical;
    public Transform forHorizontal;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        forHorizontal.Rotate(Vector3.up, mouseX);
        forVertical.Rotate(Vector3.right, -mouseY);
    }
}
