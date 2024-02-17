using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRight : MonoBehaviour
{
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public Transform FirePoint;
   
    private Animator anim;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //shoot right
        {
            Shoot();
    
        }
       
    }
    
    void Shoot ()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);  //spawns bullte prefab on fire command
    }
    
   
    

}
    