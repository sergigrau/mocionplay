using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FadeJoystick : MonoBehaviour
{
    [SerializeField] private Fading fadeJoystick;
    [SerializeField] private Joystick selfJoystick;
    private float currentTime, limit = 1.1f;
    private bool touched = false;
    
    // Start is called before the first frame update
    void Start()
    {
        touched = false;
        currentTime = 0;
    }

    public void gather()
    {
        if (selfJoystick.Horizontal != 0) { touched = true; }
        else if (selfJoystick.Vertical != 0) { touched = true; }
        else { touched = false; }
    }

    // Update is called once per frame
    void Update()
    {
        gather();

        if (touched)
        {
            fadeJoystick.show();
            currentTime = 0;
        }
        else
        {
            if (currentTime <= limit)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                fadeJoystick.hide();
            }
        }
    }
}
