using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private float _horizontalMove;
    private bool _facingRight = false;
    private bool _isGrounded = false;

    public event UnityAction<float> OnMove;
    public event UnityAction OnJump;

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            OnJump?.Invoke();

        if (_horizontalMove < 0 && _facingRight)
            Flip();
        else if (_horizontalMove > 0 && !_facingRight)
            Flip();
    }

    private void FixedUpdate()
    {
        OnMove?.Invoke(_horizontalMove);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PlatformEffector2D>())
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
