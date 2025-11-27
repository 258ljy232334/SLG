//存入仓库的实例
using UnityEngine;

public class ItemInstance 
{
    protected ItemInformation _information;
    protected int _count;

    public ItemInformation Information => _information;
    public int Count => _count;

    public ItemInstance(ItemInformation itemInformation,int count=1)
    {
        _information = itemInformation;
        _count = count;
    }
    public virtual void AddCount(int count)
    {
        _count += count;
    }
    public virtual void RemoveCount(int count)
    {
        _count=Mathf.Max(0,_count- count);
    }
    public virtual void UseSelf()
    {
    }
}
