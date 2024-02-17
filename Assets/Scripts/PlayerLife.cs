using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    public static int coinAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

  private void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.CompareTag("Trap"))
    {
        Die();
        coinAmount = 0;
    }
   }
    private void Die()
   {
    RestartLevel();
    rb.bodyType = RigidbodyType2D.Static;
   }
   private void RestartLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
