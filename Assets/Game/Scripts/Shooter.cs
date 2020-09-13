using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : NetworkBehaviour
{
    public float attackInterval = 1f;
    public GameObject bulletPrefab;
    public LayerMask layerMask;
    public Camera playerCamera;

    public GameObject testPoint;

    PlayerController playerController;
    InputHandler inputHandler;
    float nextAttackTime;

    Vector3 ShootPoint => new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        inputHandler = GetComponent<InputHandler>();
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        if (inputHandler.GetFire(out float delta))
        {
            if(playerController.IsAvailableForAttack() && Time.time >= nextAttackTime)
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        nextAttackTime = Time.time + attackInterval;

        var direction = playerCamera.ScreenPointToRay(ShootPoint);
        if(Physics.Raycast(direction, out RaycastHit info, 100, layerMask))
        {
            if (isServer) RpcAttack(info.point);
            else CmdAttack(info.point);
        }
    }

    GameObject BulletTo(Vector3 target)
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Shoot(target);
        return bullet;
    }

    [Command(ignoreAuthority = false)]
    void CmdAttack(Vector3 target)
    {
        var bullet = BulletTo(target);
        //NetworkServer.Spawn(bullet);
        RpcAttack(target);
    }

    [ClientRpc]
    void RpcAttack(Vector3 target)
    {
        BulletTo(target);
    }
}
