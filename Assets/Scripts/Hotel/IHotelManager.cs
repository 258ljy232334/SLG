using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHotelManager 
{
    HotelValue CurrentMoney { get; }
    HotelValue CurrentSatisfaction { get; }
    HotelLevel CurrentLevel {  get; }
    void AddMoney(int money);
    void CostMoney(int money);
    void CostSatisfaction(int satisfaction);
    void AddSatisfaction(int satisfaction);
    bool HasEnoughMoney(int money);
    bool HasEnoughSatisfaction(int satisfaction);

}
