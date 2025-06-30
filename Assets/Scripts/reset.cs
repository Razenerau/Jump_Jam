using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    
    void Update()
    {
        Debug.Log("rnsnt");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
