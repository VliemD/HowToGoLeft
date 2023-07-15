using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMoney : Spawner
{
    protected override void Respawn()
    {
        Instantiate(Template, transform.position, Quaternion.identity);
    }

    private void Awake()
    {
        Respawn();
    }
}
