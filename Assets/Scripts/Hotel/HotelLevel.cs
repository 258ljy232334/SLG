using System;


public class HotelLevel 
{
    private int _level;
    public event Action<int> OnAddLevel;
    public HotelLevel(int level=1)
    {
        _level= level;
        OnAddLevel?.Invoke(_level);
    }
    public int GetCurrentLevel()
    {
        return _level;
    }
    public void AddLevel()
    {
        _level++;
        OnAddLevel?.Invoke(_level);
    }
}
