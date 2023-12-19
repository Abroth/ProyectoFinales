using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBag : MonoBehaviour, IInventoryObject
{

    [SerializeField] public List<string> invetoryBag = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddObjectToInventory(string key)
    {
        invetoryBag.Add(key);
        Debug.Log($"Object {key} added to Inventory");
    }
}
