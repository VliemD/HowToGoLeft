using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _speedMove;

    public void Initialize()
    {        
        _enemy.Moved += Move;
    }

    public void Dispose()
    {
        _enemy.Moved -= Move;
    }

    private void Move(float directionMove)
    {
        _rigidbody.velocity = new Vector2(directionMove * _speedMove, _rigidbody.velocity.y);
    }
}
