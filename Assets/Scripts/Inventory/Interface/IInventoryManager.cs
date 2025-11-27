
using System;
using System.Collections.Generic;

public interface IInventoryManager 
{
    void AddItem(int id, int count = 1);
    void RemoveItem(int id, int count = 1);
    void UseItem(int id);
    bool HasItem(int id);
    void CallInventoryEvent(ItemType type);
    IReadOnlyList<ItemInstance> GetBag(ItemType type);
    event Action<ItemType> OnInventoryChanged;
    ItemInformation GetItemInformation(int id);
}
