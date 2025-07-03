using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation Instance;
    public Animator animator;

    private void Awake()
    {
        if (Instance == null) {Instance = this;}
        else Destroy(gameObject);
        animator = GetComponent<Animator>();
    }

    public void SetIdle()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isFalling", false);
    }

    public void SetWalking(bool tralse)
    {
        animator.SetBool("isWalking", tralse);
        animator.SetBool("isRunning", !tralse);
        animator.SetBool("isFalling", false);
    }

    public void SetRunning(bool tralse)
    {
        animator.SetBool("isWalking", !tralse);
        animator.SetBool("isRunning", tralse);
        animator.SetBool("isFalling", false);
    }

    /*public void SetJumping()
    {
        Animator.SetBool("IsJumping", true);
        Animator.SetBool("isWalking", false);
        Animator.SetBool("isRunning", false);
    }

    public void SetFalling()
    {
        Animator.SetBool("IsJumping", false);
        Animator.SetBool("isFalling", true );
    }

    public void SetFlyingUp()
    {
        Animator.SetBool("isFalling", false);
        Animator.SetBool("FlyingUp", true);
        Animator.SetBool("FlyingDown", false);
    }

    public void SetFlyingDown()
    {
        Animator.SetBool("FlyingUp", false);
        Animator.SetBool("FlyingDown", true);
        Animator.SetBool("isFalling", false);
    }*/

}
