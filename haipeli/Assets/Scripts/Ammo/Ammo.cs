using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private float lifeTimer;
    public float speed = 5;

    private void OnEnable()
    {
        lifeTimer = 2;
    }
   
   
    void Start()
    {
        
    }

    
    void Update()
    {
       transform.Translate(Vector2.up * Time.deltaTime * speed); 
       lifeTimer = Time.deltaTime;
       if(lifeTimer <= 0)
       {
        BulletPoolManager.Instance.ReturnBullet(gameObject);
       }
    }
}
