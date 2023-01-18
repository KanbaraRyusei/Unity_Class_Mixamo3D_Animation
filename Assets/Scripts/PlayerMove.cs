using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float _walkSpeed = 0.75f;

    [SerializeField]
    private float _runSpeed = 2f;

    private bool _isRun = false;
    private Rigidbody _rb = null;
    private Animator _anim = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Run();
    }

    private void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        var speed = _isRun ? _runSpeed : _walkSpeed;

        if(0 != h || 0 != v)
        {
            _anim.SetFloat("Speed", speed);
        }
        else
        {
            _anim.SetFloat("Speed", 0);
            return;
        }

        _rb.velocity = new Vector3(h * speed, 0, v * speed);
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isRun = !_isRun;
        }
    }
}
