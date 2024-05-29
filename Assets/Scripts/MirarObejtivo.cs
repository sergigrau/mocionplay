using System;
using UnityEngine;

public class MirarObejtivo : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.LookAt(target);
    }
}