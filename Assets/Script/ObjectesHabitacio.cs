using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectesHabitacio : MonoBehaviour{
public float distanciaMaxima = 2f; // La distancia máxima a la que el jugador puede estar para que el objeto desaparezca
public String seguentObjecte; // El siguiente objeto
public TextMeshProUGUI text;
public ParticleSystem partSys;
public Image tickBox;

void Start()
{
    // Asegúrate de que el sistema de partículas esté desactivado al inicio
    if (partSys != null)
    {
        partSys.Stop();
    }
}

void Update()
{
    // Verificar si el jugador está cerca del objeto
    GameObject jugador = GameObject.FindWithTag("Player");
    if (jugador != null)
    {
        float distancia = Vector3.Distance(transform.position, jugador.transform.position);
        if (distancia <= distanciaMaxima)
        {
            // Verificar si el jugador presionó la tecla "E"
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Activar el sistema de partículas
                if (partSys != null)
                {
                    partSys.Play();
                }
                    
                // Cambiar el texto
                if (text != null)
                {
                    text.SetText(seguentObjecte);
                }

                // Desactivar el objeto
                gameObject.SetActive(false);
            }
        }
    }
}
}
