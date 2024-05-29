using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActivarSiLlegaTarde : MonoBehaviour
{
    public GameObject jugador;
    public GameObject mainCam;
    public GameObject camaraLlegarTarde;

    public GameObject gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("player prefs: " + PlayerPrefs.GetInt("llegaTarde"));
       // PlayerPrefs.GetInt("llegaTarde");

        if (PlayerPrefs.GetInt("llegaTarde") == 0)
        {
            //ha llegado bien
            Debug.Log(("ha llegado bien"));
          
        }
        else
        {
            camaraLlegarTarde.SetActive(true);
            mainCam.SetActive(false);
            gameOverText.SetActive(true);
            jugador.gameObject.GetComponent<MovimientoPersonaje>().enabled = false;
            Debug.Log(("llegó tarde"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
