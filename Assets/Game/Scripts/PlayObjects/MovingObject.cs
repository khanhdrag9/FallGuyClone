using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float movementSpeed;
    public Transform[] controlleds;
    public Vector3[] destinations;

    Rigidbody rb;
    int[] currentTo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentTo = new int[controlleds.Length];
    }

    void Update()
    {
        for(int i = 0; i < controlleds.Length; ++i)
        {
            Move(i);
        }
    }

    void Move(int index)
    {
        Transform trans = controlleds[index];
        Vector3 destination = destinations[currentTo[index]];

        trans.position = Vector3.MoveTowards(trans.position, destination, movementSpeed * Time.deltaTime);

        if (trans.position == destination)
        {
            ++currentTo[index];
            if (currentTo[index] >= destinations.Length) currentTo[index] = 0;
        }
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
