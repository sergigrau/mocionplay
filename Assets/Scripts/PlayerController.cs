using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Text _name;

    private Vector2 _moveInput;
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        // Inicialitza l'objecte PlayerInputActions
        _playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        // Activa les accions del PlayerInputActions
        _playerInputActions.Player.Enable();
        
        // Subscriu les accions a esdeveniments
        _playerInputActions.Player.Move.performed += OnMove;
        _playerInputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        // Desubscribe les accions dels esdeveniments
        _playerInputActions.Player.Move.performed -= OnMove;
        _playerInputActions.Player.Move.canceled -= OnMove;
        
        // Desactiva les accions del PlayerInputActions
        _playerInputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Llegeix el valor de l'entrada com un Vector2
        _moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Mou el jugador basant-se en l'input de moviment
        Vector3 move = new Vector3(_moveInput.x * _moveSpeed, _rigidbody.velocity.y, _moveInput.y * _moveSpeed);
        _rigidbody.velocity = move;

        // Gestiona l'animació i la rotació del jugador
        if (_moveInput.y >= 0.999f || Mathf.Abs(_moveInput.x) >= 0.01f || _moveInput.y <= -0.999f)
        {
            _animator.SetFloat("Speed", 10f);
            var rot = Quaternion.LookRotation(new Vector3(_moveInput.x, 0, _moveInput.y), Vector3.up);
            transform.rotation = rot;
        }
        else
        {
            _animator.Play("Idle", -1, 0.5f);
        }

        // Actualitza el text de velocitat
        _name.text = (1 / Time.deltaTime).ToString();

        // Debug
        Debug.Log("Vertical: " + _moveInput.y);
        Debug.Log("Horizontal: " + _moveInput.x);
    }
}


/*using System.Collections;
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
}*/
