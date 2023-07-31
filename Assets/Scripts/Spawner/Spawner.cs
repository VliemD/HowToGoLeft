using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject Template;

    protected abstract void Respawn();
        
}
