using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class PlayerAnimControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerController;


    private void Update()
    {
        _animator.SetFloat("Speed", _playerController.Velocity.z);

    }
}




