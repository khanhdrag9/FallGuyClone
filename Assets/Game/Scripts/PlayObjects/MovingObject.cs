using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float movementSpeed;
    public Transform[] controlleds;
    public Vector3[] destinations;
    public int startTo;

    Rigidbody rb;
    int[] currentTo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCurrentTo(startTo);
    }

    void Update()
    {
        if(destinations.Length == 0) return;

        for(int i = 0; i < controlleds.Length; ++i)
        {
            Move(i);
        }
    }

    void Move(int index)
    {
        Transform trans = controlleds[index];
        Vector3 destination = destinations[currentTo[index]];

        trans.localPosition = Vector3.MoveTowards(trans.localPosition, destination, movementSpeed * Time.deltaTime);

        if (trans.localPosition == destination)
        {
            ++currentTo[index];
            if (currentTo[index] >= destinations.Length) currentTo[index] = 0;
        }
    }

    public void SetCurrentTo(int index)
    {
        startTo = index;
        currentTo = new int[controlleds.Length];
        for(int i = 0; i < currentTo.Length; ++i)
            currentTo[i] = index;
    }

    //private void FixedUpdate()
    //{
    //    if (toContinue > Time.time) return;

    //    rb.MovePosition(Vector3.MoveTowards(rb.position, destinations[currentTo], movementSpeed * Time.fixedDeltaTime));
    //    if (rb.position == destinations[currentTo])
    //    {
    //        toContinue = Time.time + restTime;
    //        ++currentTo;
    //        if (currentTo >= destinations.Length) currentTo = 0;

    //        return;
    //    }
    //}
}
