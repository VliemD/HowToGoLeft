using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _offset = 0.2f;
    [SerializeField] private int _damage = 1;
    [SerializeField] private Waypoint _waypoint;
    [SerializeField] private EnemyMovement _movement;

    private float _directionMove;
    private Transform _target;
    
    public event Action<float> Moved;
    public event Func<Transform, Transform> ReachedTarget;

    public void Initialize(List<Transform> points)
    {
        _waypoint.Initialize(points);
        _movement.Initialize();
        _target = ReachedTarget?.Invoke(_target);
        SetDirection();             
    }

    private void OnDisable()
    {
        _waypoint.Dispose();
        _movement.Dispose();
    }   

    private void Update()
    {
        if (transform.position.x < _target.position.x + _offset &&
            transform.position.x > _target.position.x - _offset)
        {
            SetNextTarget();
            SetDirection();
        }        
    }

    private void FixedUpdate()
    {
        Moved?.Invoke(_directionMove);
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
        _target = ReachedTarget?.Invoke(_target);
    }

    private void SetDirection()
    {
        _directionMove = _target.position.x > transform.position.x ? 1 : -1;
        Flip();
    }      

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
