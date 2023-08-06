using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;

    [SerializeField] private float _horizontalSpeed;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _jumpPower;
    public float JumpPower
    {
        get => _jumpPower;
        set => _jumpPower = value;
    }


    [SerializeField]
    private float _maxHorizontalDistance;

    private bool _isGrounded;
    private Vector3 _velocity = new Vector3();
    public Vector3 Velocity
    {
        get => _velocity;
        set { _velocity = value;}
    }
    BoxCollider _myFeetCollider;

    private void Awake()
    {
        _myFeetCollider = GetComponent<BoxCollider>();
        //_rigidbody.position = Vector3.zero;
    }



    //public event Action<Vector3> VelocityChanged;
    private void Update()
    {
        Debug.Log(GameManager.Instance.Lose);

        if (!GameManager.Instance.IsGameStarted)
        {
            _velocity = Vector3.zero;
            return;
        }
        if (!GameManager.Instance.Lose)
        {
            _velocity = Vector3.zero;
            return;

        }


        _velocity.z = _forwardSpeed;
        _velocity.y = _rigidbody.velocity.y;
        _velocity.x = Input.GetAxis("Horizontal") * _horizontalSpeed;
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            //_velocity.y = _jumpPower;
            _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _isGrounded = false;
        }

    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_rigidbody.position.x) > _maxHorizontalDistance)
        {
            var clampedPosition = _rigidbody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_maxHorizontalDistance, _maxHorizontalDistance);

            _rigidbody.position = clampedPosition;
        }

        _rigidbody.velocity = _velocity;
        //RaycastHit hitInfo;
        //_isGrounded = Physics.Raycast(_rigidbody.position, Vector3.down, out RaycastHit hitInfo, 2f);
        //Debug.Log(hitInfo.collider);
        //Debug.Log(_rigidbody.position);
        //Debug.DrawRay(_rigidbody.position + Vector3.forward, Vector3.down, Color.black);
        //if (hitInfo.distance != null)
        //{

        //}
    }
    //void OnJump()
    //{
    //    if (!GameManager.Instance.IsGameStarted) { return; }
    //    if (!_myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
    //    if (value.isPressed)
    //    {
    //        myAnimator.SetBool("isRunning", false);
    //        myAnimator.SetBool("isJumping", true);
    //        myRigidbody.velocity += new Vector2(0f, jumpSpeed);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log(collision.gameObject.name);
            _isGrounded = true;

        }
    }
}