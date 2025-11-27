
using System.Collections.Generic;

public interface IInventoryRepository
{
    void AddItem(int id, int count=1);
    void RemoveItem(int id, int count=1);
    bool HasItem(int id);
    IReadOnlyList<ItemInstance> GetBag(ItemType type);
    ItemInstance GetItem(int id);
}
