using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teletransportador : MonoBehaviour
{
    // Nombre de la escena a la que se desea teletransportar
    public string Iglesia;

    // Este método se ejecutará cuando un objeto con un Rigidbody entre en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró en el trigger tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Cambia a la escena destino
            SceneManager.LoadScene(Iglesia);
        }
    }
}

