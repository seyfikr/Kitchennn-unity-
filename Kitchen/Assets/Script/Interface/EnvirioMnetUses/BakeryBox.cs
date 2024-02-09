using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryBox : ItemBox
{   
    [SerializeField] private Bakery bakery;
    public  bool canTake;
   public override ItemType GetItem()
    {
        if (!canTake) return ItemType.NONE;
        bakery.CoocedMeatClose();  
        canTake = false;
        return base.GetItem();
       

    }
}
