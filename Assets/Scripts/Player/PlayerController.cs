using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel PlayerModel;
    public PlayerView PlayerView;
    public Rigidbody2D Rb;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

    private void Movement()
    {
        RunningCheck();

        float horizontal = Input.GetAxis("Horizontal");
        float newXVelocity;
        if (PlayerModel.IsRunning)
        {
            newXVelocity = horizontal * PlayerModel.RunningSpeed;
        }
        else
        {
            newXVelocity = horizontal * PlayerModel.WalkingSpeed;
        }
        Rb.velocity = new Vector2(newXVelocity, Rb.velocity.y);
    }

    private void RunningCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift)) { PlayerModel.IsRunning = true; Debug.Log("running"); }

        else { PlayerModel.IsRunning = false; Debug.Log("NOT running"); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("gorunde");
    }
}
