using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Interactuable : MonoBehaviour
{
    private const int Dialog = 0;
    private const int Light = 1;
    private const int Focusable = 2;
    private const int Door = 3;
    
    public static CinemachineVirtualCamera Vcam;
    public static GameObject Player;
    public static Text DialogText;
    public static bool IsFocused;
    public bool isOpen;
    
    private static int _type;
    private static GameObject _objectFocused;
    private static List<GameObject> _staticLight;
    private static bool _isOn = true;
    
    
    private void OnMouseDown()
    {
        if (GetDistance() < 5 && !IsFocused && InteractController.lastClick + 0.1f < Time.time)
        {
            InteractController.lastClick = Time.time;
            Debug.Log("Focusing object");
            OnFocus();
            Interact();
        }
    }
    private float GetDistance()
    {
        Vector3 playerPos = Player.transform.position;
        Vector3 objectPos = transform.position;
        playerPos.y = 0;
        objectPos.y = 0;
        Debug.Log(Vector3.Distance(playerPos,objectPos));
        return Vector3.Distance(playerPos, objectPos);
    }

    private void OnFocus()
    {
        _objectFocused = gameObject;
        Vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y = 0;
        if (gameObject.CompareTag("LightSwitch"))
        {
            _type = Light;
            _staticLight = GetComponent<LightList>().lights;
        }
        else if (gameObject.CompareTag("FocusableObjectHorizontal") || gameObject.CompareTag("FocusableObjectVertical"))
        {
            _type = Focusable;

            if (gameObject.CompareTag("FocusableObjectVertical"))
            {
                Vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y = 90;
            }

            Vcam.LookAt = _objectFocused.transform;
            Vcam.Follow = _objectFocused.transform;
        }
        else if (gameObject.CompareTag("Door"))
        {
            _type = Door;
        }
        else if (gameObject.CompareTag("NPC"))
        {
            _type = Dialog;

            Vcam.LookAt = _objectFocused.transform;
            Vcam.Follow = _objectFocused.transform;
        }
    }

    public static void Interact()
    {
        Debug.Log("interact "+ _type);
        switch (_type)
        {
            case Dialog:
                SetDialog();
                break;
            case Light:
                SwitchLights();
                break;
            case Focusable:
                Focus();
                break;
            case Door:
                ToggleDoor();
                break;
        }
    }

    private static void Focus()
    {
        SetFocus(!IsFocused);
        Debug.Log("Focus "+IsFocused);
    }

    public static void SetFocus(bool focus)
    {
        IsFocused = focus;
        if (focus)
        {
            Debug.Log("Focus on");
            Player.SetActive(false);
            Vcam.Priority = 15;
        }
        else
        {
            Debug.Log("Focus off");
            Player.SetActive(true);
            Vcam.Priority = 5;
        }
    }
    private static void SwitchLights()
    {
        Debug.Log(_isOn);
        _staticLight = _objectFocused.GetComponent<LightList>().lights;
        foreach (var l in _staticLight)
        {
            l.SetActive(_isOn);
        }   
        _isOn = !_isOn;
    }

    private static void ToggleDoor()
    {
        bool isOpen = _objectFocused.GetComponent<Interactuable>().isOpen;
        GameObject door = _objectFocused.transform.GetChild(1).gameObject;
        if (isOpen)
        {
            _objectFocused.transform.Rotate(0, 90, 0);
            door.SetActive(false);
        }
        else
        {
            _objectFocused.transform.Rotate(0, -90, 0);
            door.SetActive(true);
        }
        _objectFocused.GetComponent<Interactuable>().isOpen = !isOpen;
    }
    private static void SetDialog()
    {
        SetFocus(!IsFocused);
        // Dialog here
    }
}
