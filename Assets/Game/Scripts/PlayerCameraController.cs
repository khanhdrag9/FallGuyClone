using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCameraController : NetworkBehaviour
{
    public float rotationSpeed;
    public Transform forVertical;
    public Transform forHorizontal;
    public Camera playerCamera;

    InputHandler inputHandler;

    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        if (!isLocalPlayer)
            playerCamera.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = inputHandler.GetMouseX();
        float mouseY = inputHandler.GetMouseY();

        forHorizontal.Rotate(Vector3.up, mouseX);
        forVertical.Rotate(Vector3.right, -mouseY);
    }
}
