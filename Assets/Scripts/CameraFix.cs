using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    
    [SerializeField] public GameObject objPlayer;

    private Vector3 transformPlayer;

    [SerializeField] public Vector3 offset = new Vector3(11, 13, -11);

    [SerializeField] public bool nowActive = false;
    // Start is called before the first frame update
    void Start()
    {
        nowActive = true;
        transformPlayer = objPlayer.transform.position;
    }

    public void followPlayer()
    {
        if (nowActive)
        {
            transformPlayer = objPlayer.transform.position;
            transform.position = transformPlayer + offset;
        }
    }

    public void setActive()
    {
        nowActive = true;
    }

    public void setInactive()
    {
        nowActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        transformPlayer = objPlayer.transform.position;
        followPlayer();

        if (Input.GetKey("m"))
        {
            nowActive = !nowActive;
        }
    }
}
