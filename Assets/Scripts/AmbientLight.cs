using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class AmbientLight : MonoBehaviour
{
    [SerializeField] public Light light1;
    [SerializeField] public Light light2;
    
    private bool onoff = true;
    private bool last = false;

    void renderLight(bool p)
    {
        if (p)
        {
            if (onoff)
            {
                light1.enabled = true;
                light2.enabled = false;
            }
            else
            {
                light2.enabled = true;
                light1.enabled = false;
            }
        }

        onoff = !onoff;
    }

    // Update is called once per frame
    
    void Start()
    {
        renderLight(true);
    }

    public void Update()
    {
        bool temp = Input.GetKey("k");
        
        renderLight(last);
        

        last = Input.GetKey("k");
    }
}
