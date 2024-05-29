using System;
using System.Collections;
using System.Collections.Generic;
using SimpleInputNamespace;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    public Vector3 _input;
    [SerializeField] private Rigidbody _rb;
    
    private float speed = 0.1f;
    [SerializeField] float isometricAngle = -45f;
    public float currentAngle;
    [SerializeField] GameObject playermodel;
    [SerializeField] GameObject playermodel2;
    [SerializeField] public bool iswall = false;
    [SerializeField] private FixedJoystick _joystick;

    public bool canMove = true;
    private bool moving = false;

    private Animator animator;
    
    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (_input.magnitude == 0)
        {
            _input = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        }
    }

    private void Move(Vector3 skewedInput)
    {
        //Vector3 movement = new Vector3(skewedInput.x*speed, skewedInput.y*speed, skewedInput.z*speed);
        float totalMovement = Math.Abs(skewedInput.x) + Math.Abs(skewedInput.z);
        float x = Math.Abs(skewedInput.x) / totalMovement;
        float z = Math.Abs(skewedInput.z) / totalMovement;
        x *= speed;
        z *= speed;
        x = (skewedInput.x > 0) ? x : -x;
        z = (skewedInput.z > 0) ? z: -z;
        
        Vector3 movement = new Vector3((float)Math.Round(x,2), 0, (float)Math.Round(z,2));
        Debug.Log(movement);
        _rb.MovePosition(transform.position + movement);
    }

    private void Look()
    {
        // var skewedInput = matrix.MultiplyPoint3x4(_input);
        var skewedInput = Quaternion.Euler(0, currentAngle, 0) * _input;
        
        if (_input != Vector3.zero)
        {
            var relative = (skewedInput);
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            
            if (canMove)
            {
                playermodel.transform.LookAt(playermodel.transform.position + new Vector3(skewedInput.x, 0, skewedInput.z));
                playermodel2.transform.LookAt(playermodel2.transform.position + new Vector3(skewedInput.x, 0, skewedInput.z));
                
                if (!iswall)
                {
                    if (!moving)
                    {
                        moving = true;
                        swapAnim();
                    }
                    Move(skewedInput);
                }
            }
        }
        else if (moving)
        {
            moving = false;
            swapAnim();   
        }
    }

    public void setMove(bool t)
    {
        canMove = t;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator = playermodel.GetComponent<Animator>();
        Debug.Log(animator.GetParameter(0).name);
        currentAngle = isometricAngle;
        transform.Rotate(0, currentAngle, 0, Space.Self);

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
    public void rotateCamera()
    {
        if (Input.GetKey("o"))
        {
            currentAngle -= 0.05f;
            transform.Rotate(0, -0.05f, 0, Space.Self);
        }
        if (Input.GetKey("p"))
        {
            currentAngle += 0.05f;
            transform.Rotate(0, 0.05f, 0, Space.Self);
        }
        
        // textFrames.text = ((Math.Cos(transform.rotation.y).ToString()));
    }

    // Update is called once per frame
    void Update()
    {
        GatherInput();

        Look();
        
        rotateCamera();
        
        //Move();
    }
}