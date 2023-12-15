using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderZoom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Slider slider;
    [SerializeField] private CinemachineVirtualCamera cam;

    private bool touched = false;
    private float last = 0;
    
    public void OnPointerDown (PointerEventData eventData) 
    {
        touched = true;
    }
    
    public void OnPointerUp (PointerEventData eventData) 
    {
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!touched)
        {
            if (slider.value > 0)
            {
                slider.value -= Time.deltaTime*0.8f + slider.value*0.03f;
            }
        }
        if (slider.value != last){

            if (!cam.m_Lens.Orthographic)
            {
                cam.m_Lens.FieldOfView = 35 /* default FOV */ - (slider.value * 20) /* how much zoom you want */;
            }
            else
            {
                cam.m_Lens.OrthographicSize = 11 /* default FOV */ - (slider.value * 6) /* how much zoom you want */;
            }
            
        }
        last = slider.value;
    }
}
