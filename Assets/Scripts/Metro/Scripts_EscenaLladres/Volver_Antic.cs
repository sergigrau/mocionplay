using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volver_Antic : MonoBehaviour
{
    public GameObject No_Pujar;
    public GameObject Baixar_Escalas;
    public GameObject Script_Volver;
    
    public Vector3 destino;

    public float velocidad = 1.0f;

    private float progresoMovimiento = 0.0f;

    private bool mover = false;
    private bool canMove = true;
    
    private BoxCollider boxCollider_Player;
    private BoxCollider boxCollider_Ladron1;
    
    public string nombreEscena;

    public int cont = 0;

    public static int Inv_Volver;

    private void Start()
    {
        canMove = false;
        mover = true;
        cont = 0;
        Inv_Volver = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        
        if (!canMove)
        {
            if (mover)
            {
                // Debug.Log("Script Volver: Script activat.");
                Vector3 coordenadas = Player.transform.position;

                No_Pujar.SetActive(false);
                // Incrementa el progreso del movimiento en función del tiempo
                progresoMovimiento += velocidad * Time.deltaTime;

                // Asegúrate de que el progreso del movimiento esté entre 0 y 1
                progresoMovimiento = Mathf.Clamp01(progresoMovimiento);

                // Interpola entre las coordenadas de origen y destino basadas en el progreso del movimiento
                Player.transform.position = Vector3.Lerp(coordenadas, destino, progresoMovimiento);
                
                cont++;
                //Debug.Log("Contador: " + cont);
                
                // Si el progreso del movimiento es 1, el objeto ha alcanzado el destino
                if (progresoMovimiento == 1.0f)
                {
                    
                    Debug.Log("Script Volver: El objeto ha llegado al destino (ARRIBA).");
                    No_Pujar.SetActive(true);
                    
                    /*bool Inv_Detener = Moviment_BaixarEscalasMecanicas.detenerEjecucion;
                    if (Inv_Detener == true)
                    {
                        Inv_Detener = false;
                    }*/
                    Baixar_Escalas.SetActive(true);
                    // Reinicia la bandera y el progreso del movimiento
                    mover = false;
                    canMove = true;
                    progresoMovimiento = 0.0f;
                    Script_Volver.SetActive(false);
                    
                    Inv_Volver = 1;
                    SceneManager.LoadScene(nombreEscena);
                    DetenerEjecucion();

                    /*Moviment_BaixarEscalasMecanicas script_BaixarEscalas = Baixar_Escalas.GetComponent<Moviment_BaixarEscalasMecanicas>();
                    if (script_BaixarEscalas != null)
                    {
                        script_BaixarEscalas.ReanudarEjecucion();
                        Debug.Log("Script Parar_Lladres: Script activat.");
                    }*/
                    //Invoke("ActivarScript",3f);
                }
            }
        }
    }
    public void Tornar()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject Ladron1 = GameObject.FindGameObjectWithTag("Ladron1");
        
        boxCollider_Player = Player.GetComponent<BoxCollider>();
        boxCollider_Ladron1 = Ladron1.GetComponent<BoxCollider>();
        
        boxCollider_Player.enabled = true;
        boxCollider_Ladron1.enabled = true;
        Update();
    }
    
    public void DetenerEjecucion()
    {
        // Establece la variable de control en verdadero para detener la ejecución del script
        enabled = false;
    }
    
    public void ReanudarEjecucion()
    {
        enabled = true;
    }
    
    /*public void ActivarScript()
    {
        // Obtén el componente del script MiScript adjunto al GameObject
        Moviment_BaixarEscalasMecanicas script_BaixarEscalas = Baixar_Escalas.GetComponent<Moviment_BaixarEscalasMecanicas>();

        // Si el componente del script no es nulo, llama al método para activar el script
        if (script_BaixarEscalas != null)
        {
            script_BaixarEscalas.ReanudarEjecucion();
            Debug.Log("Script Volver: Script activat.");
        }
    }*/
}
