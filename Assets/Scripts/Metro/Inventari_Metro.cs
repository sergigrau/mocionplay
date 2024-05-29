using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventari_Metro : MonoBehaviour
{
    public GameObject Ladron1;
    public GameObject Avia;
    // public GameObject Escena_Lladres;
    // public GameObject Script_Volver;
    public GameObject Empty_Escena;
    public GameObject Escena_Futur;
    public GameObject Pujar_Escalas_Lladre;
    public GameObject Script_MourePlayer;
    public GameObject Baixar_Escalas_Robatori;
    public GameObject Baixar_Escalas;
    
    private void Awake()
    {
        int Inv_SalirLadron1 = DesactivarLladre1.Inv_SalirLadron1;
        Debug.Log("Inv_SalirLadron1: " + Inv_SalirLadron1);
        int Inv_Volver = Volver_Antic.Inv_Volver;
        Debug.Log("Inv_Volver: " + Inv_Volver);
        int Inv_AjudarAvia_Ajudar = AjudarAvia.Inv_AjudarAvia;
        Debug.Log("Inv_AjudarAvia_Ajudar: " + Inv_AjudarAvia_Ajudar);
        int Inv_AjudarAvia_Baixar = BaixarEscalas.Inv_AjudarAvia;
        Debug.Log("Inv_AjudarAvia_Baixar: " + Inv_AjudarAvia_Baixar);
        int Inv_Lladre1 = PujarEscalas.Inv_Lladre1;
        Debug.Log("Inv_Lladre1: " + Inv_Lladre1);
        int Inv_MourePlayer = Moure_Player.Inv_MourePlayer;
        Debug.Log("Inv_MourePlayer: " + Inv_MourePlayer);
        int Inv_Fase1 = Canviar_Fase.Inv_Fase1;
        Debug.Log("Inv_Fase1: " + Inv_Fase1);
        int Inv_Fase3 = Canviar_Fase.Inv_Fase3;
        Debug.Log("Inv_Fase3: " + Inv_Fase3);

        // Si el lladre a sortit del Metro
        if (Inv_Fase3 == 1)
        {
            if (Inv_SalirLadron1 == 1)
            {
                Ladron1.SetActive(false);
            }
            else if (Inv_SalirLadron1 == 0)
            {
                Ladron1.SetActive(true);
            }
            
            // Si el jugador a decidit tornar a parar el Lladre
            if (Inv_Volver == 1)
            {
                // Escena_Lladres.SetActive(false);
                // Script_Volver.SetActive(false);
                Empty_Escena.SetActive(false);
            }
            else if (Inv_Volver == 0)
            {
                // Escena_Lladres.SetActive(true);
                // Script_Volver.SetActive(true);
                Empty_Escena.SetActive(true);
            }
            
            // Si el Lladre a fet tots els scripts que tenia que fer
            if (Inv_Lladre1 == 1)
            {
                // Escena_Lladres.SetActive(false);
                // Script_Volver.SetActive(false);
                Pujar_Escalas_Lladre.SetActive(false);
                Empty_Escena.SetActive(false);
                Escena_Futur.SetActive(false);
                Baixar_Escalas_Robatori.SetActive(false);
                Baixar_Escalas.SetActive(true);
            }
            else if (Inv_Lladre1 == 0)
            {
                // Escena_Lladres.SetActive(true);
                // Script_Volver.SetActive(true);
                Pujar_Escalas_Lladre.SetActive(true);
                Empty_Escena.SetActive(true);
                Escena_Futur.SetActive(true);
                Baixar_Escalas_Robatori.SetActive(true);
                Baixar_Escalas.SetActive(false);
            }
            
            // Si el Player ja ha fet per primera vegada el moures cap a les escales mecaniques
            if (Inv_MourePlayer == 1)
            {
                Script_MourePlayer.SetActive(false);
                Debug.Log("Inv_MourePlayer: Script false");
            }
            else if (Inv_MourePlayer == 0)
            {
                Script_MourePlayer.SetActive(true);
                Debug.Log("Inv_MourePlayer: Script true");
            }
            
            // Si el jugador a decidit Ajudar a l'Avia
            if ((Inv_AjudarAvia_Baixar == 1) || (Inv_AjudarAvia_Ajudar == 1))
            {
                // Escena_Lladres.SetActive(false);
                // Script_Volver.SetActive(false);
                Pujar_Escalas_Lladre.SetActive(false);
                Baixar_Escalas_Robatori.SetActive(false);
                Baixar_Escalas.SetActive(true);
                Empty_Escena.SetActive(false);
                Escena_Futur.SetActive(false);
                Ladron1.SetActive(false);
            }
            else if ((Inv_AjudarAvia_Baixar == 0) || (Inv_AjudarAvia_Ajudar == 0))
            {
                // Escena_Lladres.SetActive(true);
                // Script_Volver.SetActive(true);
                Pujar_Escalas_Lladre.SetActive(true);
                Baixar_Escalas_Robatori.SetActive(true);
                Baixar_Escalas.SetActive(false);
                Empty_Escena.SetActive(true);
                Escena_Futur.SetActive(true);
                Ladron1.SetActive(true);
            }
        }

        if (Inv_Fase1 == 1)
        {
            Pujar_Escalas_Lladre.SetActive(false);
            Baixar_Escalas_Robatori.SetActive(false);
            Baixar_Escalas.SetActive(true);
            Empty_Escena.SetActive(false);
            Escena_Futur.SetActive(false);
            Ladron1.SetActive(false);
            
            Avia.SetActive(false);
            
            Script_MourePlayer.SetActive(false);
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
