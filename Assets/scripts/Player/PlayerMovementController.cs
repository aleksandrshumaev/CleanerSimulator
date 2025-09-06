using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //[SerializeField] float _speed;
    //[SerializeField] float _turnSpeed;
    [SerializeField] Joystick _joystick;
    Rigidbody _playerRigidBody;
    Animator _playerAnimator;
    PlayerStats _playerStats;
    float _horizontalInput;
    float _verticalInput;
    Vector3 _movementPosition;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody>();
        _playerStats =GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    private void Update()
    {
        _horizontalInput = _joystick.Horizontal;
        _verticalInput = _joystick.Vertical;
        _movementPosition.x = _horizontalInput;
        _movementPosition.z = _verticalInput;
    }
    void FixedUpdate()
    {
        //Test = _joystick.Direction;
        _playerAnimator.SetFloat("Speed_f",Mathf.Sqrt(Mathf.Pow(_movementPosition.x,2)+ Mathf.Pow(_movementPosition.y, 2))* _playerStats.Speed);

        //_horizontalInput = Input.GetAxis("Horizontal");
        //_verticalInput=Input.GetAxis("Vertical");
        if (_verticalInput!=0 && _horizontalInput!=0)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * _verticalInput * _playerStats.Speed);
            //_playerRigidBody.velocity= transform.forward * Time.deltaTime * _verticalInput * _playerStats.Speed;
            //_playerRigidBody.MovePosition(Vector3.forward * Time.deltaTime * _verticalInput * _playerStats.Speed);
            _playerRigidBody.MovePosition(_playerRigidBody.position + _movementPosition * Time.fixedDeltaTime *_playerStats.Speed);
            //_playerRigidBody.AddRelativeForce((Vector3.forward * Time.deltaTime * _verticalInput * _playerStats.Speed)+ (Vector3.right * Time.deltaTime * _horizontalInput * _playerStats.Speed));
            if(!_playerStats.IsMoving)
            {
                _playerStats.Move();
            }
            //transform.Rotate(Vector3.up, testTwo );
            float testTwo = Mathf.Atan2(_joystick.Direction.x, _joystick.Direction.y) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, testTwo, transform.eulerAngles.z);
        }
        else
        {
            if (_playerStats.IsMoving)
            {
                _playerStats.StopMove();
            }
                
        }


    }
}
