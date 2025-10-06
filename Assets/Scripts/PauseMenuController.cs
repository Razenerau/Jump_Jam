using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenu;
    public GameObject Player;
    public Slider Slider;
    public AudioSource Music;

    
    void Start()
    {
        //SetPaused();
        SetMusicVolume(0.5f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetPaused();
        }
    }

    public void SetPaused()
    {
        IsPaused = !IsPaused;
        PauseMenu.SetActive(IsPaused);

        PlayerModel playerModel = Player.GetComponent<PlayerModel>();
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();

        if (IsPaused)
        {
            playerModel.LastVelocity = rb.velocity;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.isKinematic = false;
            rb.velocity = playerModel.LastVelocity;
        }
    }

    public void LoadedMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetMusicVolume()
    {
        Music.volume = Slider.value;
    }
    public void SetMusicVolume(float value)
    {
        Music.volume = value;
        Slider.value = value;
    }
}
