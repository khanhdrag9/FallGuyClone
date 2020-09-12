using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
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
        if(inputHandler.GetFire(out float delta))
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
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Shoot(info.point);
        }
    }
}
