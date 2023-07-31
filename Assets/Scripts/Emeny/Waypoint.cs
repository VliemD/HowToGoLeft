using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private List<Transform> _targets;

    public void Initialize(List<Transform> points)
    {
        _targets = points;      
        _enemy.ReachedTarget += GetNextTarget;
    }

    public void Dispose()
    {
        _enemy.ReachedTarget -= GetNextTarget;
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
