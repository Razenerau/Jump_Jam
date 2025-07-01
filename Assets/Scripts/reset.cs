using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
