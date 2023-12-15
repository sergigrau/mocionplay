using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    [SerializeField] private CanvasGroup myCanvas;
    
    [SerializeField] public bool fadeIn = false;
    [SerializeField] public bool fadeOut = false;

    [SerializeField] public float fdspeed = 1; // fdspeed 1 == 100% (DEFAULT)
    [SerializeField] public float limit;
    
    [SerializeField] public bool showThis;

    private float speed = 0.5f;

    public void show()
    {
        fadeIn = true;
        fadeOut = false;
    }
    
    public void hide()
    {
        fadeOut = true;
        fadeIn = false;
    }

    public void onStart()
    {
        myCanvas.alpha = limit;
        if (showThis) { hide();}
    }

    public void Start()
    {
        onStart();
    }

    public void Update()
    {
        if (fadeIn)
        {
            if (myCanvas.alpha < limit)
            {
                myCanvas.alpha = myCanvas.alpha + Time.deltaTime * fdspeed;
                if (myCanvas.alpha >= limit)
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if (myCanvas.alpha > 0)
            {
                myCanvas.alpha = myCanvas.alpha - Time.deltaTime * fdspeed;
                if (myCanvas.alpha <= 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}


/*
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }
}

[System.Serializable]
public class Dialogue
{
    public string name;
    
    [TextArea(1,2)]
    public string[] sentences;
    
}

public class DialogTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().Start
    }
}

*/