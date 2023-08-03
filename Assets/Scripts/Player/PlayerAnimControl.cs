using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class PlayerAnimControl : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerController;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _animator.velocity.magnitude);
        if (PlayerMovement.verticalInput!= 0)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }
}




