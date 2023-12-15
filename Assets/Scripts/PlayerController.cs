using System.Collections;
using System.Collections.Generic;
using SimpleInputNamespace;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Text _name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        if (_joystick.Vertical >= 0.999f)
        {
            _animator.SetFloat("Speed", 10f);
        } else if (_joystick.Horizontal >= 0.01f || _joystick.Horizontal <= -0.01f)
        {
            _animator.SetFloat("Speed", 10f);
            var rot = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical), Vector3.up);
            transform.rotation = rot;
        }else if(_joystick.Vertical <= -0.999f)
        {
            _animator.SetFloat("Speed", 10f);
            var rot = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical), Vector3.up);
            transform.rotation = rot;
        }
        else
        {
            _animator.Play("Idle", -1 ,0.5f);
        }

        _name.text = (1/Time.deltaTime).ToString();

        Debug.Log("Vertical: " + _joystick.Vertical);
        Debug.Log("Horizontal: " + _joystick.Horizontal);
    }
}
