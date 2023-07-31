using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _price;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Wallet wallet))
        {
            wallet.Accept(_price);
            Destroy(gameObject);
        }
    }
}
