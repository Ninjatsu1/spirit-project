using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayInventory : MonoBehaviour
{
    public InventoryObject Inventory;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMNS;
    public int Y_SPACEBETWEEN_ITEMS;
    public int X_START;
    public int Y_START;
    //Represents a collection of keys and values.
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }
    void Update()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        for(int i = 0; i < Inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(Inventory.Container[i]))
            {
                itemsDisplayed[Inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = Inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                //world position
                var obj = Instantiate(Inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                //local position
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = Inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(Inventory.Container[i], obj);
            }
        }
    }
    public void CreateDisplay()
    {
        for(int i = 0; i < Inventory.Container.Count; i++)
        {
            //world position
            var obj = Instantiate(Inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            //local position
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = Inventory.Container[i].amount.ToString("n0");
        }
    }
    public Vector3 GetPosition(int i) //Get position of item
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM *(i % NUMBER_OF_COLUMNS)), Y_START + (-Y_SPACEBETWEEN_ITEMS) * (i/NUMBER_OF_COLUMNS), 0f);
    }
}
