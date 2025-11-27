using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemList",
    menuName ="SO_Assets/Item/ItemList")]
public class ItemList : ScriptableObject
{
    [SerializeField]
    private List<CollectionInformation> _collectionList;
    [SerializeField]
    private List<FigurineInformation> _figurineList;
    [SerializeField]
    private List<ConsumableInformation> _consumableList;
    [SerializeField]
    private List<MaterialInformation> _materialList;
    public List<CollectionInformation> CollectionList => _collectionList;
    public List<FigurineInformation> FigurineList => _figurineList;
    public List<ConsumableInformation> ConsumableList => _consumableList;
    public List<MaterialInformation> MaterialList => _materialList;
}
