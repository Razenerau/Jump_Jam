using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel PlayerModel;
    public PlayerView PlayerView;
    public Rigidbody2D Rb;

    // All checks happen in Update
    void Update()
    {
        UptadeInput();

        JumpOrFlyCheck();

        FallCheck();

        
    }

    void FixedUpdate()
    {
        Jump();

        Fly();

        Gravity();

        SplatCountdown();

        ClampVelocityY();

        Movement();

        PlayerView.SetBools();
        PlayerView.SetVelocity(Rb.velocity);
    }

    private void ClampVelocityY()
    {
        float clampedYVelocity = Mathf.Clamp(Rb.velocity.y, -PlayerModel.MaxYVelocity, PlayerModel.MaxYVelocity);
        Rb.velocity = new Vector2(Rb.velocity.x, clampedYVelocity);
    }

    public void AddFuel(float num)
    {
        float newFuel = PlayerModel.CurrentFuel + num;
        PlayerModel.CurrentFuel = newFuel >= PlayerModel.MaxFuel ? PlayerModel.MaxFuel : newFuel;
        FuelBarController.Instance.SetFillAmount(PlayerModel.CurrentFuel);
    }

    private void SplatCountdown()
    {
        if (Rb.velocity.y <= PlayerModel.SplatVelocity)
        {
            PlayerModel.FallingTime += Time.deltaTime;
        }
        else
        {
            PlayerModel.FallingTime = 0f;
        }
    }

    //=============================================================================================
    //                          CHECKS
    //=============================================================================================

    private void FallCheck()
    {
        if (Rb.velocity.y < -1 && !PlayerModel.IsGrounded)
        {
            PlayerModel.IsFalling = true;
            //PlayerView.SetFalling();
        }
    }

    private void JumpOrFlyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!PlayerModel.IsGrounded && PlayerModel.CurrentFuel > 0)
            {
                PlayerModel.IsFlying = true;
                PlayerModel.IsFalling = false;
                PlayerModel.IsJumping = false;
            }
            else if (PlayerModel.CurrentFuel <= 0) 
            {
                //Debug.Log("Out of Fuel");
            }

            //jumping off the ground
            if (PlayerModel.IsGrounded)
            {
                PlayerModel.IsJumping = true;
            }

            if (PlayerModel.IsFalling && PlayerModel.CurrentFuel <= 0)
            {
                PlayerModel.IsJumpPressed = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayerModel.IsJumping = false;
            PlayerModel.IsFlying = false;
        }

        if(PlayerModel.CurrentFuel <= 0)
        {
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

    private void UptadeInput()
    {
        PlayerModel.Horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            PlayerModel.IsRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            PlayerModel.IsRunning = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerModel.IsJumpPressed = true;
            PlayerModel.IsJumpHeld = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayerModel.IsJumpHeld = false;
        }

    }
    private void Movement()
    {
        float horizontal = PlayerModel.Horizontal;
        float speed = PlayerModel.IsRunning ? PlayerModel.RunningSpeed : PlayerModel.WalkingSpeed;
        float newXVelocity = horizontal * speed;

        Rb.velocity = new Vector2(newXVelocity, Rb.velocity.y);

        if(PlayerModel.IsSplat)
        {
            Rb.velocity = Vector2.zero;
        }
    }

    private void Gravity()
    {
        if (!PlayerModel.IsGrounded && !PlayerModel.IsJumpHeld)
        {
            Rb.velocity += PlayerModel.GravityVector * (PlayerModel.FallForce * Time.deltaTime);
        }
    }

    private void Fly()
    {
        if (PlayerModel.IsFlying && PlayerModel.CurrentFuel > 0)
        {
            PlayerModel.IsJumpPressed = false;
            //Debug.Log("Flying");
            float flyMultiplier = Rb.velocity.y < -10 ? PlayerModel.FlyMultiplier : 1;
            Vector2 newVelocity = new Vector2(Rb.velocity.x, PlayerModel.FlyForce * flyMultiplier);
            Rb.velocity += newVelocity;

            PlayerModel.CurrentFuel -= PlayerModel.FuelDecrement;
            FuelBarController.Instance.SetFillAmount(PlayerModel.CurrentFuel);
        }
    }

    private void Jump()
    {
        if (PlayerModel.IsGrounded && PlayerModel.IsJumpPressed && !PlayerModel.IsFlying)
        {
            //Debug.Log("Jumped");
            PlayerModel.IsJumpPressed = false;
            Vector2 newVelocity = new Vector2(Rb.velocity.x, PlayerModel.JumpForce);
            Rb.velocity = newVelocity;
        }
    }

    //=============================================================================================
    //                          COLLISION   
    //=============================================================================================
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Ground") return;
        if (PlayerModel.TimeNeededToSplat <= PlayerModel.FallingTime)//Rb.velocity.y <= PlayerModel.SplatVelocity)
        {
            Debug.Log("Splat!");
            PlayerSplat playerSplat = GetComponent<PlayerSplat>();
            playerSplat.SetSplat();
        }
       
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
