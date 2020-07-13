using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=aPXvoWVabPY&t=76s
public enum ItemType
{
    Default,
    Potion,
    Equipment,
    Keys
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
