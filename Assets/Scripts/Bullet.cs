using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;
    public int damage = 50;
    public float bulletspeed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletspeed;

    }
 void OnTriggerEnter2D (Collider2D hitInfo)
    {
       Enemy enemy = hitInfo.GetComponent<Enemy>();
       if (enemy != null)
       {
        enemy.TakeDamage(damage);
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
       }
       Destroy(gameObject);

    
    }

   
}
