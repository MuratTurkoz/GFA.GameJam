
using UnityEngine;

using Input = UnityEngine.Input;

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
    

    private Vector3 _velocity = new Vector3();

    private bool _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isGrounded)
        {
            horizontalInput = UnityEngine.Input.GetAxis("Horizontal" + inputID);
            verticalInput = Input.GetAxis("Vertical" + inputID);

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
            _rigidbody.velocity = new Vector3(horizontalInput*_horizontalSpeed, _rigidbody.position.y, verticalInput*_forwardSpeed);

        }
    }
}