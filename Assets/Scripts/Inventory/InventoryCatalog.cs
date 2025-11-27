using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCatalog : MonoBehaviour, IInventoryCatalog
{
    [SerializeField]
    private ItemList _itemList;
    private Dictionary<int, ItemInformation> _itemDictionary;
    private void OnValidate()
    {
        if( _itemList != null )
        {
            _itemDictionary=new Dictionary<int, ItemInformation>();
           foreach(var item in _itemList.ConsumableList )
            {
                _itemDictionary.Add(item.ID, item);
            }
           foreach(var item in _itemList.CollectionList)
            {
                _itemDictionary.Add(item.ID, item);
            }
            foreach (var item in _itemList.MaterialList)
            {
                _itemDictionary.Add(item.ID, item);
            }
            foreach (var item in _itemList.FigurineList)
            {
                _itemDictionary.Add(item.ID, item);
            }

        }
    }
    public ItemInformation GetItemInformation(int id)
    {
       if(_itemDictionary.TryGetValue(id,out var information))
       {
            return information;
       }
       return null;
    }
}
