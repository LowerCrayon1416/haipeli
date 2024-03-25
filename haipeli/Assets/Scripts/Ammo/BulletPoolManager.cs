using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour {
  
    public static BulletPoolManager Instance;

    public GameObject bulletPrefab;

    public int bulletAmount = 20;

    private Queue<GameObject> bulletpool = new Queue<GameObject>();
     
    void Start()
    {
        Instance = this;
        InitializePool();
        GetBullet();
    }

    private void InitializePool (){

        for (int i = 0; i < bulletAmount; i++) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletpool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(){

        if(bulletpool.Count > 0){
            GameObject Bullet = bulletpool.Dequeue();
            Bullet.SetActive(true);
            return Bullet;
        }
        else{
            return null;
        }
    }


}
