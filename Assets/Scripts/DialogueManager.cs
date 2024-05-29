using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=BEaOHWkZhtE
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueParent;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button nextDialogButton;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;

    [SerializeField] private TriggerAction action;
    [SerializeField] private GlassesBehaviour glass;

    [SerializeField] private float typingSpeed = 1f;
    [SerializeField] private float turnSpeed = 2f;

    private bool nextDialogBUttonClicked;
    private bool optionSelected = false;

    private List<dialogueString> dialogueList;

    [Header("Player")]
    [SerializeField] private FixedJoystick thirdPersonController;
    private Transform playerCamera;

    private int currentDialogueIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueParent.SetActive(false);
        playerCamera = Camera.main.transform;
        
    }

    public void ChangeAspectButtons(bool ActionButton, bool glassButton, int alphaAction, int alphaGlasses, Vector3 scaleAction, Vector3 ScaleGlasses)
    {
        action.transform.localScale = scaleAction;
        action.button.interactable = ActionButton;
        action.cv.alpha = alphaAction;

        glass.bt.interactable = glassButton;
        glass.cv.alpha = alphaGlasses;
        glass.transform.localScale = ScaleGlasses;
    }

    public void DialogueStart(List<dialogueString> textToPrint, Transform NPC)
    {
        dialogueParent.SetActive(true);
        dialogueParent.GetComponent<Fading>().show();
        //GameObject.Find("Fixed Joystick").SetActive(false);
        thirdPersonController.enabled = false;

        ChangeAspectButtons(true, false, 1, 0, new Vector3(1, 5.36f, 1), Vector3.zero);

        StartCoroutine(TurnCameraTowardsNPC(NPC));

        dialogueList = textToPrint;
        currentDialogueIndex = 0;

        DisableButtons();

        StartCoroutine(PrintDialog());
    }

     public void DisableButtons()
     {
        option1Button.interactable = false;
        option2Button.interactable = false;


        option1Button.GetComponentInChildren<TMP_Text>().text = "No option";
        option2Button.GetComponentInChildren<TMP_Text>().text = "No option";
     }

     private IEnumerator TurnCameraTowardsNPC(Transform NPC)
     {
        Quaternion startRotation = playerCamera.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(NPC.position - playerCamera.position);

        float elapsedTime = 0f;

        while(elapsedTime < 1f)
        {
            playerCamera.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * turnSpeed;
            yield return null;
        }

        playerCamera.rotation = targetRotation;
        //Debug.Log("Hola");
     }

     private IEnumerator PrintDialog()
    {
        while(currentDialogueIndex < dialogueList.Count)
        {
            dialogueString line = dialogueList[currentDialogueIndex];

            line.startDialogEvent?.Invoke();

            if(line.isQuestion)
            {
                yield return StartCoroutine(TypeText(line.text));

                option1Button.interactable = true;
                option2Button.interactable = true;

                option1Button.GetComponentInChildren<TMP_Text>().text = line.answerOption1; 
                option2Button.GetComponentInChildren<TMP_Text>().text = line.answerOption2;

                option1Button.onClick.AddListener(() => HandleOptionSelected(line.optio1IndexJump));
                option2Button.onClick.AddListener(() => HandleOptionSelected(line.optio2IndexJump));

            }
            else
            {
                yield return StartCoroutine(TypeText(line.text));
            }
            line.endDialogEvent?.Invoke();

            optionSelected = false;
        }

        //DialogueStop();

     }

     private void HandleOptionSelected(int indexJump)
     {
        optionSelected = false;
        DisableButtons();

        currentDialogueIndex = indexJump;
     }

     private void ClickButton()
     {
        ChangeAspectButtons(false, true, 0, 1, Vector3.zero, new Vector3(1, 3.2f, 1));
        dialogueParent.GetComponent<Fading>().hide();
        thirdPersonController.enabled = true;
        //Debug.Log(nextDialogBUttonClicked);
        nextDialogBUttonClicked = true;
    }

     private IEnumerator WaitUntilForClick()
     { 
        yield return new WaitUntil(() => nextDialogBUttonClicked);
     }

     private IEnumerator TypeText(string text)
     {
        dialogueText.text = "";

        foreach(char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            //yield return new WaitForSeconds(typingSpeed);
        }

        if (!dialogueList[currentDialogueIndex].isQuestion)
        {
            nextDialogButton.onClick.AddListener(ClickButton);
            StartCoroutine(WaitUntilForClick());
        }

        if (dialogueList[currentDialogueIndex].isEnd)
        {
            nextDialogButton.onClick.AddListener(ClickButton);
            StartCoroutine(WaitUntilForClick());
            //nextDialogBUttonClicked = false;
            if (nextDialogBUttonClicked)
            {
                DialogueStop();
                nextDialogBUttonClicked = false;
            }
        }
        if (nextDialogBUttonClicked)
        {
            //yield return new WaitForSeconds(typingSpeed);
            yield return null;
            currentDialogueIndex++;
            nextDialogBUttonClicked = false;
        }
     }

    private void DialogueStop()
    {
        StopAllCoroutines();
        ChangeAspectButtons(false, true, 0, 1, Vector3.zero, new Vector3(1, 3.2f, 1));
        dialogueParent.GetComponent<Fading>().hide();
        thirdPersonController.enabled = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerMotion>().canMove = true;
        dialogueText.text = "";
        //GameObject.Find("Fixed Joystick").SetActive(true);
        Debug.Log("Hola");
    }
}
