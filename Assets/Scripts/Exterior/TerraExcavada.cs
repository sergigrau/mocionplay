using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraExcavada : MonoBehaviour
{
    public Vector3 posicioFinal;
    public float velocitatMov = 1.0f;
    public GameObject CaixaClick;
    private bool movimentStart = false;
    
    void Update()
    {
        if (!movimentStart && GlobalVariables.Terra_Esta_Excavada)
        {
            StartCoroutine(MoureTerra());
            movimentStart = true;
        }
    }

    IEnumerator MoureTerra()
    {
        Vector3 posicioInicial = transform.position;
        float distanciaTotal = Vector3.Distance(posicioInicial, posicioFinal);
        float distanciaActual = 0f;

        while (distanciaActual < distanciaTotal)
        {
            Debug.Log("Excavant...");
            float fracDistancia = distanciaActual / distanciaTotal;
            transform.position = Vector3.Lerp(posicioInicial, posicioFinal, fracDistancia);
            distanciaActual += velocitatMov * Time.deltaTime;
            
            yield return null;
        }
        Debug.Log("Acabat d'excavar");
        CaixaClick.SetActive(true);
    }
}