using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    Vector3 input;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        bool hitObject = Physics.Raycast(transform.position + Vector3.up, Vector3.down, 1.1f);

        input.z = Input.GetAxis("Vertical");
        input.x = Input.GetAxis("Horizontal");

        input = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * input;

        input *= speed;

        input.y = rb.velocity.y;

        if (hitObject && Input.GetKeyDown(KeyCode.Space))
        {
            input.y = jumpForce;
        }
     
        rb.velocity = input;
        
    }
}
