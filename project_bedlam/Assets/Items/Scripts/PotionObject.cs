using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New_Potion_Object", menuName = "Inventory_System/Items/Potion")]

public class PotionObject : ItemObject
{
    public int restoreHealth;
    public void Awake()
    {
        type = ItemType.Potion;
    }
}
