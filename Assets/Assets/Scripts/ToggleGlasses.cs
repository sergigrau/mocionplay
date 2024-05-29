using UnityEngine;

public class ToggleGlasses : MonoBehaviour
{
    GameObject[] glasses;

    private void Start()
    {
        // Call FindGameObjectsWithTag in Start method
        glasses = GameObject.FindGameObjectsWithTag("Gafas");
        
        // Desactivamos todas las gafas al inicio del juego
        DisableAllGlasses();
    }

    private void DisableAllGlasses()
    {
        // Obtenemos todos los objetos con el tag "Gafas"

        // Desactivamos cada objeto de gafas
        foreach (GameObject glassesObj in glasses)
        {
            glassesObj.SetActive(false);
        }
    }

    public void ToggleGlassesState()
    {
        // Toggle the state of each glasses object
        foreach (GameObject glassesObj in glasses)
        {
            // If glasses object is active, deactivate it. Otherwise, activate it.
            glassesObj.SetActive(!glassesObj.activeSelf);
        }
    }
}