using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Mostrar_Img_Avia_Fase1 : MonoBehaviour
{
    public float fadeDuration = 2.0f; // Duración de la transición
    public RawImage Img_Avia_Borde; // Referencia a la imagen que deseas controlar

    public void Començar()
    {
        if (Img_Avia_Borde == null)
        {
            Debug.LogError("No se ha asignado una imagen objetivo para controlar la transparencia. Asigna la imagen en el Inspector.");
            enabled = false; // Desactiva el script para evitar errores
            return;
        }

        // Desactiva la imagen al inicio
        Img_Avia_Borde.gameObject.SetActive(false);

        // Comienza la Coroutine para la transición de opacidad
        StartCoroutine(EsperarYReanudar());
        
    }

    IEnumerator FadeIn()
    {
        // Activa la imagen
        Img_Avia_Borde.gameObject.SetActive(true);

        // Inicializa el color de la imagen con transparencia cero
        Color targetColor = Img_Avia_Borde.color;
        targetColor.a = 0;
        Img_Avia_Borde.color = targetColor;

        // Transición de opacidad
        float timer = 0;
        while (timer < fadeDuration)
        {
            // Incrementa el temporizador
            timer += Time.deltaTime;

            // Calcula el progreso de la transición
            float progress = timer / fadeDuration;

            // Actualiza la transparencia de la imagen
            targetColor.a = Mathf.Lerp(0, 1, progress);
            Img_Avia_Borde.color = targetColor;

            // Espera hasta el siguiente frame
            yield return null;
        }
    }
    
    IEnumerator EsperarYReanudar()
    {
        StartCoroutine(FadeIn());
        Debug.Log("Esperando 3 segundos...");
        yield return new WaitForSeconds(3f);
        Debug.Log("Pasaron 3 segundos.");
        // Img_Avia_Borde.gameObject.SetActive(false);
        StartCoroutine(FadeOut());
    }
    
    IEnumerator FadeOut()
    {
        // Inicializa el color de la imagen con transparencia máxima
        Color targetColor = Img_Avia_Borde.color;
        targetColor.a = 1;
        Img_Avia_Borde.color = targetColor;

        // Transición de opacidad
        float timer = 0;
        while (timer < fadeDuration)
        {
            // Incrementa el temporizador
            timer += Time.deltaTime;

            // Calcula el progreso de la transición
            float progress = timer / fadeDuration;

            // Actualiza la transparencia de la imagen
            targetColor.a = Mathf.Lerp(1, 0, progress);
            Img_Avia_Borde.color = targetColor;

            // Espera hasta el siguiente frame
            yield return null;
        }

        // Desactiva la imagen después de la transición
        Img_Avia_Borde.gameObject.SetActive(false);
    }
    
}

