using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private List<Transform> _targets;
    private Enemy _enemy;

    public event Func<List<Transform>> OnCreate;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _targets = OnCreate?.Invoke();        
        _enemy.OnReachingTarget += GetNextTarget;
    }

    private void OnDisable()
    {
        _enemy.OnReachingTarget -= GetNextTarget;
    }

    private Transform GetNextTarget(Transform currentTarget)
    {
        if (currentTarget == null)
            return _targets[0];

        int index = _targets.IndexOf(currentTarget);

        index++;

        if (index >= _targets.Count)
            index = 0;

        return _targets[index];
    }
}
