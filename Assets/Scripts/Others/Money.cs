using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _price;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Wallet>())
        {
            Destroy(gameObject);
            other.GetComponent<Wallet>().Accept(_price);
        }
    }
}
