using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jumpForce;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.Moved += Move;
        _playerInput.Jumped += Jump;
    }

    private void OnDisable()
    {
        _playerInput.Moved -= Move;
        _playerInput.Jumped -= Jump;
    }

    private void Move(float horizontalMove)
    {
        _rigidbody.velocity = new Vector2(horizontalMove * _speedMove, _rigidbody.velocity.y);
    }

    private void Jump()
    {        
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
