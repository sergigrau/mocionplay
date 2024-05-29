using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuidoLibreria : MonoBehaviour
{
    public AudioClip soundEffect; // Variable para almacenar el sonido
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null && soundEffect != null)
        {
            audioSource.clip = soundEffect;
        }
        else
        {
            Debug.LogError("AudioSource o AudioClip no asignados en el Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null && soundEffect != null)
        {
            // Reproduce el sonido
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource o AudioClip no configurados correctamente.");
        }
    }
}
