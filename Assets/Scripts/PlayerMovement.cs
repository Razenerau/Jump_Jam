using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
    public float runningSpeed = 7;
    private Rigidbody2D _rigidbody2D;
    private bool _runningCheck = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _runningCheck = Input.GetKey(KeyCode.LeftShift);
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 newVelocity;

        if (_runningCheck)
        {
            newVelocity = new Vector2(horizontal * runningSpeed, _rigidbody2D.linearVelocity.y);
        }
        else
        {
            newVelocity = new Vector2(horizontal * speed, _rigidbody2D.linearVelocity.y);
        }


        _rigidbody2D.linearVelocity = newVelocity;
    }
}
