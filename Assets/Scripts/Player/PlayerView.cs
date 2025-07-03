using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Animator Animator;
    public PlayerModel PlayerModel;
    public SpriteRenderer SpriteRenderer;

    public void SetVelocity(Vector2 velocity)
    {
        Animator.SetFloat("xVelocity", Mathf.Abs(velocity.x));
        Animator.SetFloat("yVelocity", velocity.y);

        SetDirecion(velocity.x);
    }

    public void SetDirecion(float xVelocity)
    {
        SpriteRenderer.flipX = xVelocity > 0 ? true : false;
    }

    public void SetBools()
    {
        Animator.SetBool("isGrounded", PlayerModel.IsGrounded);
        Animator.SetBool("isFalling", PlayerModel.IsFalling);
        Animator.SetBool("isJumping", PlayerModel.IsJumping);
        Animator.SetBool("isFlying",  PlayerModel.IsFlying);
    }


}
