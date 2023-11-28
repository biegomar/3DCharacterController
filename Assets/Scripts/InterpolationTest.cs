using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InterpolationTest : MonoBehaviour
{
    [SerializeField]
    private Transform A;

    [SerializeField] 
    private Transform B;

    [SerializeField]
    [Range(0,1)]
    private float t = 0.5f;

    private Vector3 position; 
    // Start is called before the first frame update
    void Start()
    {
        position = A.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        //position.x = position.x + (B.position.x - position.x) * t * Time.deltaTime;
        //position.y = position.y + (B.position.y - position.y) * t * Time.deltaTime;

        //transform.position = position;

        position = Vector3.Lerp(position, B.position, 3 * Time.deltaTime);

        transform.position = position;
    }
}
