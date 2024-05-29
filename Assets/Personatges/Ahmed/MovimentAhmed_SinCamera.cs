using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class MovimentAhmed_SinCamera : MonoBehaviour
{
    [SerializeField] private float velocitat = 3f;

    private bool moving = false;

    private Animator animator;

    private GameObject spawn;
    
    // private Vector3 m_CameraPos;
    
    private Rigidbody m_Rb;

    [HideInInspector]public string sceneName = "";
    
    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("fase"))
        {
            PlayerPrefs.SetInt("fase",0);
        }
        
        animator = GetComponent<Animator>();
        if (sceneName != "")
        {
            spawn = GameObject.FindGameObjectWithTag("tp-" + sceneName);
        }/*else
        {
            spawn = GameObject.Find("Spawn");
        }*/
        
        if (spawn)
        {
            
            Vector3 pos = spawn.transform.position;
            transform.position = new Vector3(pos.x, 0, pos.z);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (moving && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            moving = false;
            swapAnim();
        }
        if (!moving && (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0))
        {
            moving = true;
            swapAnim();
        }
        transform.Translate(Vector3.forward * Time.deltaTime * Math.Max(Math.Abs(Input.GetAxis("Vertical")),Math.Abs(Input.GetAxis("Horizontal")))*velocitat);
        transform.LookAt(transform.position + new Vector3((Input.GetAxis("Vertical")*-1f), 0, Input.GetAxis("Horizontal")));
    }

    void swapAnim()
    {
        if (moving)
        {
            animator.SetTrigger("walk");
        }   
        else
        {
            animator.SetTrigger("idle");
        }
    }
    private void LateUpdate()
    {

    }
}
