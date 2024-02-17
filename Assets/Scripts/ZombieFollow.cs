using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZombieFollow : MonoBehaviour
{
    public Transform Player;
    public Transform PlayerCheck;
    public float detectionRadius = 5f;
    public LayerMask whatIsPlayer;
    public float speed = 2f;
    bool PlayerDetected = true;
    private Vector2 target;
    public Transform Zombie;




    // Update is called once per frame
    void Update()
    {
        /*PlayerDetected = Physics2D.OverlapCircle (PlayerCheck.position, detectionRadius, whatIsPlayer);
        target = Player.transform.position;
        
        if (PlayerDetected)
        {
            Debug.Log("Yes");
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            PlayerDetected = true;
        }*/

        Zombie.transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed);
    }
}
