using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _maxCapacity;

    private int _currentOccupancy;

    public event UnityAction<int> MoneyChanged;

    public void Accept(int coins)
    {
        if (coins + _currentOccupancy < _maxCapacity)
        {
            _currentOccupancy += coins;
            MoneyChanged?.Invoke(_currentOccupancy);
        }
    }
}
