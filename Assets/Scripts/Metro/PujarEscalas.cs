using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PujarEscalas : MonoBehaviour
{
    public GameObject No_Baixar;
    //public GameObject No_Pujar;
    //public GameObject Baixar_Escalas;
    
    // Define las coordenadas de origen y destino
    [SerializeField] private Transform objetoAMover;
    [SerializeField] private Vector3 destino;

    // Velocidad de movimiento del objeto
    public float velocidad = 1.0f;

    public static int dif_Obj = 0;
    public static int Inv_Lladre1;
    
    public float rotationSpeedX = 0f; // Velocidad de rotación en el eje X
    public float rotationSpeedY = 0f;
    public float rotationSpeedZ = 0f;
    
    private BoxCollider boxCollider_Player;
    
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Inv_Lladre1 = 0;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        // GameObject Ladron1 = GameObject.FindGameObjectWithTag("Ladron1");
        
        Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        
        dif_Obj = 0;
        boxCollider_Player = Player.GetComponent<BoxCollider>();
        
        float rotationX = rotationSpeedX * Time.deltaTime;
        float rotationY = rotationSpeedY * Time.deltaTime;
        float rotationZ = rotationSpeedZ * Time.deltaTime;
                
        Player.transform.Rotate(rotationX, rotationY, rotationZ);
        
        if (other.CompareTag("Player"))
        {
            dif_Obj = 1;
            boxCollider_Player.enabled = false;
            StartCoroutine(Pujar());
        }
    }
    
    IEnumerator Pujar()
    {
        No_Baixar.SetActive(false);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        boxCollider_Player = Player.GetComponent<BoxCollider>();
        
        yield return StartCoroutine(PujarCo(objetoAMover, objetoAMover.position, destino, velocidad));
        Debug.Log("BaixarEscalas StartCoroutine Tornar: Comença. ");
        
        IEnumerator PujarCo(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
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
        Debug.Log("El objeto ha llegado al destino.");
        No_Baixar.SetActive(true);
        //Baixar_Escalas.SetActive(true);
        //No_Pujar.SetActive(true);
        
    }
}
