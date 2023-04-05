using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//TODO: uncomment sound code once audio file exists
public class LevelLoader : MonoBehaviour
{
    // private AudioSource finishSound;
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Player"))
        {
            // finishSound.Play();
            Invoke("LoadNextLevel", 1f);
            
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
