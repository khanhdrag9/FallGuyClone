using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CatchingLandObject : MonoBehaviour
{
    public static Action<CharacterController> OnRemoveObject = delegate {};

    List<CharacterController> caugthObjects = new List<CharacterController>();

    Vector3 previousPosition;

    public bool IsServer {get; set; } = false;

    private void Start()
    {
        previousPosition = transform.position;
        OnRemoveObject += RemoveCaughtObject;
    }

    private void OnDestroy()
    {
        OnRemoveObject -= RemoveCaughtObject;
    }

    private void Update()
    {
        foreach (var obj in caugthObjects)
        {
            obj.Move(transform.position - previousPosition);
        }

        previousPosition = transform.position;
    }

    public void AddCaughtObject(CharacterController controller)
    {
        if(!caugthObjects.Contains(controller))
            caugthObjects.Add(controller);
    }

    public void RemoveCaughtObject(CharacterController element)
    {
        caugthObjects.Remove(element);
    }


}
