using Unity.Jobs;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D _rigidbody2D;
    

    [Header("Capsule")]
    public float capsuleHeight = 0.25f;
    public float capsuleRadius = 0.08f;

    [Header("Ground Check")]
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
    private bool _canDoubleJump;

    [Header("Forces")]
    public float jumpForce = 10;
    public float fallForce = 2;
    public float doubleJumpForce = 0.01f;
    public float doubleJumpCoefficient = 2f;
    private Vector2 _gravityVector;

    [Header("Limits")]
    public float MaxXVelocity = 10f;
    public float MinXVelocity = -10f;
    public float MaxYVelocity = 15;
    public float MinYVelocity = -15f;

    // Sets gravity vector and connects components 
    private void Start() {
        _gravityVector = new Vector2(0, Physics2D.gravity.y);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
   private void Update()
    {
        // Checks if player is touching ground 
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(capsuleHeight, capsuleRadius), CapsuleDirection2D.Horizontal,
            0, groundMask);

        if (_groundCheck)
        {
            _canDoubleJump = false;
            PlayerAnim.Instance.Animator.SetBool("isFalling", false);

        }

        Jump();
        Fall();
        DoubleJump();

        

    }

    private void DoubleJump()
    {
        if (!_groundCheck && _canDoubleJump && Input.GetKey(KeyCode.Space))
        {
            float fuel = PlayerFuel.Instance.GetFuel();

            if (fuel < 0) return;
            if (_rigidbody2D.velocity.y < 0)
            {
                //PlayerAnimation.Instance.SetFlyingDown();
                _rigidbody2D.velocity += new Vector2(_rigidbody2D.velocity.x, doubleJumpForce * doubleJumpCoefficient);
            }
            else
            { 
                //PlayerAnimation.Instance.SetFlyingUp();
                _rigidbody2D.velocity += new Vector2(_rigidbody2D.velocity.x, doubleJumpForce);
            }
            
            PlayerFuel.Instance.DecreseFuel();
            PlayerAnim.Instance.Animator.SetBool("isFlying", true);
        }
    }

    private void Fall()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.velocity += Vector2.up * _gravityVector * (fallForce * Time.deltaTime);
            _canDoubleJump = true;
            if (PlayerAnim.Instance.Animator.GetBool("isJumping") == true)
            {
                PlayerAnim.Instance.Animator.SetBool("isFalling", true);
                PlayerAnim.Instance.Animator.SetBool("isJumping", false);
            }
            

        }
    }

    private void Jump()
    {
        // Checks if player is trying to jump/can jump 
        if (Input.GetKeyDown(KeyCode.Space) && _groundCheck)
        {

            PlayerAnim.Instance.Animator.SetBool("isJumping", true);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }
        //else if (!Input.GetKey(KeyCode.Space) && _groundCheck)
        //{
        //    PlayerAnim.Instance.Animator.SetBool("isJumping", false);
        //}
    }
}
