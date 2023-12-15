using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private Queue<string> listPersona = new Queue<string>();
    private Queue<string> listDialogo = new Queue<string>();
    private Queue<float> listSpeeds = new Queue<float>();
    
    [SerializeField] public SceneAuxiliar sca;
    public TestDialogStart aim;
    private bool inDialog;
    [SerializeField] private TriggerAction action;
    [SerializeField] private GlassesBehaviour glass;
    public GameObject cutScene;
    public GameObject cinematicCamera;
    public GameObject mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        aim = null;
    }

    public void activateDialog()
    {
        if (aim is not null)
        {
            action.transform.localScale = new Vector3(1, 5.36f, 1);
            action.button.interactable = true;
            action.cv.alpha = 1;

            mainCamera.SetActive(false);
            cinematicCamera.SetActive(true);
            cutScene.SetActive(true);

            glass.bt.interactable = false;
            glass.cv.alpha = 0;
            glass.transform.localScale = Vector3.zero;

        }
        else
        {
            action.button.interactable = false;
            action.cv.alpha = 0;
            action.transform.localScale = Vector3.zero;

            mainCamera.SetActive(true);
            cutScene.SetActive(false);
            cinematicCamera.SetActive(false);

            glass.transform.localScale = new Vector3(1, 3.2f, 1);
            glass.bt.interactable = true;
            glass.cv.alpha = 1;
        }
    }

    public void displayAction()
    {

        if (!sca.isDialog())
        {
            // a more complex function is needed in DialogContainer, to detect if its new dialog, or ending
            string code = aim.getSentence();
        
            sca.searchSentence(code);
            // the search for other dialogs is made in another location

            sca.startDialog();
            
        }
        else
        {
            sca.nextSentence();
        }
    }


}
