using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    //[Header("Components")]
    //public BoxCollider2D BoxCollider;
    
    [Header("Movement Variables")]
    public float WalkingSpeed = 5;
    public float RunningSpeed = 7;
    public bool IsRunning = false;

    [Header("Jump/Fly Variables")]
    public float JumpForce = 2f;
    public float FlyForce = 0.1f;
    public float FlyMultiplier = 4f;
    public float MaxYVelocity = 25f;
    public Vector2 GravityVector;
    public float FallForce = 2f;
    public float SplatVelocity = -15f;
    public float SplatTime = 2f;

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
