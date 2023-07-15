using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyAnimation : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private int _speed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _speed = Animator.StringToHash("Speed");       
    }

    private void Update()
    {
        if (_rigidbody.velocity.x != 0)
        {
            _animator.SetFloat(_speed, Mathf.Abs(_rigidbody.velocity.x));
        }
        else
        {            
            _animator.SetFloat(_speed, _rigidbody.velocity.x);
        }
    }
}
