using Unity.Jobs;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Components 
    private Rigidbody2D _rigidbody2D;
    
    // Capsule
    public float capsuleHeight = 0.25f;
    public float capsuleRadius = 0.08f;

    // Ground Check 
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
    private bool _canDoubleJump;

    // Forces 
    public float jumpForce = 10;
    public float fallForce = 2;
    public float doubleJumpForce = 0.01f;
    public float doubleJumpCoefficient = 2f;
    private Vector2 _gravityVector;
    
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

        Jump();
        Fall();
        DoubleJump();

        if (_groundCheck)
        {
            _canDoubleJump = false;
        }

    }

    private void DoubleJump()
    {
        if (!_groundCheck && _canDoubleJump && Input.GetKey(KeyCode.Space))
        {
            Debug.Log(_rigidbody2D.linearVelocity);
            float fuel = PlayerFuel.Instance.GetFuel();

            if (fuel < 0) return;
            if (_rigidbody2D.linearVelocityY < 0)
            {
                _rigidbody2D.linearVelocity += new Vector2(_rigidbody2D.linearVelocity.x, doubleJumpForce * doubleJumpCoefficient);
            }
            else
            {
                _rigidbody2D.linearVelocity += new Vector2(_rigidbody2D.linearVelocity.x, doubleJumpForce);
            }
            //if (_rigidbody2D.linearVelocityY < -5) _rigidbody2D.linearVelocityY = 0;
            
            PlayerFuel.Instance.DecreseFuel();
        }
    }

    private void Fall()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.linearVelocity += _gravityVector * (fallForce * Time.deltaTime);
            _canDoubleJump = true;
        }
    }

    private void Jump()
    {
        // Checks if player is trying to jump/can jump 
        if (Input.GetKeyDown(KeyCode.Space) && _groundCheck)
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, jumpForce);
        }
    }
}
