using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offset;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    

    private void Update()
    {
        var targetPosition = target.position + Vector3.up * 4f;
        targetPosition.z -= offset;
        transform.position = targetPosition;
        
    }
}
