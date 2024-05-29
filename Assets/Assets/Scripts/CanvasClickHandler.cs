using UnityEngine;

public class CanvasClickHandler : MonoBehaviour
{
    public Camera cameraToUse; // Referencia a la cámara a utilizar

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Botón izquierdo del mouse clickeado
        {
            CheckCanvasClick(cameraToUse); // Llama al método para verificar el clic en el lienzo
        }
    }

    private void CheckCanvasClick(Camera camera)
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition); // Utiliza la cámara especificada en lugar de Camera.main

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Has clickeado en el lienzo!");
            }
            else
            {
                Debug.Log("FFFFFFFFFFFFF");
            }
        }
    }
}