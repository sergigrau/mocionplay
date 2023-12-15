using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWall : MonoBehaviour
{
    [SerializeField] public PlayerMotion pleyer;

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            pleyer.iswall = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            pleyer.iswall = true;
        }
    }
}
