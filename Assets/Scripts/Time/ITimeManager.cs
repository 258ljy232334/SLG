
using System;

public interface ITimeManager 
{
    int GetCurDay();
    TimeSlot GetCurSlot();
    void AddSlot();
    void SetSlot(TimeSlot timeSlot);
   
}
