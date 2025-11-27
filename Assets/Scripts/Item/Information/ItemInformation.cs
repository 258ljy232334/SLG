
using UnityEngine;
[System.Serializable]
public class ItemInformation 
{
    [SerializeField]
    protected int _id;
    [SerializeField]
    protected string _name;
    [SerializeField]
    protected Sprite _icon;
    [SerializeField]
    protected string _description;
    [SerializeField]
    protected int _price;
    [SerializeField]
    protected ItemType _type;
    [SerializeField]
    public int ID=>_id;
    public string Name => _name;
    public Sprite Icon => _icon;
    public string Description => _description;
    public int Price => _price;
    public ItemType Type => _type;
}
