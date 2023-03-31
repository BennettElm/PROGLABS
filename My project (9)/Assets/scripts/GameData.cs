using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Playables;


public class GameData : MonoBehaviour
{
    public int coins;
    public bool hasCoin;

    public Inventory inventory = new Inventory();




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveToJson();
        }
        
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
        }
    }

    public void SaveToJson()
    {
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("Saved Game");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        string inventortData = System.IO.File.ReadAllText(filePath);

        inventory = JsonUtility.FromJson<Inventory>(inventortData);
        Debug.Log("Loaded Save");
    }
 
}
[System.Serializable]
public class Inventory
{
    public int Coin;
    
}

