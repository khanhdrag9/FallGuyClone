using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CreateManyMovingCircleObjects : NetworkBehaviour
{
    public CircleMovingObject prefab;
    public int numberObjects;
    public float radius;
    public float height;
    public float speedApply;

    [HideInInspector]
    public List<CircleMovingObject> circles = new List<CircleMovingObject>();

    // public override void OnStartClient() //for host-er
    // {
    //     base.OnStartClient();
    //     if(isServer)
    //         RpcCreate();

    // }

    // [ClientRpc]
    // void RpcCreate()
    // {
    //     Create();
    // }

    // [Command]
    // void CmdCreate()
    // {
    //     Create();
    //     RpcCreate();
    // }

    void Update()
    {
        if(isServer)
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * speedApply, 0);
    }

    public void Create()
    {
        float angle = 360f / numberObjects;
        for(int i = 0; i < numberObjects; ++i)
        {
            var obj = CreateCircleObject(angle * i);
            // obj.GetComponentInChildren<RandomColorForRenderer>()?.UpdateColorRandomly();
            NetworkServer.Spawn(obj.gameObject);
        }

        // transform.localEulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
    }

    public CircleMovingObject CreateCircleObject(float angle)
    {
        CircleMovingObject obj = Instantiate(prefab, transform);
        SetCircleObject(obj, angle);
        circles.Add(obj);
        return obj;
    }

    public void SetCircleObject(CircleMovingObject obj, float angle)
    {
        float x = Mathf.Cos(Mathf.Deg2Rad * angle);
        float z = Mathf.Sin(Mathf.Deg2Rad * angle);
        obj.transform.position = new Vector3(x, 0, z) * radius + Vector3.up * height;

        obj.point = transform.position;
        obj.speedMovement = speedApply;
    }
}
