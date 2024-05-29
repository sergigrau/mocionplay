using Cinemachine;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    void Start()
    {
        //Interactuable.DialogBox = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
        Interactuable.Vcam = GameObject.FindGameObjectWithTag("Interact VCam").GetComponent<CinemachineVirtualCamera>();
        Interactuable.Player = GameObject.FindGameObjectWithTag("Player");
        lastClick = Time.time;
        //Set interactuable objects
        
        string[] tags = { "FocusableObjectHorizontal", "FocusableObjectVertical", "NPC", "Door", "LightSwitch" };

        foreach (var t in tags)
        {
            foreach (GameObject focus in GameObject.FindGameObjectsWithTag(t))
            {
                focus.AddComponent<Interactuable>();
            }
        }
            
        Debug.Log("Controller set");
    }

    private float delay = 0.1f;
    public static float lastClick;
    
    void Update()
    {
        if (Interactuable.IsFocused)
        {
            if (Time.time >= lastClick + delay)
            {
                CheckClick();
            }
        }
    }
    void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Interactuable.SetFocus(false);
        }
    }
}
