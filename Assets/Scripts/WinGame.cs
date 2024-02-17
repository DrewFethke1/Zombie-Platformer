using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinGame : MonoBehaviour
{
     void Start()
    {
        CompleteLevel();
    }
    void Update()
    {
        CompleteLevel();
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
