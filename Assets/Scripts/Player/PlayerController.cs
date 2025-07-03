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

    // All checks happen in Update
    void Update()
    {
        RunningCheck();

        JumpOrFlyCheck();

        FallCheck();
    }

    // All movement happens in Late Update
    void LateUpdate()
    {
        // Jump
        if (PlayerModel.IsJumping && Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 newVelocity = new Vector2(Rb.velocity.x, PlayerModel.JumpForce);
            Rb.velocity = newVelocity;
        }

        // Flying
        if (PlayerModel.IsFlying)
        {
            float flyMultiplier = Rb.velocity.y < -10 ? PlayerModel.FlyMultiplier : 1;
            Vector2 newVelocity = new Vector2(Rb.velocity.x, PlayerModel.FlyForce * flyMultiplier);
            Rb.velocity += newVelocity;
        }

        // Gravity
        if(!PlayerModel.IsGrounded && !Input.GetKey(KeyCode.Space))
        {
            Rb.velocity += PlayerModel.GravityVector * (PlayerModel.FallForce * Time.deltaTime);
        }

        float clampedYVelocity = Mathf.Clamp(Rb.velocity.y, -PlayerModel.MaxYVelocity, PlayerModel.MaxYVelocity);
        Rb.velocity = new Vector2(Rb.velocity.x, clampedYVelocity);

        Movement(); // Clamps X velocity
    }

    //=============================================================================================
    //                          CHECKS
    //=============================================================================================

    private void FallCheck()
    {
        if (Rb.velocity.y < -1 && !PlayerModel.IsGrounded)
        {
            PlayerModel.IsFalling = true;
        }
    }

    private void JumpOrFlyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if((PlayerModel.IsJumping || PlayerModel.IsFalling) && PlayerModel.CurrentFuel > 0)
            {
                PlayerModel.IsFlying = true;
                PlayerModel.IsFalling = false;
                PlayerModel.IsJumping = false;
            }

            //jumping off the ground
            if (PlayerModel.IsGrounded)
            {
                PlayerModel.IsJumping = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayerModel.IsJumping = false;
            PlayerModel.IsFlying = false;
        }
    }

    private void RunningCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift)) { PlayerModel.IsRunning = true; }

        else { PlayerModel.IsRunning = false; }
    }

    //=============================================================================================
    //                      MOVEMENT
    //=============================================================================================

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float speed = PlayerModel.IsRunning ? PlayerModel.RunningSpeed : PlayerModel.WalkingSpeed;
        float newXVelocity = horizontal * speed;

        Rb.velocity = new Vector2(newXVelocity, Rb.velocity.y);
    }

    

    //=============================================================================================
    //                          COLLISION   
    //=============================================================================================
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerModel.IsGrounded = true;
        PlayerModel.IsFalling = false;
        PlayerModel.IsJumping = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerModel.IsGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerModel.IsGrounded = false;
    }
}
