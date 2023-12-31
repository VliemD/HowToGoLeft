using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    private int _speed;
    private int _direction;
    private int _jump;

    private void Start()
    {
        _speed = Animator.StringToHash("Speed");
        _direction = Animator.StringToHash("Direction");
        _jump = Animator.StringToHash("IsJump");
    }

    private void Update()
    {
        if (_rigidbody.velocity.y != 0)
        {
            _animator.SetBool(_jump, true);
            _animator.SetFloat(_direction, _rigidbody.velocity.y > 0 ? 1 : 0);
        }
        else
        {
            _animator.SetBool(_jump, false);
            _animator.SetFloat(_direction, 0);
            _animator.SetFloat(_speed, Mathf.Abs(_rigidbody.velocity.x));
        }       
    }
}
