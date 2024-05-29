using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float zoomedOrthoSize = 2f; // Tamaño ortográfico para el zoom
    public float transitionSpeed = 2f; // Velocidad de la transición de la cámara
    public LayerMask obstacleMask; // Máscara de capas para detectar obstáculos

    private Vector3 initialPosition;
    private float initialOrthoSize;
    private Vector3 defaultCameraPosition;

    void Start()
    {
        // Guardar los parámetros iniciales de la cámara
        initialPosition = virtualCamera.transform.position;
        initialOrthoSize = virtualCamera.m_Lens.OrthographicSize;
        defaultCameraPosition = initialPosition;
    }

    void Update()
    {
        // Detectar clic del ratón
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Verificar si el objeto tiene la etiqueta "Producto"
                if (hit.transform.CompareTag("Producto"))
                {
                    // Calcular la posición objetivo y el tamaño ortográfico
                    Bounds bounds = hit.collider.bounds;
                    Vector3 targetPosition = bounds.center;
                    float targetOrthoSize = CalculateOrthographicSize(bounds.size);

                    // Verificar si estamos cerca de la posición objetivo, si es así, desactivar el zoom
                    if (Vector3.Distance(virtualCamera.transform.position, targetPosition) < 0.1f)
                    {
                        StartCoroutine(TransitionToTarget(defaultCameraPosition, initialOrthoSize));
                    }
                    else
                    {
                        // Si no estamos cerca, activar el zoom
                        StartCoroutine(TransitionToTarget(targetPosition, targetOrthoSize));
                    }
                }
            }
        }
    }

    // Calcula el tamaño ortográfico necesario para hacer zoom en el objeto basado en su tamaño
    float CalculateOrthographicSize(Vector3 size)
    {
        float maxDimension = Mathf.Max(size.x, size.y);
        return zoomedOrthoSize * (maxDimension / 4f); // Ajustamos el factor de escala
    }

    // Realiza una transición suave de la cámara hacia la posición y tamaño ortográfico objetivo
    IEnumerator TransitionToTarget(Vector3 targetPosition, float targetOrthoSize)
    {
        Vector3 startPosition = virtualCamera.transform.position;
        float startOrthoSize = virtualCamera.m_Lens.OrthographicSize;

        // Verificar si hay obstáculos entre la posición actual y la posición objetivo
        RaycastHit obstacleHit;
        if (Physics.Linecast(startPosition, targetPosition, out obstacleHit, obstacleMask))
        {
            // Si hay un obstáculo, ajustar la posición objetivo para que esté más cerca del punto de impacto
            targetPosition = obstacleHit.point - (targetPosition - obstacleHit.point).normalized * 0.1f;
        }

        float elapsedTime = 0f;
        while (elapsedTime < transitionSpeed)
        {
            float t = elapsedTime / transitionSpeed;
            virtualCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startOrthoSize, targetOrthoSize, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Esperar al siguiente frame
        }
        virtualCamera.transform.position = targetPosition;
        virtualCamera.m_Lens.OrthographicSize = targetOrthoSize;
    }
}
