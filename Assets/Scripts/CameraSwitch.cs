using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera; // Cámara principal
    public Camera secondaryCamera; // Cámara secundaria
    public MonoBehaviour playerController; // Componente PlayerController a desactivar en la cámara secundaria
    private Camera activeCamera; // Cámara activa
    private Camera inactiveCamera; // Cámara inactiva

    void Start()
    {
        // Establecer la cámara principal como la cámara activa al inicio
        activeCamera = mainCamera;
        inactiveCamera = secondaryCamera;
        activeCamera.enabled = true;
        inactiveCamera.enabled = false;
    }

    void Update()
    {
        // Verificar si se presiona el botón derecho del mouse
        if (Input.GetMouseButtonDown(1))
        {
            // Cambiar las cámaras activa e inactiva al hacer clic derecho
            SwitchCameras();
        }
    }

    void SwitchCameras()
    {
        // Cambiar las cámaras activa e inactiva
        Camera temp = activeCamera;
        activeCamera = inactiveCamera;
        inactiveCamera = temp;

        // Desactivar la cámara inactiva y activar la cámara activa
        activeCamera.enabled = true;
        inactiveCamera.enabled = false;

        // Desactivar el componente PlayerController en la cámara secundaria si está definido
        if (inactiveCamera == secondaryCamera && playerController != null)
        {
            playerController.enabled = true;
        }
        // Activar el componente si la cámara secundaria no está activa y el componente está definido
        else if (inactiveCamera == mainCamera && playerController != null)
        {
            playerController.enabled = false;
        }
    }
}