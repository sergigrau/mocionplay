using UnityEngine;
using System.Collections;

public class Moviment : MonoBehaviour
{
    public float velocitat = 10.0F;
    public float velocitatRotacio = 100.0F;

    void Start()
    {
    }

    void Update()
    {
        float traslacio = Input.GetAxis("Vertical") * velocitat;
        float rotacio = Input.GetAxis("Horizontal") * velocitatRotacio;
        traslacio *= Time.deltaTime;
        rotacio *= Time.deltaTime;
        transform.Translate(0, 0, traslacio);
        transform.Rotate(0, rotacio, 0);
    }
}
