using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.OnMove += Move;
        _playerInput.OnJump += Jump;
    }

    private void OnDisable()
    {
        _playerInput.OnMove -= Move;
        _playerInput.OnJump -= Jump;
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
