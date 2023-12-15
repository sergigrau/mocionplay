using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SceneAuxiliar : MonoBehaviour
{
    [SerializeField] private PlayerMotion currentPlayer;

    [SerializeField] private DialogContainer dialogContainer;
    [SerializeField] public GlassesBehaviour glasses;
    
    // Start is called before the first frame update

    public void addDialog(string author, string dialog, float speed = 1)
    {
        dialogContainer.addSentence(author, dialog, speed);
    }

    public void startDialog()
    {
        dialogContainer.startDialog();
    }

    public void searchSentence(string s)
    {
        // implementar busqueda de codigo en lista
        
        addDialog("Samuel", s, 0.4f);
    }

    public bool isDialog()
    {
        return dialogContainer.isStarted;
    }

    public void nextSentence()
    {
        dialogContainer.getSentence();
    }
    
    void Start()
    {
        string temp = ""; while (temp.Length < 1000) { temp += "3";}
        
        /*
        addDialog("Samuel", "esto es una prueba de los dialogos");
        addDialog("Misigno", "Iore lipsum", 0.3f);
        addDialog("ANONYMOUS", temp, 2.5f);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
