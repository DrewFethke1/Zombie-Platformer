using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   /* public Transform FirePoint;
    public Transform FirePointLeft;
    public bool canshoot;
    [SerializeField] private Rigidbody2D rb;
   private SpriteRenderer sprite;
    private Animator anim;
    public GameObject bulletPrefab;
    // Update is called once per frame
    private void start()
    {
        anim=GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        canshoot=true;
    }
    void Update()
    {
       if (canshoot)
       {
         if (Input.GetButtonDown("Fire1")) //shoot right on right mouse click
        {
            //anim.SetBool("ShootRight", true);
            Shoot();
           //anim.SetBool("ShootRight", false);
    
        }
        if (Input.GetButtonDown("Fire2")) //shoot left on left mouse click
        {
            //anim.SetBool("ShootLeft", true);
            Shoot2();
           // anim.SetBool("ShootLeft", false);
    
        }
       }
    }
    
    void Shoot () //right
    {
        anim.SetBool("ShootRight", true);
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);  //spawns bullte prefab on fire command
        canshoot=false;
        StartCoroutine(resetshoot());
    }
    void Shoot2 () //left
    {
        anim.SetBool("ShootLeft", true);
        Instantiate(bulletPrefab, FirePointLeft.position, FirePointLeft.rotation);  //spawns bullte prefab on fire command
        canshoot=false;
        StartCoroutine(resetshoot());
    }
    
   IEnumerator resetshoot()
   {
    yield return new WaitForSeconds(1);
    anim.SetBool("ShootRight", false);
    anim.SetBool("ShootLeft", false);
    canshoot=true;
   }
    
*/
}
    