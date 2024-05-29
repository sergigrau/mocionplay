using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaixarEscalas_Robatori : MonoBehaviour
{
    public GameObject No_Pujar;
    public GameObject Baixar_Escalas;
    public GameObject Baixar_Escalas_Robatori;
    // public GameObject Script_Volver;
    public GameObject Escena_Lladres;
    // public GameObject Script_MourePlayer;
    
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
    
    
    void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Ladron1").SendMessage("Moure");
        // Script_MourePlayer.SetActive(false);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        float rotationX = rotationSpeedX * Time.deltaTime;
        float rotationY = rotationSpeedY * Time.deltaTime;
        float rotationZ = rotationSpeedZ * Time.deltaTime;
                
        // Player.transform.Rotate(rotationX, rotationY, rotationZ);
        
        dif_Obj = 0;
        boxCollider_Player = Player.GetComponent<BoxCollider>();
        
        // Verifica si el objeto que entró en el trigger tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EsperarYReanudar());
            dif_Obj = 1;
            
            // boxCollider_Player.enabled = false;
            objetoAMover.transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Empezando a bajar escaleras (Player).");
            StartCoroutine(Baixar());
            //ReanudarEjecucion();
        }
    }
    
    IEnumerator EsperarYReanudar()
    {
        Debug.Log("Esperando 3 segundos...");
        yield return new WaitForSeconds(3f);
        Debug.Log("Pasaron 3 segundos. Ejecutar comando aquí.");
        Escena_Lladres.SetActive(true);
        PausarTiempo();
    }
    
    void PausarTiempo()
    {
        Time.timeScale = 0f;
        Debug.Log("Tiempo pausado");
    }
    
    IEnumerator Baixar()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        objetoAMover.transform.rotation = Quaternion.Euler(0, 0, 0);
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
        GameObject.Find("Script_MourePlayer").SendMessage("Anar_Avia");
        boxCollider_Player.enabled = true;
        //boxCollider_Ladron1.enabled = true;
        Debug.Log("El objeto ha llegado al destino (ABAJO).");
        Inv_AjudarAvia = 1;
        No_Pujar.SetActive(true);
        Escena_Lladres.SetActive(false);
        Baixar_Escalas.SetActive(true);
        // Reinicia la bandera y el progreso del movimiento
        
    }
    
    public void DetenerEjecucion()
    {
        Baixar_Escalas_Robatori.SetActive(false);
        Debug.Log("Script BaixarEscalas: 'Baixar_Escalas' desactivat.");
        // Establece la variable de control en verdadero para detener la ejecución del script
        detenerEjecucion = true;
        enabled = false;
    }
    
    public void ReanudarEjecucion()
    {
        Baixar_Escalas_Robatori.SetActive(true);
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
