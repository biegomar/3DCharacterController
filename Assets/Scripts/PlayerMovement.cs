using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    GameInput gameInput;
    InputAction move;
    InputAction jump;

    Rigidbody rb;

    Vector3 input;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 6f;


    private void Awake()
    {
        gameInput = new GameInput();
    }

    private void OnEnable()
    {        
        move = gameInput.Player.Move;
        jump = gameInput.Player.Jump;

        move.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementWithNewInputSystem();                     
    }

    private void HandleMovement()
    {
        bool isGrounded = GroundCheck();

        input.z = Input.GetAxis("Vertical");
        input.x = Input.GetAxis("Horizontal");

        input = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * input;

        input *= speed;

        input.y = rb.velocity.y;

        if (isGrounded && Input.GetButton("Jump"))
        {
            input.y = jumpForce;
        }

        rb.velocity = input;
    }

    private void HandleMovementWithNewInputSystem()
    {
        bool isGrounded = GroundCheck();

        input.z = move.ReadValue<Vector2>().y;
        input.x = move.ReadValue<Vector2>().x;

        input = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * input;

        input *= speed;

        input.y = rb.velocity.y;

        if (isGrounded && jump.triggered)
        {
            input.y = jumpForce;
        }

        rb.velocity = input;
    }

    private bool GroundCheck()
    {
        bool hitObject = Physics.Raycast(transform.position + Vector3.up, Vector3.down, 1.1f);

        Color debugColor = hitObject ? Color.green : Color.red;

        Debug.DrawRay(transform.position + Vector3.up, Vector3.down * 1.1f, debugColor, 0.01f, true);

        return hitObject;
    }
}
