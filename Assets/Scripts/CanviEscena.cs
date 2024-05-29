using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanviEscena : MonoBehaviour
{
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
        switch (gameObject.name)
        {
            case "PortaDavidExterior":
                SceneManager.LoadScene("Scenes/DespachoDavid");
                //ManagerPrincipal.Instancia.PosicioInicial = GameObject.Find("AparicionExterior").transform.position;
                break;
            case "PortaDavidInterior":
                SceneManager.LoadScene("Scenes/SampleScene");
                //ManagerPrincipal.Instancia.PosicioInicial = GameObject.Find("AparicionDespachoD").transform.position;
                break;
        }
    }
}
