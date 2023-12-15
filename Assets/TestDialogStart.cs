using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogStart : MonoBehaviour
{

    [SerializeField] public SceneAuxiliar sca;

    [SerializeField] public PlayerInteraction pl;
    [SerializeField] GameObject cutScene;
    [SerializeField] GameObject cinematicCamera;
    [SerializeField] GameObject mainCamera;

    private string code;
    // Start is called before the first frame update
    void Start()
    {
        pl.cutScene = cutScene;
        pl.mainCamera = mainCamera;
        pl.cinematicCamera = cinematicCamera;
        code = "asdf";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("walldetection"))
        {
            pl.aim = this;
            pl.activateDialog();
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("walldetection"))
        {
            pl.aim = null;
            pl.activateDialog();
            
        }
    }

    public string getSentence()
    {
        // hacer consulta del codigo deseado
        return code;
    }

    
}
