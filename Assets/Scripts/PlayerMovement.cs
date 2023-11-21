using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    Vector3 input;

    [SerializeField]
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        input.z = Input.GetAxis("Vertical");
        input.x = Input.GetAxis("Horizontal");

        input = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * input;
        Camera.main.transform.localRotation = Quaternion.identity;

        rb.velocity = input * speed;
        
    }
}
