

using System.Collections.Generic;

public interface IInventoryServe 
{
    void AddItem(int id,int count=1);
    void RemoveItem(int id, int count=1);
    void UseItem(int id);
    bool HasItem(int id);
    void AddInventoryEvent(ItemType type);
    IReadOnlyList<ItemInstance> GetBag(ItemType type);
}
