using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prohibitpasar : MonoBehaviour
{
    public GameObject Avis_Prohibit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Avis Prohibit Tesoro detectat");
            Avis_Prohibit.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Avis Pala Tesoro desDetectat");
            Avis_Prohibit.SetActive(false);
        }
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
