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

        //jump or fly
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jumping off the ground
            if (PlayerModel.IsGrounded)
            {
                Debug.Log("Jumping");
                PlayerModel.IsJumping = true;
            }
        }

        //falling
        if (Rb.velocity.y < -2) 
        {
            PlayerModel.IsFalling = true;
            Debug.Log("Falling");
        }

        
    }

    void LateUpdate()
    {
        if (PlayerModel.IsJumping)
        {
            Vector2 newVelocity = new Vector2(Rb.velocity.x, PlayerModel.JumpForce);
            Rb.velocity = newVelocity;
        }
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
        if (Input.GetKey(KeyCode.LeftShift)) { PlayerModel.IsRunning = true; }

        else { PlayerModel.IsRunning = false; }
    }

    //When touches ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Grounded");
        PlayerModel.IsGrounded = true;
        PlayerModel.IsFalling = false;
        PlayerModel.IsJumping = false;
    }
}
