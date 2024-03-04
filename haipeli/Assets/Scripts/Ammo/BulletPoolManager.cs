using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
  
    public static BulletPoolManager Instance;

    public GameObject bulletPrefab;

    public int bulletAmount = 20;

    private Queue<GameObject> bulletpool = new Queue<GameObject>();
}
