using UnityEngine;
using Zenject;

public class TimeManager : MonoBehaviour, ITimeManager
{
    [Inject]
    private SignalBus _bus;

    private int _currentDay;
    private TimeSlot _currentSlot;

    private void Start()
    {
        _currentDay = 0;
        _currentSlot = TimeSlot.Morning;
    }

    public void AddSlot()
    {
        if (_currentSlot == TimeSlot.Evening)
        {
            _currentDay++;
            _currentSlot = TimeSlot.Morning;
            _bus.Fire(new OnDayChanged(_currentDay));
        }
        else
        {
            _currentSlot++;
        }
        _bus.Fire(new OnSlotChanged(_currentSlot));
    }

    public void SetSlot(TimeSlot timeSlot)
    {
        // 真正跨天：只有当“新时段 < 旧时段”时才进第二天
        if (timeSlot < _currentSlot)
        {
            _currentDay++;
            _bus.Fire(new OnDayChanged(_currentDay));
        }
        _currentSlot = timeSlot;
        _bus.Fire(new OnSlotChanged(_currentSlot));
    }

    public int GetCurDay() => _currentDay;
    public TimeSlot GetCurSlot() => _currentSlot;
}
