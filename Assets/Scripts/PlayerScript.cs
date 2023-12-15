using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Text textFrames;
    private float nTemp;

    private int i= 0;
    
    // Update is called once per frame
    void Update()
    {
        nTemp = (1/Time.deltaTime);

        i = (i+1)%60;
        if (i > 58)
        {textFrames.text = nTemp.ToString();
        }

    }

    
}
