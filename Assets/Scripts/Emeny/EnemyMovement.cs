using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private Rigidbody2D _rigidbody;
    private Enemy _enemy;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemy = GetComponent<Enemy>();
        _enemy.OnMove += Move;
    }

    private void OnDisable()
    {
        _enemy.OnMove -= Move;
    }

    public void Move(float directionMove)
    {
        _rigidbody.velocity = new Vector2(directionMove * _speedMove, _rigidbody.velocity.y);
    }
}
