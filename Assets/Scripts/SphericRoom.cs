using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericRoom : MonoBehaviour
{
    [SerializeField] private GameObject epicenter;
    [SerializeField] private GameObject boundary;
    [SerializeField] private float[] doorsAt;
    [SerializeField] private float[] doorsSizes;

    [SerializeField] private PlayerMotion pl;

    // Update is called once per frame
    void Update()
    {
        if (pl._input.magnitude > 0)
        {
            epicenter.transform.LookAt(pl.transform);
        }
    }

    private void Start()
    {
        // boundary.transform.position = new Vector3(0, 0, 1);
    }
}
