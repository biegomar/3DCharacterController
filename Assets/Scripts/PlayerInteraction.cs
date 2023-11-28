using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private Transform cameraRoot;

    // Start is called before the first frame update
    void Start()
    {
        cameraRoot = Camera.main.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraRoot.position, cameraRoot.forward, out hit, 4))
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                hit.transform.GetComponent<LightSwitch>().PressLightSwitch();
            }
            Debug.DrawLine(cameraRoot.position, hit.point, Color.red);
            Debug.DrawRay(hit.point, cameraRoot.forward * (2 -hit.distance), Color.yellow);
        }
        else
        {
            Debug.Log("Hit Nothing");
        }
    }
}
