
using UnityEngine;
[CreateAssetMenu(fileName ="New_Key_object", menuName ="Inventory_System/Keys")]
public class KeyObject : ItemObject
{


    public void Awake()
    {
        type = ItemType.Keys;
    }
}
