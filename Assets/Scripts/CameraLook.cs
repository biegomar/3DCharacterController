using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 300f;

    Vector3 localEulerAngles;
    
    void Update()
    {
        localEulerAngles.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        localEulerAngles.x = Mathf.Clamp(localEulerAngles.x, -80f, 80f);


        localEulerAngles.y += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.localEulerAngles = localEulerAngles;
    }
}
