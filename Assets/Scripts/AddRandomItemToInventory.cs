using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddRandomItemToInventory : MonoBehaviour
{
  
    
    public List<Item> itemsToGive = new List<Item>();

   
    public int minimumItemsToGive = 1;

    
    public int maximumItemsToGive = 1;


  
    public void AddRandomItem()
    {
        Inventory.instance.AddItem(itemsToGive[Random.Range(0, itemsToGive.Count)], Random.Range(minimumItemsToGive, maximumItemsToGive));
    }

}
