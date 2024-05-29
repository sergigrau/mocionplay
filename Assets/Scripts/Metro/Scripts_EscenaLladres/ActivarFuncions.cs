using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarFuncions : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject.Find("Ladron1").SendMessage("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
