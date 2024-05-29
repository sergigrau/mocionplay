using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mision : MonoBehaviour
{
    // Lista para almacenar las esferas
    public List<GameObject> spheres;
    // Referencia al canvas
    public CanvasRenderer targetCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // Opcional: Inicializa la lista de esferas aquí si no está asignada desde el editor
        if (spheres == null)
        {
            spheres = new List<GameObject>();
        }

        // Desactiva el canvas al inicio
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si todas las esferas están desactivadas
        bool allSpheresDeactivated = true;
        foreach (GameObject sphere in spheres)
        {
            if (sphere.activeSelf)
            {
                allSpheresDeactivated = false;
                break;
            }
        }

        // Si todas las esferas están desactivadas, activar el canvas
        if (allSpheresDeactivated && targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(true);
        }
    }
}