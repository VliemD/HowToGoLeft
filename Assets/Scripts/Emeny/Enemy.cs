using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _offset = 0.2f;
    [SerializeField] private int _damage = 1;
    private float _directionMove;
    private bool _facingRight = false;
    private Transform _target;

    public event UnityAction<float> OnMove;
    public event Func<Transform,Transform> OnReachingTarget;

    private void Start()
    {
        StartCoroutine(LoadingOnWaitSecond());        
    }

    private IEnumerator LoadingOnWaitSecond()
    {
        yield return null;
        _target = OnReachingTarget?.Invoke(_target);
        SetDirection();
    }

    private void Update()
    {
        if (_target == null)
            return;

        if (transform.position.x < _target.position.x + _offset &&
            transform.position.x > _target.position.x - _offset)
        {
            SetNextTarget();
            SetDirection();
        }

        if (_directionMove < 0 && _facingRight)
            Flip();
        else if (_directionMove > 0 && !_facingRight)
            Flip();
    }

    private void FixedUpdate()
    {
        OnMove?.Invoke(_directionMove);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }
    }

    private void SetNextTarget()
    {
        _target = OnReachingTarget?.Invoke(_target);
    }

    private void SetDirection()
    {
        _directionMove = _target.position.x > transform.position.x ? 1 : -1;
    }      

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
