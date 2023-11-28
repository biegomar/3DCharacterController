using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 300f;

    Vector3 localEulerAngles;

    InputAction look;
    GameInput gameInput;

    private void Awake()
    {
        gameInput = new GameInput();
    }

    private void OnEnable()
    {
        //look = gameInput.Player.Look;
        //look.Enable();
    }

    private void OnDisable()
    {
        //look.Disable();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            localEulerAngles.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            localEulerAngles.x = Mathf.Clamp(localEulerAngles.x, -80f, 80f);


            localEulerAngles.y += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

            transform.localEulerAngles = localEulerAngles;
        }
        
    }
}
