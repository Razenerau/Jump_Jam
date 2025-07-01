using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Variables")]
    public float speed = 5;
    public float runningSpeed = 7;
    private Rigidbody2D _rigidbody2D;
    public bool _runningCheck = false;

    [Header("Components")]
    private PlayerAnimation _animator;
    public float horizontal = 0;
    public SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<PlayerAnimation>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _runningCheck = Input.GetKey(KeyCode.LeftShift);
         horizontal = Input.GetAxis("Horizontal");
        Vector2 newVelocity;

        if(horizontal < 0)
        {
            SpriteRenderer.flipX = false; 
        }
        else
        {
            SpriteRenderer.flipX = true;
        }

        if (_runningCheck)
        {
            _animator.SetRunning(true);
            newVelocity = new Vector2(horizontal * runningSpeed, _rigidbody2D.velocity.y);
        }
        else if(horizontal != 0)
        {
            _animator.SetWalking(true);
            newVelocity = new Vector2(horizontal * speed, _rigidbody2D.velocity.y);
        }
        else
        {
            _animator.SetIdle();
            newVelocity = _rigidbody2D.velocity;
        }

        _rigidbody2D.velocity = newVelocity;
    }
}
