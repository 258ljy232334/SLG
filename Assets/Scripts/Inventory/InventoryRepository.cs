using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryRepository : MonoBehaviour, IInventoryRepository
{
    private IInventoryServe _serve;
    private IInventoryCatalog _catalog;
    //底层容器
    private readonly List<ItemInstance>[] _lists = new List<ItemInstance>[(int)ItemType.COUNT];
    private readonly Dictionary<int, ItemInstance>[] _dicts = new Dictionary<int, ItemInstance>[(int)ItemType.COUNT];
    private readonly IReadOnlyList<ItemInstance>[] _listRo = new IReadOnlyList<ItemInstance>[(int)ItemType.COUNT];
    

    [Inject]
    public void Construct(IInventoryCatalog catalog,IInventoryServe serve)
    {
        _catalog = catalog;
        _serve = serve;
        InitializeBag();
    }
    //初始化背包
    private void InitializeBag()
    {
       for(int i=0;i<(int)ItemType.COUNT;i++)
        {
            _lists[i] = new List<ItemInstance>();
            _dicts[i] = new Dictionary<int, ItemInstance>();
            _listRo[i] = _lists[i];
        }
    }
    //按索引取列表
    private ref List<ItemInstance> ListOf(ItemType t) => ref _lists[(int)t];
    private ref Dictionary<int, ItemInstance> DictOf(ItemType t) => ref _dicts[(int)t];
    public void AddItem(int id, int count=1)
    {
        ItemInformation info=_catalog.GetItemInformation(id);
        if(info==null)
        {
            return;
        }
        ref var list = ref ListOf(info.Type);
        ref var dict = ref DictOf(info.Type);
        if (dict.TryGetValue(id, out var item))
        {
            item.AddCount(count);
        }
        else
        {
            item=new ItemInstance(info, count);
            dict.Add(id, item);
            list.Add(item);
        }
        _serve.AddInventoryEvent(info.Type);
    }

    public bool HasItem(int id)
    {
        ItemInformation info = _catalog.GetItemInformation(id);
        if (info == null)
        {
            return false;
        }
        ref var dict = ref DictOf(info.Type);
        return dict.ContainsKey(id);
    }

    public void RemoveItem(int id, int count=1)
    {
        ItemInformation info = _catalog.GetItemInformation(id);
        if (info == null)
        {
            return;
        }
        ref var list = ref ListOf(info.Type);
        ref var dict = ref DictOf(info.Type);
        if (dict.TryGetValue(id, out var item))
        {
            item.RemoveCount(count);
            if(item.Count == 0)
            {
                list.Remove(item);
                dict.Remove(id);
            }
        }
        _serve.AddInventoryEvent(info.Type);
    }

    public IReadOnlyList<ItemInstance> GetBag(ItemType type)
    {
        return _listRo[(int)type];
    }

    public ItemInstance GetItem(int id)
    {
        ItemInformation info = _catalog.GetItemInformation(id);
        if (info == null)
        {
            return null;
        }
        ref var dict = ref DictOf(info.Type);
        if (dict.TryGetValue(id, out var item))
        {
            return item;
        }
        return null;
    }
}
