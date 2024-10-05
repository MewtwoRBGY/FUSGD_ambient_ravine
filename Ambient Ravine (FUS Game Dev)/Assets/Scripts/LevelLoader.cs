using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretLevelLoader : MonoBehaviour
{
    [SerializeField] int levelNumber = -1;

    void LoadLevel()
    {
        if(levelNumber < 0)
        {
            levelNumber = 1 + SceneManager.GetActiveScene().buildIndex;
        }
        SceneManager.LoadScene(levelNumber);
    }

   void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("HI");
            LoadLevel();
        }
    }
}
