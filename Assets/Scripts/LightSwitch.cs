using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField]
    private Light lightSource;

    public void PressLightSwitch()
    {
        lightSource.enabled = !lightSource.enabled;
    }  
}
