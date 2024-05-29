using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

/**
* Classe que implementa el moviment lliure d'un objecte
* i la instàciació'objectes
* Jesuïtes El Clot
 * sergi.grau.@fje.edu
* 1.0 28.10.2023
*/
public class MovimentLliure : MonoBehaviour
{
    [SerializeField] float velocitat = 3f; //velocitat de

    private float _i = 0;
    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Input.GetAxis("Vertical") * velocitat);
        transform.Translate(Vector3.left * Time.deltaTime * Input.GetAxis("Horizontal") * velocitat);
     
    }

    
}