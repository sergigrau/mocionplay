using System.Collections;
using System.Collections.Generic;
using SimpleInputNamespace;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    public Vector3 _input;
    [SerializeField] private Rigidbody _rb;
    
    private float speed = 0.17f;
    [SerializeField] float isometricAngle = -45f;
    public float currentAngle;
    [SerializeField] GameObject playermodel;
    [SerializeField] GameObject playermodel2;
    [SerializeField] public bool iswall = false;
    [SerializeField] private FixedJoystick _joystick;

    public bool canMove = true;
    
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
        float a = speed*Time.deltaTime;
        Vector3 movement = new Vector3(skewedInput.x*speed, skewedInput.y*speed, skewedInput.z*speed);
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
                
                playermodel.transform.rotation = rot;
                playermodel2.transform.rotation = rot;
                
                if (!iswall)
                {
                    Move(skewedInput);
                }
            }
        }
    }

    public void setMove(bool t)
    {
        canMove = t;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = isometricAngle;
        transform.Rotate(0, currentAngle, 0, Space.Self);

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
