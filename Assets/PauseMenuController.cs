using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenu;
    public GameObject Player;

    
    void Start()
    {
        
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
}
