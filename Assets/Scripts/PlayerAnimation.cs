using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation Instance;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIdle()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
    }

    public void SetWalking(bool tralse)
    {
        animator.SetBool("isWalking", tralse);
        animator.SetBool("isRunning", !tralse);
    }

    public void SetRunning(bool tralse)
    {
        animator.SetBool("isWalking", !tralse);
        animator.SetBool("isRunning", tralse);

    }

}
