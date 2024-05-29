using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerLago : MonoBehaviour
{
    //public Transform goal;
    private NavMeshAgent agent;
    public Transform[] puntsMoviment;
    int indexPuntsMoviment;
    Vector3 destinacio;
    
       
    void Start () {
         agent = GetComponent<NavMeshAgent>();
        ActualitzarDestinacio();
    }

     void Update()
    {
        if(Vector3.Distance(transform.position, destinacio) < 1f)
        {
            IterarIndexPuntsMoviment();
            ActualitzarDestinacio();
        }
    }

    void ActualitzarDestinacio()
    {
        destinacio = puntsMoviment[indexPuntsMoviment].position;
        agent.SetDestination(destinacio);
    }
    void IterarIndexPuntsMoviment()
    {
        indexPuntsMoviment++;
        if(indexPuntsMoviment==puntsMoviment.Length)
        {
            indexPuntsMoviment = 0;
        }
    }
}
