using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Futur_Avia : MonoBehaviour
{
    public GameObject Escena_Avia_Futur;
    public GameObject Escena_Lladres;
    
    public void Avia_Futur()
    {
        Escena_Lladres.SetActive(false);
        Escena_Avia_Futur.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
