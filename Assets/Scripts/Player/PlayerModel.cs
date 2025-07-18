using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Header("Input")]
    public float Horizontal;
    public bool IsJumpPressed = false;
    public bool IsJumpHeld = false;
    public bool IsRunning = false;

    [Header("Movement Variables")]
    public float WalkingSpeed = 5;
    public float RunningSpeed = 7;

    [Header("Jump/Fly Variables")]
    public float JumpForce = 2f;
    public float FlyForce = 0.1f;
    public float FlyMultiplier = 4f;
    public float MaxYVelocity = 25f;
    public Vector2 GravityVector;
    public float FallForce = 2f;
    public float SplatVelocity = -24f;
    public float SplatTime = 2f;
    public float FallingTime = 0f;
    public float TimeNeededToSplat = 0f;

    [Header("Jump Checks")]
    public bool IsGrounded = false;
    public bool IsJumping = false;
    public bool IsFalling = true;
    public bool IsFlying = false;
    public bool IsSplat = false;

    [Header("Fuel")]
    public float MaxFuel = 100f;
    public float CurrentFuel = 100f;
    public float FuelDecrement = 0.1f;
}
