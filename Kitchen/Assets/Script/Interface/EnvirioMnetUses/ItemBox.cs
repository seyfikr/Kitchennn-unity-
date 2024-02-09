using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour, ITakeItem
{
    [SerializeField] private ItemType item;

   
    public virtual ItemType GetItem()
    {
      
        return item;
    }

    public  void SetType(ItemType type)
    {
        item = type;
    }

 
}
