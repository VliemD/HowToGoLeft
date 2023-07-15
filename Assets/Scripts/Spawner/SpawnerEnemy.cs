using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerEnemy : Spawner
{
    [SerializeField] private List<GameObject> _gameObjectsPoints;

    private Waypoint _waypoint;

    private void Start()
    {
        Respawn();        
        _waypoint.OnCreate += GetTargetPoints;
    }

    private void OnDisable()
    {
        _waypoint.OnCreate -= GetTargetPoints;        
    }

    protected override void Respawn()
    {
        _waypoint = Instantiate(Template, transform.position, Quaternion.identity).GetComponent<Waypoint>();
    }

    private List<Transform> GetTargetPoints()
    {
        List<Transform> points = new List<Transform>();

        foreach (var gameObjectPoint in _gameObjectsPoints)
            points.Add(gameObjectPoint.GetComponent<Transform>());

        return points;
    }
}
