using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteraccionObjeto : MonoBehaviour
{
    [Header("Camara especial para el objeto a interaccionar")]
    public GameObject camaraObjetivo;
    [Header("Camara principal de la escena")]
    public GameObject camaraPrincipal;
    [Header("Panel que contiene el diálogo (texto como hijo) a mostrar")]
    public GameObject panelTextoPantalla;
    [Header("Texto/imagen con pincha para investigar (dentro de un gameobject)")]
    public GameObject texturaTecla;
    
    //Al instante de la colision con el jugador, muestra la imagen 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            texturaTecla.SetActive(true);
        }
    }
    //Mientras están en contacto, comprueba si el jugador pulsa la tecla E

    private void OnTriggerStay(Collider other)
    {

        if(other.gameObject.CompareTag("Player")){  
            
            if (Input.GetMouseButtonDown(0))
            {
                //Si pulsa la tecla, activamos la cámara específica para este objeto y desactivamos la principal
                camaraObjetivo.SetActive(true);
                camaraPrincipal.SetActive(false);
                //Hacemos visible el panel con el texto de diálogo
                panelTextoPantalla.SetActive(true);
            }
        }
    }

    //Cuando el jugador sale de la colisión del objeto reiniciamos la visiblidad de las cámaras, panel y imagen
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LimpiarInterficie();
        }
    }

    void LimpiarInterficie()
    {
        camaraObjetivo.SetActive(false);
        camaraPrincipal.SetActive(true);
        texturaTecla.SetActive(false);
        panelTextoPantalla.SetActive(false);
    }
}
