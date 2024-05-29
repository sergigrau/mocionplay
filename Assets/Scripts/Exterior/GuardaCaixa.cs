using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaCaixa : MonoBehaviour
{
    public GameObject Caixa;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Caixa en inventari");
                GlobalVariables.Caixa_Esta_Agafada = true;
                
                //logica de guardar items en el inventari
            }
        }
        
        if (GlobalVariables.Caixa_Esta_Agafada) //CADA VEGADA QUE ES CAMBIA D'ESCENA S'EXECUTA AIXÒ, EL SCRIPT S'ACTIVA 1 FRAME I ES TORNA A DESACTIVAR
        {
            Debug.Log("Caixa fora");
            gameObject.SetActive(false);
            Caixa.SetActive(false);
        }
    }
}
