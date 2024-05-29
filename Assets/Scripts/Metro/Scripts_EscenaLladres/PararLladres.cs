using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PararLladres : MonoBehaviour
{
    public GameObject Baixar_Escalas_Robatori;
    public GameObject Baixar_Escalas;
    // public GameObject Script_Volver;
    public GameObject Escena_Lladres;
    public GameObject Escena_Parar_Futur;
    public GameObject Player_Carlos;
    
    [SerializeField] private Transform objetoAMover;
    [SerializeField] private Vector3 destino;

    public float velocidad = 1.0f;
    
    public string nombreEscena;
    
    private BoxCollider boxCollider_Player;
    
    public static int Inv_Parar;
    
    private Animator animator;

    
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        animator = objetoAMover.GetComponent<Animator>();
    }

    void Update()
    {
        int Inv_Lladre1 = PujarEscalasLladre1.Inv_Lladre1;
        //Debug.Log("Inv_Lladre1: " + Inv_Lladre1);
        //Debug.Log("Inv_Parar: " + Inv_Parar);
        if (Inv_Lladre1 == 1 && Inv_Parar == 1)
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
    
    IEnumerator Canvi_Direccio()
    {
        // ReanudarTiempo();
        Inv_Parar = 1;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        boxCollider_Player = Player.GetComponent<BoxCollider>();
        
        Escena_Parar_Futur.SetActive(false);
        Escena_Lladres.SetActive(false);
        Debug.Log("Boto \"Parar Lladres\"premut.");

        BaixarEscalas_Robatori script_BaixarEscalas_Robatori = Baixar_Escalas_Robatori.GetComponent<BaixarEscalas_Robatori>();
        
        if (script_BaixarEscalas_Robatori != null)
        {
            script_BaixarEscalas_Robatori.DetenerEjecucion();
            Debug.Log("Script Parar_Lladres: Script 'Baixar_Escalas' desactivat.");
        }
        
        var puntA = transform.position;
        
        Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        yield return StartCoroutine(Tornar(objetoAMover, objetoAMover.position, destino, velocidad));
        animator.SetTrigger("idle");
        Debug.Log("PararLladres StartCoroutine1 Tornar: Comença. ");
        
        boxCollider_Player.enabled = true;
        
        IEnumerator Tornar(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
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
        
        MovimentCarlos_SinCamera script_Moviment = Player_Carlos.GetComponent<MovimentCarlos_SinCamera>();
        
        Baixar_Escalas_Robatori.SetActive(false);
        // Baixar_Escalas.SetActive(true);

        if (script_Moviment != null)
        {
            script_Moviment.enabled = false;
        }
        else
        {
            Debug.LogWarning("El script 'MovimentCarlos_SinCamera' no se encontró en el objeto especificado.");
        }
        //SceneManager.LoadScene(nombreEscena);
        
        
    }
    
    public void ReanudarTiempo()
    {
        Time.timeScale = 1f;
        Debug.Log("Tiempo reanudado");
        StartCoroutine(Canvi_Direccio());
    }
    
}


/*Script_Volver.SetActive(true);
    Volver_Antic script_Volver = Script_Volver.GetComponent<Volver_Antic>();
    if (script_Volver != null)
    {
        Baixar_Escalas.SetActive(false);
        script_Volver.ReanudarEjecucion();
        script_Volver.Tornar();
        Debug.Log("Script Volver: Script activat.");
    }
    if (script_BaixarEscalas != null)
    {
        script_BaixarEscalas.DetenerEjecucion();
        Debug.Log("Script Parar_Lladres: Script desactivat.");
    }*/
    
/*void ActivarScript()
{
    // Obtén el componente del script MiScript adjunto al GameObject
    Moviment_BaixarEscalasMecanicas script_BaixarEscalas = Baixar_Escalas.GetComponent<Moviment_BaixarEscalasMecanicas>();

    // Si el componente del script no es nulo, llama al método para activar el script
    if (script_BaixarEscalas != null)
    {
        script_BaixarEscalas.ActivarScript();
        Debug.Log("Script Parar_Lladres: Script activat.");
    }
}*/