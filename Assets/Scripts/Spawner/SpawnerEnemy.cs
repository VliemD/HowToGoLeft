using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Spawner
{
    [SerializeField] private List<Transform> _points;

    private Enemy _enemy;   

    private void Start()
    {
        Respawn();
    }

    protected override void Respawn()
    {
        _enemy = Instantiate(Template, transform.position, Quaternion.identity).GetComponent<Enemy>();
    
        _enemy.Initialize(_points);       
    }
}
