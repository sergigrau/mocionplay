using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treure_Cartell : MonoBehaviour
{
    public GameObject Cartell_Metro1;
    public GameObject Cartell_Metro2;
    int Click_Cartell1 = Click_Cartell_Metro1.Click_Cartell1;
    int Click_Cartell2 = Click_Cartell_Metro2.Click_Cartell2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Cartell_Metro1.SetActive(false);
                Cartell_Metro2.SetActive(false);
                Debug.Log("Cuadres tret");
            }
        }
    }
}
