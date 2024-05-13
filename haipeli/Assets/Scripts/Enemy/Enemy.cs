using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    void FixedUpdate()
   {
       if(!GameManager.instance.IsGamePlay())
       {
           return;
       }
       
       GetPlayer();

       Move();
   }

    private void Move()
   {
       if(playerTransform == null)
       {
           return;
       }
       Vector2 direction = (playerTransform.position - transform.position).normalized;
       body.MovePosition(body.position + direction * currentSpeed * Time.fixedDeltaTime);
   }

    private float currentSpeed = 1f;
    
    public Rigidbody2D body;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private Transform playerTransform;

    private void GetPlayer()
    {
        playerTransform = GameManager.instance.playerController.transform;
    }
}
