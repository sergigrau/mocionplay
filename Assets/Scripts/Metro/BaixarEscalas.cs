using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaixarEscalas : MonoBehaviour
{
    public GameObject No_Pujar;
    public GameObject Baixar_Escalas;
    // public GameObject Img_Avia_Borde;
    // public GameObject Script_Volver;
    // public GameObject Escena_Lladres;
    public GameObject Script_MourePlayer;
    
    [SerializeField] private Transform objetoAMover;
    [SerializeField] private Vector3 destino;

    public float velocidad = 1.0f;
    
    private BoxCollider boxCollider_Player;
    
    public static int dif_Obj = 0;
    public static int Inv_AjudarAvia;
    
    public static bool detenerEjecucion = false;
    
    public float rotationSpeedX = 0f; // Velocidad de rotación en el eje X
    public float rotationSpeedY = 0f;
    public float rotationSpeedZ = 0f;
    
    // public Mostrar_Img_Avia_Fase1 mostrar_img_avia_fase1_Script;
    
    
    void OnTriggerEnter(Collider other)
    {
        // Script_MourePlayer.SetActive(false);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        float rotationX = rotationSpeedX * Time.deltaTime;
        float rotationY = rotationSpeedY * Time.deltaTime;
        float rotationZ = rotationSpeedZ * Time.deltaTime;
                
        Player.transform.Rotate(rotationX, rotationY, rotationZ);
        
        dif_Obj = 0;
        boxCollider_Player = Player.GetComponent<BoxCollider>();
        
        // Verifica si el objeto que entró en el trigger tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            dif_Obj = 1;
            // Escena_Lladres.SetActive(true);
            // boxCollider_Player.enabled = false;
            Debug.Log("Empezando a bajar escaleras (Player).");
            StartCoroutine(Baixar());
            //ReanudarEjecucion();
        }
    }
    
    IEnumerator Baixar()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        // mostrar_img_avia_fase1_Script = GetComponent<Mostrar_Img_Avia_Fase1>();
        int Inv_Fase1 = Canviar_Fase.Inv_Fase1;
        Debug.Log("Inv_Fase1: " + Inv_Fase1);
        No_Pujar.SetActive(false);
        
        boxCollider_Player = Player.GetComponent<BoxCollider>();
        
        yield return StartCoroutine(BaixarCo(objetoAMover, objetoAMover.position, destino, velocidad));
        Debug.Log("BaixarEscalas StartCoroutine Tornar: Comença. ");
        
        IEnumerator BaixarCo(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
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
        boxCollider_Player.enabled = true;
        //boxCollider_Ladron1.enabled = true;
        Debug.Log("El objeto ha llegado al destino (ABAJO).");
        Inv_AjudarAvia = 1;
        No_Pujar.SetActive(true);
        if (Inv_Fase1 == 1)
        {
            GameObject.Find("Script_Mostrar_Img_Avia_Fase1").SendMessage("Començar");
            // GameObject.Find("Script_Mostrar_Img_Avia_Fase1").SendMessage("StartFadeIn");
            // mostrar_img_avia_fase1_Script.StartFadeIn();
            // Img_Avia_Borde.SetActive(true);
            // StartCoroutine(EsperarYReanudar());
        }
        
        // Script_MourePlayer.SetActive(true);
        // Debug.Log("Script_MourePlayer.");
        // Escena_Lladres.SetActive(false);
        // Reinicia la bandera y el progreso del movimiento
        
    }
    
    /*IEnumerator EsperarYReanudar()
    {
        Debug.Log("Esperando 5 segundos...");
        yield return new WaitForSeconds(5f);
        Debug.Log("Pasaron 5 segundos. Ejecutar comando aquí.");
        Img_Avia_Borde.SetActive(false);
    }*/
    
    public void DetenerEjecucion()
    {
        Baixar_Escalas.SetActive(false);
        Debug.Log("Script BaixarEscalas: 'Baixar_Escalas' desactivat.");
        // Establece la variable de control en verdadero para detener la ejecución del script
        detenerEjecucion = true;
        enabled = false;
    }
    
    public void ReanudarEjecucion()
    {
        Baixar_Escalas.SetActive(true);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        // Establece la variable de control en falso para permitir que el script continúe su ejecución
        detenerEjecucion = false;
        enabled = true;
        boxCollider_Player.enabled = true;
        //boxCollider_Ladron1.enabled = true;
        //Player.transform.position = Baixar_Escalas.GetComponent<Transform>().position;
        //origen = (-1.3f, 4.519f, 3.546f);
    }
    
}
