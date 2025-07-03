using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Animator Animator;
    public PlayerModel PlayerModel;
    
    public void UpdateVelocity(Vector2 velocity)
    {
        Animator.SetFloat("xVelocity", Mathf.Abs(velocity.x));
        Animator.SetFloat("yVelocity", velocity.y);
    }



    public void UpdateBools()
    {
        Animator.SetBool("isGrounded", PlayerModel.IsGrounded);
        Animator.SetBool("isFalling", PlayerModel.IsFalling);
        Animator.SetBool("isJumping", PlayerModel.IsJumping);
        Animator.SetBool("isFlying",  PlayerModel.IsFlying);
    }


}
