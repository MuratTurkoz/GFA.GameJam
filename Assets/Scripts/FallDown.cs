using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    private Vector3 _velocity;

    [SerializeField] PlayerMovement _playerMovement;
    //private void OnEnable()
    //{
    //    _playerMovement.VelocityChanged += OnVelocityChanged;
    //}
    //private void OnDisable()
    //{
    //    _playerMovement.VelocityChanged += OnVelocityChanged;
    //}
    //private void OnVelocityChanged(Vector3 vector)
    //{
    //    vector= _velocity;
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          _playerMovement.Velocity = Vector3.zero;
            Debug.Log(_playerMovement.Velocity);
            //OnVelocityChanged(_velocity);
            GameManager.Instance.PlayerLose();
           
        }

    }
    //private void Update()
    //{
    //    Debug.Log(_velocity);
    //}
}
