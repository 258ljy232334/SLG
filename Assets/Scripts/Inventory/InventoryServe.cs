using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryServe : MonoBehaviour, IInventoryServe
{
    [Inject]
    private IInventoryRepository _repository;
    [Inject]
    private IInventoryManager _manager;
    private HashSet<ItemType> _dirty;

    private void LateUpdate()
    {
        if (_dirty.Count > 0)
        {
            foreach (var type in _dirty)
            {
                _manager.CallInventoryEvent(type);
            }
        }
    }
    public IReadOnlyList<ItemInstance> GetBag(ItemType type)
    {
        return _repository.GetBag(type);
    }
    public void AddItem(int id, int count = 1)
    {
        _repository.AddItem(id, count);
    }

    public bool HasItem(int id)
    {
        return _repository.HasItem(id);
    }

    public void RemoveItem(int id, int count = 1)
    {
        _repository.RemoveItem(id, count);
    }

    public void UseItem(int id)
    {
        ItemInstance item= _repository.GetItem(id);
        if (item != null)
        {
            item.UseSelf();
            _repository.RemoveItem(item.Information.ID);
        }
    }

    public void AddInventoryEvent(ItemType type)
    {
        _dirty.Add(type);
    }
}
