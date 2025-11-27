using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelValue 
{
    private int _currentValue;
    public event Action<int> OnValueChanged;
    public HotelValue(int value = 0)
    {
        _currentValue = value;
        OnValueChanged?.Invoke(_currentValue);
    }
    public int GetCurrentValue()
    {
        return _currentValue;
    }
    public void ReduceValue(int value)
    {
        _currentValue =Mathf.Max(0,_currentValue-value);
        OnValueChanged?.Invoke(_currentValue);
    }
    public void AddValue(int value)
    {
        _currentValue += value;
        OnValueChanged?.Invoke(_currentValue);
    }
    public bool HasEnoughValue(int value)
    {
        return _currentValue >= value;
    }
}
