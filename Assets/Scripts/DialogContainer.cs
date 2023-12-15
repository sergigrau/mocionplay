using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogContainer : MonoBehaviour
{
    public List<DialogueParser.Dialogue> list;
    
    public bool isStarted = false;
    private bool wasPressed = false;

    [SerializeField] public CanvasGroup display;
    
    [SerializeField] public Text persona;
    [SerializeField] public Text dialogo;
    private Queue<string> listPersona = new Queue<string>();
    private Queue<string> listDialogo = new Queue<string>();
    private Queue<float> listSpeeds = new Queue<float>();

    [SerializeField] public PlayerMotion pl;

    [SerializeField] public Fading dialogFading;
    
    public float wrtieSpeed = 1; // writespeed 1 = 100% (DEFAULT time between leters is 0.06 sec)
    public bool isWriting = false;
    private string strBridge = "";
    private float timePasswd = 0;

    private int queuelong()
    {
        return listDialogo.Count;
    }

    private void passLetter()
    {
        dialogo.text += (strBridge.Substring(0, 1));
        strBridge = strBridge.Remove(0, 1);

        if (strBridge.Length == 0)
        {
            isWriting = false;
        }
    }
    
    public void getSentence()
    {
        if (queuelong() != 0)
        {
            persona.text = listPersona.Dequeue();
            // dialogo.text = listDialogo.Dequeue();

            strBridge = listDialogo.Dequeue();
            dialogo.text = "";
            isWriting = true;

            wrtieSpeed = listSpeeds.Dequeue();
            Debug.Log(queuelong());
        }
        else
        {
            endDialog();
        }
    }

    public void startDialog()
    {
        isStarted = true;
        pl.canMove = false;
        getSentence();
        
        dialogFading.show();
    }

    private void endDialog()
    {
        dialogFading.hide();
        isStarted = false;
        pl.canMove = true;
    }

    public void addSentence(string name, string dialog, float dialog_speed = 1)
    {
        listPersona.Enqueue(name);
        listDialogo.Enqueue(dialog);
        listSpeeds.Enqueue(dialog_speed);
    }
    

    public void nextSentence()
    {
        if (isStarted)
        {
            
            if (Input.GetKey("m"))
            {
                if (!wasPressed)
                {
                    getSentence();
                }
            }
        }

        wasPressed = Input.GetKey("m");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(1 / Time.deltaTime);
        
        if (isWriting)
        {
            nextSentence();
            
            if (timePasswd >= 0.06)
            {
                passLetter();
                timePasswd = 0;
            }
            else
            {
                timePasswd += (Time.deltaTime * wrtieSpeed);
            }
        }
    }

    private void Start()
    {
        
    }
}
