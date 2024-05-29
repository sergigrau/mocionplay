using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float zoomedOrthoSize = 2f; // Tama�o ortogr�fico para el zoom
    public float transitionSpeed = 2f; // Velocidad de la transici�n de la c�mara
    public LayerMask obstacleMask; // M�scara de capas para detectar obst�culos

    private Vector3 initialPosition;
    private float initialOrthoSize;
    private Vector3 defaultCameraPosition;

    void Start()
    {
        // Guardar los par�metros iniciales de la c�mara
        initialPosition = virtualCamera.transform.position;
        initialOrthoSize = virtualCamera.m_Lens.OrthographicSize;
        defaultCameraPosition = initialPosition;
    }

    void Update()
    {
        // Detectar clic del rat�n
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Verificar si el objeto tiene la etiqueta "Producto"
                if (hit.transform.CompareTag("Producto"))
                {
                    // Calcular la posici�n objetivo y el tama�o ortogr�fico
                    Bounds bounds = hit.collider.bounds;
                    Vector3 targetPosition = bounds.center;
                    float targetOrthoSize = CalculateOrthographicSize(bounds.size);

                    // Verificar si estamos cerca de la posici�n objetivo, si es as�, desactivar el zoom
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

    // Calcula el tama�o ortogr�fico necesario para hacer zoom en el objeto basado en su tama�o
    float CalculateOrthographicSize(Vector3 size)
    {
        float maxDimension = Mathf.Max(size.x, size.y);
        return zoomedOrthoSize * (maxDimension / 4f); // Ajustamos el factor de escala
    }

    // Realiza una transici�n suave de la c�mara hacia la posici�n y tama�o ortogr�fico objetivo
    IEnumerator TransitionToTarget(Vector3 targetPosition, float targetOrthoSize)
    {
        Vector3 startPosition = virtualCamera.transform.position;
        float startOrthoSize = virtualCamera.m_Lens.OrthographicSize;

        // Verificar si hay obst�culos entre la posici�n actual y la posici�n objetivo
        RaycastHit obstacleHit;
        if (Physics.Linecast(startPosition, targetPosition, out obstacleHit, obstacleMask))
        {
            // Si hay un obst�culo, ajustar la posici�n objetivo para que est� m�s cerca del punto de impacto
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
