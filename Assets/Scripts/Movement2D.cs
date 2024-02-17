using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{

    private bool doubleJump;
    public bool isGrounded = true;
    public bool IsJumping;
    public bool canshoot;
    public GameObject bulletPrefab;
    public Transform FirePoint;
    public Transform FirePointLeft;
    private Animator anim;
    private float dirX = 0f;
    public float jumpingPower = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private bool m_FaceingRight = true;
    private SpriteRenderer sprite;
    public void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        canshoot=true;
    }
    private void Update()
    {
        //Jump();
        float dirX = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

       // if (Input.GetAxis("Horizontal") > 0)
       // {
        //    sprite.flipX = true;
      //  }
     //else if (Input.GetAxis("Horizontal") < 0)
      //  {
       //     sprite.flipX = false;
       // }
        
        if (isGrounded && !Input.GetButton("Jump"))
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


        
        if (dirX > 0f) //for running animation switch
        {
            anim.SetBool("Running", true);
            //sprite.flipX = false;
           //anim.SetBool("ShootRight", false);
            //anim.SetBool("ShootLeft", false);
        }
        else if (dirX < 0f)
        {
            anim.SetBool("Running", true);
            //sprite.flipX = true;
            //anim.SetBool("ShootRight", false);
            //anim.SetBool("ShootLeft", false);
        }
        else
        {
            anim.SetBool("Running", true);
        }//running animation switch


   
        if (canshoot)      //new shoot script
       {
         if (Input.GetButtonDown("Fire1")) //shoot right on right mouse click
        {
            anim.SetBool("ShootRight", true);
            Shoot();
           //anim.SetBool("ShootRight", false);
    
        }
        if (Input.GetButtonDown("Fire2")) //shoot left on left mouse click
        {
            anim.SetBool("ShootLeft", true);
            Shoot2();
            //anim.SetBool("ShootLeft", false);
    
        }
       }


    }
    //private void Flip()
    //{
      // m_FaceingRight = !m_FaceingRight;  //rotates gun point with player
        //transform.Rotate(0f, 180f, 0f);
    //}
    void Shoot () //right
    {
        
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);  //spawns bullte prefab on fire command
        canshoot=false;
        StartCoroutine(resetshoot());
    }
    void Shoot2 () //left
    {
        
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

}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;  // Ardity's namespace

public class Movement2D : MonoBehaviour
{
    private bool doubleJump;
    public bool isGrounded = true;
    public bool IsJumping;
    public bool canshoot;
    public GameObject bulletPrefab;
    public Transform FirePoint;
    public Transform FirePointLeft;
    private Animator anim;
    private float dirX = 0f;
    public float jumpingPower = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private bool m_FaceingRight = true;
    private SpriteRenderer sprite;

    // Reference to SerialController component
    public SerialController serialController;

    public void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        canshoot = true;

        // Obtain the SerialController component
        serialController = GameObject.FindObjectOfType<SerialController>();
    }

    private void Update()
    {
        string dataString = serialController.ReadSerialMessage();

        if (dataString == null)
            return;

        // Process the received string
        if (dataString.StartsWith("DATA"))
        {
            string[] vec3 = dataString.Substring(5).Split(',');  // Remove "DATA" prefix and split

            if (vec3.Length == 3)
            {
                // Joystick input processing
                int joystickX = int.Parse(vec3[0]);
                int joystickY = int.Parse(vec3[1]);

                // Right movement
                if (joystickX > 509)
                    dirX = (joystickX - 509) / 514f;
                // Left movement
                else if (joystickX < 509)
                    dirX = -(509 - joystickX) / 509f;
                else
                    dirX = 0f;

                // Jumping
                if (joystickY > 503 && isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                    doubleJump = true;
                }

                // Shooting
                if (vec3[2] == "1")
                {
                    Shoot2();
                }
                else if (vec3[2] == "2")
                {
                    Shoot();
                }
            }
        }

        // Apply movement
        Vector3 movement = new Vector3(dirX, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        // Animations and flipping sprite
        if (dirX != 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = dirX < 0;
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

    void Shoot()
    {
        if (canshoot)
        {
            Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
            canshoot = false;
            StartCoroutine(resetshoot());
        }
    }

    void Shoot2()
    {
        if (canshoot)
        {
            Instantiate(bulletPrefab, FirePointLeft.position, FirePointLeft.rotation);
            canshoot = false;
            StartCoroutine(resetshoot());
        }
    }

    IEnumerator resetshoot()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("ShootRight", false);
        anim.SetBool("ShootLeft", false);
        canshoot = true;
    }
}*/
