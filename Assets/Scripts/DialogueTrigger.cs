using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<dialogueString> dialogueStrings = new List<dialogueString>();
    [SerializeField] private Transform NPCTransform;

    private bool hasSpoken = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasSpoken)
        {
            other.gameObject.GetComponent<DialogueManager>().DialogueStart(dialogueStrings, NPCTransform);
            other.gameObject.GetComponent<PlayerMotion>().canMove = false;
            hasSpoken = true;
        }
        hasSpoken = false;
    }
}

[System.Serializable]
public class dialogueString
{
    public string text;
    public bool isEnd;

    [Header("Branch")]
    public bool isQuestion;
    public string answerOption1;
    public string answerOption2;
    public int optio1IndexJump;
    public int optio2IndexJump;

    [Header("Triggered Events")]
    public UnityEvent startDialogEvent;
    public UnityEvent endDialogEvent;
}
