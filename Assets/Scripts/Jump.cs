/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jump : MonoBehaviour
{
    private bool doubleJump;
    public bool isGrounded;
    public bool IsJumping;
    public float jumpingPower = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
      if (isGrounded && Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
      if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                doubleJump = !doubleJump;
            }
            
        }
      if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
}*/
