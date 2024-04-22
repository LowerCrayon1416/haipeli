using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D body;

    private Master controls;
    private Vector2 moveInput;
    private Vector2 aimInput;

    public Transform gunTransform;

    private void OnEnable() 
    {
        controls = new Master();
        controls.Enable();
    }

    private void OnDisable() 
    {
        controls.Disable();
    }

    void Update()
    {
        if(!GameManager.instance.IsGamePlay())
        {
            return;
        }
        Shoot();
        Aim();
    }   

    private void FixedUpdate(){
        if(!GameManager.instance.IsGamePlay())
        {
            return;
        }
        Move();
    }
    private void Shoot()
    {
        if(controls.Player.Shoot.triggered) {
            Debug.Log("Shoot");
            GameObject bullet = BulletPoolManager.Instance.GetBullet();
            bullet.transform.position = gunTransform.position;
            bullet.transform.rotation = gunTransform.rotation;
        }
    }

    private void Move()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }
    
    private void Aim(){
        aimInput = controls.Player.Aim.ReadValue<Vector2>();
        if(aimInput.sqrMagnitude > 0.1f){
            gunTransform.up = aimInput;
            float angle = (Mathf.Atan2(aimInput.x, -aimInput.y)) * Mathf.Rad2Deg;
            gunTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}