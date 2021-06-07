using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ThirdPersonMover : MonoBehaviour
{
    [SerializeField]  float _turnSpeed = 1000f;
    [SerializeField]  float _movespeed = 5f;
    Rigidbody _rigidbody;
    Animator _animator;
    float _mouseMovement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _mouseMovement += Input.GetAxis("Mouse X");
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(ToggleablePanel.IsVisable == false)
            transform.Rotate(0, _mouseMovement * Time.deltaTime * _turnSpeed, 0);
        _mouseMovement = 0f;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            vertical *= 2;
        }

        var velocity = new Vector3(horizontal, 0, vertical);
        velocity *= _movespeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity;
        _rigidbody.MovePosition(transform.position + offset);
        
        _animator.SetFloat("Vertical", vertical, 0.1f, Time.fixedDeltaTime);
        _animator.SetFloat("Horizontal", horizontal, 0.1f, Time.fixedDeltaTime);
    }
}
