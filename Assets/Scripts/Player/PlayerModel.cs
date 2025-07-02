using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Header("Movement Variables")]
    public float WalkingSpeed = 5;
    public float RunningSpeed = 7;
    public bool IsRunning = false;

    [Header("Jump Variables")]
    public float JumpForce = 2f;
    //public float JumpTime
    //public float 
    public bool IsGrounded = false;
    public bool IsJumping = false;
    public bool IsFalling = false;

    [Header("Fuel")]
    public float MaxFuel = 100f;
    public float CurrentFuel = 100f;
    public float FuelDecrement = 0.1f;
}
