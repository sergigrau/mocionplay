using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Cartell_Metro1 : MonoBehaviour
{
    public static int Cerca_Cartell;
    public static int Click_Cartell1;
    public GameObject Cartell_Metro1;
    public GameObject Manager_Principal;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cerca_Cartell = 1;
            Manager_Principal.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Cerca_Cartell = 0;
        Manager_Principal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Cerca_Cartell == 1)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    Click_Cartell1 = 1;
                    Cartell_Metro1.SetActive(true);
                    Debug.Log("Cuadre premut");
                }
            }
        }
    }
}
