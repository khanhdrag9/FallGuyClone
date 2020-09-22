using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

// public class CircleMovingObject : NetworkBehaviour
public class CircleMovingObject : MonoBehaviour
{
    // [SyncVar]public Vector3 position;

    public float speedMovement;
    public Vector3 point;

    void Start()
    {
        
    }

    void Update()
    {
        // if(isServer)
        // {
        //     transform.RotateAround(point, Vector3.up, speedMovement * Time.deltaTime);
        //     position = transform.position;
        // }
        // else
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, position, speedMovement * Time.deltaTime);
        // }
    }

    void OnPositionUpdate(Vector3 oldPos, Vector3 newPos)
    {
    }
}
