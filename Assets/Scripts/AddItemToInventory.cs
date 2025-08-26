using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class AddItemToInventory : MonoBehaviour
{

   
    public Item specificItem;

   
    public int specificQuant;

   
   public void AddSpecificItem()
    {
        Inventory.instance.AddItem(specificItem, specificQuant);
    }

 
}
