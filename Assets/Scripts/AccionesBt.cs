using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AccionesBt : MonoBehaviour
{
    public AudioSource reproductorMusica;
    public Sprite texturaSoOn, texturaSoOff;
    public Boolean estaSonan=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void empezarJuego()
    {
        SceneManager.LoadScene(1);
    }
    public static void terminarJuego()
    {
        Application.Quit();
    }
    public void interacionarMusica()
    {
        if (estaSonan)
        { 
            reproductorMusica.Pause();
            GetComponent<Image>().sprite = texturaSoOff;
            
        }
        else
        {
            reproductorMusica.Play();
            GetComponent<Image>().sprite = texturaSoOn;
        }

        estaSonan = !estaSonan;
    }

    

}
