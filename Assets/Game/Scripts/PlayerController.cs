﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce;
    public float jumpForceDecrease;
    public float gravity = -9.8f;
    public float distanceToLanding = 0.2f;

    CharacterController characterController;
    InputHandler inputHandler;
    Rigidbody myRigidBody;
    float currentGravity;
    bool wasPlanning = true;

    Transform ghost;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = GetComponent<InputHandler>();
        myRigidBody = GetComponent<Rigidbody>();
        currentGravity = gravity;

        if (isLocalPlayer)
            CreationHelper.SetLayer(transform, LayerMask.NameToLayer("Player"), false);
        else
            CreationHelper.SetLayer(transform, LayerMask.NameToLayer("Enemy"), false);
    }

    void Update()
    {
        UpdateJump();
        UpdateMovement();
        UpdateLanding();
    }

    void UpdateJump()
    {
        if (wasPlanning && inputHandler.GetJump(out float delta))
        {
            currentGravity = jumpForce * delta;
            wasPlanning = false;
        }
    }

    void UpdateMovement()
    {
        float moveVertical = inputHandler.GetVertical();
        float moveHorizontal = inputHandler.GetHorizontal();
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement = transform.TransformDirection(movement);
        movement.y = currentGravity;
        movement *= Time.deltaTime * movementSpeed;


        characterController.Move(movement);

        currentGravity = Mathf.Clamp(currentGravity - jumpForceDecrease * Time.deltaTime, gravity, jumpForce);
    }

    void UpdateLanding()
    {
        if(Physics.Raycast(transform.position - characterController.center, Vector3.down, out RaycastHit info, distanceToLanding))
        {
            wasPlanning = true;

            CatchingLandObject.OnRemoveObject?.Invoke(characterController);
            CatchingLandObject catchingObject = info.transform.GetComponent<CatchingLandObject>();
            if (catchingObject) catchingObject.AddCaughtObject(characterController);
        }
        else
        {
            CatchingLandObject.OnRemoveObject?.Invoke(characterController);
        }
    }

    public bool IsAvailableForAttack()
    {
        return true;
    }
    

    //private void FixedUpdate()
    //{
    //    float moveVertical = Input.GetAxis("Vertical");
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * Time.fixedDeltaTime * movementSpeed;
    //    movement = transform.TransformDirection(movement);
    //    myRigidBody.velocity = movement;
    //}

}
