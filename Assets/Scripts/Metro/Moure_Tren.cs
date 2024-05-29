using UnityEngine;
using System.Collections;

public class Moure_Tren : MonoBehaviour
{
    public GameObject tren;
    public Vector3 origen;
    public Vector3 destino;
    public float duracionMovimiento = 2.0f; // Duración del movimiento del tren en segundos
    public float intervalo = 10.0f; // Intervalo de tiempo entre movimientos en segundos

    private bool enMovimiento = false;
    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = intervalo;
        StartCoroutine(ContadorTiempo());
    }

    void Update()
    {
        if (!enMovimiento && tiempoRestante <= 0)
        {
            ComenzarMovimiento();
        }
    }

    IEnumerator ContadorTiempo()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalo);
            tiempoRestante -= intervalo; // Restar el intervalo de tiempo al tiempo restante
        }
    }

    void ComenzarMovimiento()
    {
        MoverTren();
    }

    void MoverTren()
    {
        StartCoroutine(MoverTrenCoroutine());
    }

    IEnumerator MoverTrenCoroutine()
    {
        enMovimiento = true;
        tren.SetActive(true);

        float tiempoPasado = 0f;
        Vector3 posInicial = origen;
        Vector3 posFinal = destino;

        while (tiempoPasado < duracionMovimiento)
        {
            float t = tiempoPasado / duracionMovimiento;
            tren.transform.position = Vector3.Lerp(posInicial, posFinal, t);
            tiempoPasado += Time.deltaTime;
            yield return null;
        }

        tren.SetActive(false);
        tren.transform.position = origen;
        enMovimiento = false;

        tiempoRestante = intervalo; // Reiniciar el temporizador
    }
}