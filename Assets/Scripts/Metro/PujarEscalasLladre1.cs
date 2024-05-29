using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PujarEscalasLladre1 : MonoBehaviour
{
    public GameObject No_Baixar;
    // public GameObject No_Pujar;
    //public GameObject Baixar_Escalas;
    public GameObject Pujar_Escalas_Lladre;
    
    // Define las coordenadas de origen y destino
    [SerializeField] private Transform objetoAMover;
    [SerializeField] private Vector3 destino;

    // Velocidad de movimiento del objeto
    public float velocidad = 1.0f;

    public static int dif_Obj = 0;
    
    public float rotationSpeedX = 0f; // Velocidad de rotación en el eje X
    public float rotationSpeedY = 0f;
    public float rotationSpeedZ = 0f;
    
    //private BoxCollider boxCollider_Player;
    private BoxCollider boxCollider_Ladron1;
    
    public static int Inv_Lladre1;
    
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Inv_Lladre1 = 0;
        //GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject Ladron1 = GameObject.FindGameObjectWithTag("Ladron1");
        
        // Ladron1.transform.rotation = Quaternion.Euler(0, 180, 0);
        
        dif_Obj = 0;
        boxCollider_Ladron1 = Ladron1.GetComponent<BoxCollider>();
        
        float rotationX = rotationSpeedX * Time.deltaTime;
        float rotationY = rotationSpeedY * Time.deltaTime;
        float rotationZ = rotationSpeedZ * Time.deltaTime;
                
        // Ladron1.transform.Rotate(rotationX, rotationY, rotationZ);
        
        if (other.CompareTag("Ladron1"))
        {
            dif_Obj = 1;
            boxCollider_Ladron1.enabled = false;
            StartCoroutine(PujarLladre1());
        }
    }
    
    IEnumerator PujarLladre1()
    {
        No_Baixar.SetActive(false);
        GameObject Ladron1 = GameObject.FindGameObjectWithTag("Ladron1");
        boxCollider_Ladron1 = Ladron1.GetComponent<BoxCollider>();
        
        yield return StartCoroutine(PujarLladre1Co(objetoAMover, objetoAMover.position, destino, velocidad));
        Debug.Log("BaixarEscalas StartCoroutine Tornar: Comença. ");
        
        IEnumerator PujarLladre1Co(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
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
        GameObject.Find("Ladron1").SendMessage("Sortir_Metro");
        Inv_Lladre1 = 1;
        //boxCollider_Player.enabled = true;
        boxCollider_Ladron1.enabled = true;
        Debug.Log("El objeto ha llegado al destino.");
        No_Baixar.SetActive(true);
        Pujar_Escalas_Lladre.SetActive(false);
        
    }
}
