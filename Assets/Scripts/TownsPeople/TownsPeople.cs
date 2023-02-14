using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownsPeople : MonoBehaviour
{
    [SerializeField]
    float _speed;

    [SerializeField]
    Transform _target;

    Rigidbody _rb;
    bool _isTalking;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var forward = transform.position - _target.transform.position;
        forward.y = 0;

        var right = Quaternion.LookRotation(forward) * Quaternion.Euler(0, 90, 0);
        transform.rotation = right;

        transform.LookAt(transform.position + forward);

        var speed = _isTalking ? 0f : _speed;
        _rb.velocity = transform.forward * speed;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            _isTalking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isTalking = false;
        }
    }
}
