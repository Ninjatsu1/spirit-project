using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New_Inventory", menuName ="Inventory_System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    private ItemDatabaseObject database;
    public List<InventorySlot> Container = new List<InventorySlot>();
    public string savePath;
    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }
    public void AddItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                return;
            }
        }
        //Container.Add(new InventorySlot(_item, _amount));
       Container.Add(new InventorySlot(database.GetId[_item], _item, _amount));
        
    }
    public void DeleteItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].DecreaseAmount(_amount);
                return;
            
            }
           


        }

    }
    public void Save() //Kutsu tätä funktiota kun pelaaja ottaa uuden itemin
    {
        string saveData = JsonUtility.ToJson(this, true);
        Debug.Log(saveData);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }
  

    public void OnAfterDeserialize()
    {
        for(int i = 0; i < Container.Count; i++)
        {
        Container[i].item = database.GetItem[Container[i].ID];
        } //Tarkista id
    }

   public void OnBeforeSerialize()
    {

    }
}
[System.Serializable] //Displays in Unity Editor
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int amount;
    public InventorySlot(int _id, ItemObject _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public void DecreaseAmount(int value)
    {
        amount -= value;
    }
}