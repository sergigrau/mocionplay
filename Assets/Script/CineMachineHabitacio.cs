using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineHabitacio : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Puedes ajustar la etiqueta según tus necesidades
        {
            if (virtualCamera != null)
            {
                virtualCamera.gameObject.SetActive(true);
                virtualCamera.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        throw new NotImplementedException();
    }
}
