using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    private Camera _mainCamera;

    private float camTarget;
    [SerializeField] private float zoomFactor = 100f;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        camTarget = Mathf.Clamp(_mainCamera.orthographicSize - Input.mouseScrollDelta.y * zoomFactor * Time.deltaTime, 1f, 15f);
        _mainCamera.orthographicSize = camTarget;
    }
}

