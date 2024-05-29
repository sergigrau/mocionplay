using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchLight : MonoBehaviour, IPointerClickHandler
{
    // Referencia a la luz que queremos controlar
    public Light LuzTecho;

    // Para saber si la luz está encendida o apagada
    private bool isLightOn;

    // Start se llama antes del primer frame update
    void Start()
    {
        if (LuzTecho != null)
        {
            // Inicialmente, comprobamos el estado de la luz
            isLightOn = LuzTecho.enabled;
        }
        else
        {
            Debug.LogError("LuzTecho no está asignada en el inspector.");
        }
    }

    // Implementación de la interfaz IPointerClickHandler
    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleLight();
    }

    // Función para encender/apagar la luz
    void ToggleLight()
    {
        if (LuzTecho != null)
        {
            isLightOn = !isLightOn;
            LuzTecho.enabled = isLightOn;
        }
    }
}
