using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    public List<int> quantityList = new List<int>();
    public GameObject inventoryPanel;
    private List<InventorySlot> slotList = new List<InventorySlot>();

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public void Start()
    {
        foreach (InventorySlot child in inventoryPanel.GetComponentsInChildren<InventorySlot>())
        {
            slotList.Add(child);
        }
    }

    public void AddItem(Item itemAdded, int quantityAdded)
    {
        if (itemAdded.Stackable)
        {
            if (itemList.Contains(itemAdded))
            {
                quantityList[itemList.IndexOf(itemAdded)] = quantityList[itemList.IndexOf(itemAdded)] + quantityAdded;
            }
            else
            {
                if (itemList.Count < slotList.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(quantityAdded);
                }
            }
        }
        else
        {
            for (int i = 0; i < quantityAdded; i++)
            {
                if (itemList.Count < slotList.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(1);
                }
            }
        }

        UpdateInventoryUI();
    }

    public void RemoveItem(Item itemRemoved, int quantityRemoved)
    {
        if (itemRemoved.Stackable)
        {
            if (itemList.Contains(itemRemoved))
            {
                quantityList[itemList.IndexOf(itemRemoved)] = quantityList[itemList.IndexOf(itemRemoved)] - quantityRemoved;

                if (quantityList[itemList.IndexOf(itemRemoved)] <= 0)
                {
                    int index = itemList.IndexOf(itemRemoved);
                    quantityList.RemoveAt(index);
                    itemList.RemoveAt(index);
                }
            }
        }
        else
        {
            for (int i = 0; i < quantityRemoved; i++)
            {
                if (itemList.Contains(itemRemoved))
                {
                    int index = itemList.IndexOf(itemRemoved);
                    quantityList.RemoveAt(index);
                    itemList.RemoveAt(index);
                }
            }
        }

        UpdateInventoryUI();
    }

    // --------------------------------------------------UI------------------------------------------------

    public void UpdateInventoryUI()
    {
        int ind = 0;

        foreach (InventorySlot slot in slotList)
        {
            if (ind < itemList.Count)
            {
                slot.UpdateSlot(itemList[ind], quantityList[ind]);
                ind++;
            }
            else
            {
                slot.UpdateSlot(null, 0);
            }
        }
    }
}