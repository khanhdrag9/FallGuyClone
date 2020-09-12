using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float liveTime = 10f;
    public float speedMovement = 200f;


    Vector3 target;
    Rigidbody rb;

    public void Shoot(Vector3 target)
    {
        Invoke("End", liveTime);
        this.target = target;
        rb = GetComponent<Rigidbody>();
        rb.velocity = (target - transform.position).normalized * speedMovement;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(target - transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        target = transform.position;
    }

    void End()
    {
        Destroy(gameObject);
    }
}
