using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class FigurineInformation : ItemInformation
{
    [SerializeField]
    protected int _artisticVibe;    //艺术气息
    [SerializeField]
    protected int _naturalVibe; //自然气息
    [SerializeField]
    protected int _livedVibe;   //生活气息
    [SerializeField]
    protected int _estimatedValue;//预估价值

    public int ArtisticVibe => _artisticVibe;
    public int NaturalVibe => _naturalVibe;
    public int LivedVibe => _livedVibe;
    public int EstimatedValue => _estimatedValue;
}
