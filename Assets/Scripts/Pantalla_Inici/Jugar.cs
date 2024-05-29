using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string nombreEscena;

    // Método para cambiar la escena al hacer clic en el botón
    public void CambiarAEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
