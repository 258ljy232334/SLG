using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryManager : MonoBehaviour, IInventoryManager
{
    [Inject]
    private IInventoryCatalog _catalog;
    [Inject]
    private IInventoryServe _serve;


    public event Action<ItemType> OnInventoryChanged;

    public void AddItem(int id, int count = 1)
    {
       _serve.AddItem(id, count);
    }
    public void CallInventoryEvent(ItemType type)
    {
        OnInventoryChanged?.Invoke(type);
    }

    public IReadOnlyList<ItemInstance> GetBag(ItemType type)
    {
        return  _serve.GetBag(type);
    }

    public ItemInformation GetItemInformation(int id)
    {
        return _catalog.GetItemInformation(id);
    }

    public bool HasItem(int id)
    {
        return _serve.HasItem(id);
    }

    public void RemoveItem(int id, int count = 1)
    {
        _serve.RemoveItem(id, count);
    }

    public void UseItem(int id)
    {
        _serve.RemoveItem(id);
    }
}
