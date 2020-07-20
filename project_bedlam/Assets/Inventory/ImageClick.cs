using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageClick : MonoBehaviour
{
    public InventoryObject Inventory;
    public ItemDatabaseObject Database;
    private string itemName;
    public void Delete()
    {
        var item = GetComponent<Item>();

        Debug.Log(item);
        Inventory.DeleteItem(item.item, 1);
        Inventory.Save();
    }
}
