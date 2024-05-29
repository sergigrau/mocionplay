using UnityEngine;
using System.Collections;

public class CambioDeIluminacion : MonoBehaviour
{
    private Light luzOriginal;
    private Color colorFondoOriginal;
    private GameObject[] objetosConTag;
    public float tiempoDeEspera = 120f;
    public float intensidadOscuridad = 0.3f;
    public Color colorFondoOscuridad = Color.black;
    private bool triggerActivado = false; // Flag para controlar si el trigger ha sido activado

    void Start()
    {
        luzOriginal = RenderSettings.sun;
        colorFondoOriginal = Camera.main.backgroundColor;
        objetosConTag = GameObject.FindGameObjectsWithTag("FASE6CAMBIO");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggerActivado) // Verificar si el trigger no ha sido activado
        {
            Debug.Log("Entró en el trigger");
            triggerActivado = true; // Establecer el flag como activado
            CambiarIluminacionYOcultarObjetos();
            StartCoroutine(EsperarYRestaurar());
            GetComponent<Collider>().enabled = false; // Desactivar el collider del objeto para que el trigger no se active de nuevo
        }
    }

    void CambiarIluminacionYOcultarObjetos()
    {
        foreach (GameObject obj in objetosConTag)
        {
            obj.SetActive(false);
        }
        luzOriginal.gameObject.SetActive(false);
        RenderSettings.ambientIntensity *= intensidadOscuridad;
        Camera.main.backgroundColor = colorFondoOscuridad;
    }

    IEnumerator EsperarYRestaurar()
    {
        yield return new WaitForSeconds(tiempoDeEspera);
        luzOriginal.gameObject.SetActive(true);
        RenderSettings.ambientIntensity /= intensidadOscuridad;
        Camera.main.backgroundColor = colorFondoOriginal;
        foreach (GameObject obj in objetosConTag)
        {
            obj.SetActive(true);
        }
    }
}