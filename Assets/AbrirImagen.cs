using UnityEngine;

public class AbrirImagen : MonoBehaviour
{
    public GameObject imagenCompleta; // Referencia al objeto de la imagen completa

    // Este método se llama cuando otro collider entra en contacto con el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en contacto tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Activa el objeto de la imagen completa para mostrarlo en pantalla completa
            imagenCompleta.SetActive(true);
        }
    }
}
