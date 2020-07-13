using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New_Equipment_Object", menuName = "Inventory_System/Items/Equipment")]

public class EquipmentObject : ItemObject
{
    public int attackStat;

    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
