using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float gravity = 9.81f;

    private float _fallVelocity = 0f;

    private CharacterController _characterController;

    public float jumpForce;

    public float speed;

    private Vector3 _moveVector;

    void Update ()
    {
        // Movement
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector-= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {

        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);


        // Fall and Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}