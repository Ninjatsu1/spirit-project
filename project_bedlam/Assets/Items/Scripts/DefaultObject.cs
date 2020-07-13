using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New_Default_Object", menuName = "Inventory_System/Items/Default")]
public class DefaultObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
