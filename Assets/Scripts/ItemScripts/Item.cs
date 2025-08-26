
using UnityEngine;



public class Item : ScriptableObject
{
    public string itemName;

  
    public int price;

    
    public bool Stackable;

   
    public Sprite itemIcon;
    
    public virtual void Use()
    {
      
    }
}
