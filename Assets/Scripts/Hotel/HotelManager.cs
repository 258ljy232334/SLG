using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelManager : MonoBehaviour, IHotelManager
{
    private HotelLevel _level;
    private HotelValue _currentMoney;
    private HotelValue _currentSatisfaction;

    public HotelLevel CurrentLevel => _level;
    public HotelValue CurrentMoney => _currentMoney;
    public HotelValue CurrentSatisfaction => _currentSatisfaction;


    private void Start()
    {
        _level = new HotelLevel();
        _currentMoney = new HotelValue();
        _currentSatisfaction = new HotelValue();
    }
    public void AddMoney(int money)
    {
        _currentMoney.AddValue(money);
    }
    public void CostMoney(int money)
    {
       _currentMoney.ReduceValue(money);
    }
    public void AddSatisfaction(int satisfaction)
    {
        _currentSatisfaction.AddValue(satisfaction);
    }
    public void CostSatisfaction(int satisfaction)
    {
        _currentSatisfaction.ReduceValue(satisfaction);
    }
    public bool HasEnoughMoney(int money)
    {
        return _currentMoney.HasEnoughValue(money);
    }
    public bool HasEnoughSatisfaction(int satisfaction)
    {
        return _currentSatisfaction.HasEnoughValue(satisfaction);
    }
}
       
