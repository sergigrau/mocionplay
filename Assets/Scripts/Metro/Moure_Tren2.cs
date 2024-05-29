using System.Collections;
using UnityEngine;

public class Moure_Tren2 : MonoBehaviour
{
    [SerializeField] private Transform objetoAMover;
    [SerializeField] private Vector3 destino;
    [SerializeField] private Vector3 origen;

    public GameObject Tren;

    // Cambia este valor al número de segundos que desees (180 segundos = 3 minutos)
    public float tiempoLimiteEnSegundos = 10f;
    private bool alcanzadoLimite = false;
    private float tiempoTranscurrido = 0f;

    // Función que se ejecuta cuando se alcanza el límite de tiempo
    /*private void FuncionAlcanzarLimiteTiempo()
    {
        StartCoroutine(Moure());
        // Aquí puedes colocar el código que deseas ejecutar cuando se alcanza el límite de tiempo
        Debug.Log("Se alcanzó el límite de tiempo de " + tiempoLimiteEnSegundos + " segundos.");

        // Reinicia el cronómetro
        alcanzadoLimite = false;
        tiempoTranscurrido = 0f;
    }*/
    
    IEnumerator EsperarYReanudar()
    {
        Debug.Log("Esperando 2 segundos...");
        yield return new WaitForSeconds(tiempoLimiteEnSegundos);
        Debug.Log("Pasaron 2 segundos. Ejecutar comando aquí.");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EsperarYReanudar());
        // Si aún no se ha alcanzado el límite de tiempo
        StartCoroutine(Moure());
    }

    IEnumerator Moure()
    {
        Tren.SetActive(true);
        yield return StartCoroutine(MoureTren(objetoAMover, origen, destino, 1.0f));
        Debug.Log("Moure_Tren StartCoroutine1 MoureTren: Comença. ");

        IEnumerator MoureTren(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
        {
            var i = 0.0f;
            var rati = 1.0f / temps;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rati;
                transformObjecte.position = Vector3.Lerp(posInicial, posFinal, i);
                yield return null;
            }
        }
        Tren.SetActive(false);
        Tren.transform.position = origen;
        yield return StartCoroutine(EsperarYReanudar());
    }
}
