using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoureLladre : MonoBehaviour
{
    [SerializeField] private Vector3 destino1;
    [SerializeField] private Vector3 destino2;
    [SerializeField] private Vector3 origenSubir;
    [SerializeField] private Vector3 salirMetro;
    
    private Animator animator;

    IEnumerator Moure()
    {
        animator = GetComponent<Animator>();
        var puntA = transform.position;
        //while (true)
        //{
        StartCoroutine(EsperarYReanudar());
        transform.rotation = Quaternion.Euler(0, 180, 0);
        yield return StartCoroutine(MoureObjecte(transform, puntA, destino1, 1.0f));
        Debug.Log("MoureLladre StartCoroutine1 MoureObjecte: Comença. ");
        transform.rotation = Quaternion.Euler(0, 180, 0);
        animator.SetTrigger("idle");
        yield return StartCoroutine(MoureObjecte(transform, destino1, destino2, 0.5f));
        Debug.Log("MoureLladre StartCoroutine2 MoureObjecte: Comença. ");
        /*while (true)
        {
            int Inv_Lladre1 = Moviment_PujarEscalasMecanicas.Inv_Lladre1;
            Debug.LogWarning("MoureLladre Inv_Lladre1: " + Inv_Lladre1);
            if (Inv_Lladre1 == 1)
            {
                break;
            }
        }*/
        var arribaEscaleras = transform.position;
            
            
        //}

        IEnumerator EsperarYReanudar()
        {
            Debug.Log("Esperando 2 segundos...");
            yield return new WaitForSeconds(2f);
            Debug.Log("Pasaron 2 segundos. Ejecutar comando aquí.");
        }
        
        IEnumerator MoureObjecte(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
        {
            animator.SetTrigger("walk");
            var i = 0.0f;
            var rati = 1.0f / temps;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rati;
                transformObjecte.position = Vector3.Lerp(posInicial, posFinal, i);
                yield return null;
            }
        }
        
        
    }
    
    IEnumerator Sortir_Metro()
    {
        yield return StartCoroutine(SortirMetroLladre1(transform, origenSubir, salirMetro, 0.5f));
        Debug.Log("MoureLladre StartCoroutine3 MoureObjecte: Comença. ");
        IEnumerator SortirMetroLladre1(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
        {
            animator.SetTrigger("walk");
            var i = 0.0f;
            var rati = 1.0f / temps;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rati;
                transformObjecte.position = Vector3.Lerp(posInicial, posFinal, i);
                yield return null;
            }
        }
    }
    
    
    
    /*
    // Define las coordenadas de origen y destino
    public Vector3 origen;
    public Vector3 destino;

    // Velocidad de movimiento del objeto
    public float velocidad = 1.0f;

    // Variable para rastrear el progreso del movimiento
    private float progresoMovimiento = 0.0f;

    // Bandera para verificar si el objeto debe moverse
    private bool mover = false;

    void Update()
    {
        // Incrementa el progreso del movimiento en función del tiempo
        progresoMovimiento += velocidad * Time.deltaTime;

        // Asegúrate de que el progreso del movimiento esté entre 0 y 1
        progresoMovimiento = Mathf.Clamp01(progresoMovimiento);

        // Interpola entre las coordenadas de origen y destino basadas en el progreso del movimiento
        transform.position = Vector3.Lerp(origen, destino, progresoMovimiento);

        // Si el progreso del movimiento es 1, el objeto ha alcanzado el destino
        if (progresoMovimiento == 1.0f)
        {
            Debug.Log("Ladron ha llegado al destino.");
            // Reinicia la bandera y el progreso del movimiento
            progresoMovimiento = 0.0f;
            // Aquí puedes agregar cualquier código adicional que desees ejecutar al llegar al destino
        }
    }

    public void Moure()
    {
        Update();
    }
    */
}