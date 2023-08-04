using UnityEngine;
using UnityEngine.Splines;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _speed = 5f;

    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;

    [SerializeField] private float _jumpForce;

    [SerializeField]
    private float maxLeft;
    [SerializeField]
    private float maxRight;

    public string inputID;

    private float speed = 20.0f;
    [SerializeField] private float turnSpeed = 20.0f;
    public static float horizontalInput;
    public static float verticalInput;
    [SerializeField] private Rigidbody _rigidbody;
    public Transform[] controlPoints;

    private Vector3 _firstPosition;
    private Vector3 _lastPosition;
    private Vector3 _directionVector;
    private Vector3 _velocity = new Vector3();
    private InputManager _inputManager;
    private Vector3 _mousePos;

    private bool _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputManager = GetComponent<InputManager>();

    }

    private void Update()
    {
        if (_isGrounded)
        {

            //if (Input.GetMouseButtonDown(0))
            //{
            //    _firstPosition = Input.mousePosition;
            //}
            //if (Input.GetMouseButtonUp(0))
            //{
            //    _lastPosition = Input.mousePosition;
            //    _directionVector = _lastPosition - _firstPosition;
            //    _inputManager.MoveCharacter(_directionVector);
            //    _inputManager.RotateCharcter(_directionVector);
            //}


            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            //_mousePos = Input.mousePosition;
            //Debug.Log(_mousePos);
            //transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed *_mousePos.x );
            //if (Input.GetMouseButton(0))
            //{

            //}
            //if (Input.GetButtonUp("Horizantal"))
            //{

            //}

            //transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput);


            //transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
        // var horizontalInput = Input.GetAxis("Horizontal");
        // var verticalInput = Input.GetAxis("Vertical");


        //if (Input.GetKey(KeyCode.UpArrow) && _isGrounded)
        //{
        //    transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        //}
        //{
        //    transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow) && _isGrounded)
        //{
        //    transform.Translate(Vector3.left * _speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.RightArrow) && _isGrounded)
        //{
        //    transform.Translate(Vector3.right * _speed * Time.deltaTime);
        //}


        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, maxLeft, maxRight);
        transform.position = pos;

        _rigidbody.velocity = _velocity;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            // _rigidbody.AddForce(Vector3.up * 6f, ForceMode.Impulse);
            // _isGrounded = false;
            _velocity.y += Mathf.Sqrt(_jumpForce * -3.0f * Physics.gravity.y);
        }

        _velocity.y += Physics.gravity.y * Time.deltaTime;
    }


    private void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, Vector3.down,Color.red);
        _isGrounded = Physics.Raycast(_rigidbody.position, Vector3.down, 1.05f);
        if (_isGrounded)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.velocity = new Vector3(horizontalInput * _horizontalSpeed, _rigidbody.position.y, verticalInput * _forwardSpeed);
            //Debug.Log(_rigidbody.velocity);


        }
    }
}