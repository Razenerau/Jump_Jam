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
        animator.SetBool("IsJumping", true);
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
    }

    public void SetFalling()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("isFalling", true );
    }

    public void SetFlyingUp()
    {
        animator.SetBool("isFalling", false);
        animator.SetBool("FlyingUp", true);
        animator.SetBool("FlyingDown", false);
    }

    public void SetFlyingDown()
    {
        animator.SetBool("FlyingUp", false);
        animator.SetBool("FlyingDown", true);
        animator.SetBool("isFalling", false);
    }*/

}
