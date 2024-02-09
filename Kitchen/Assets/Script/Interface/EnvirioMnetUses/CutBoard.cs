using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CutBoard : Functionanlity, IPutItemFull
{
    [SerializeField] private List<ObjectnType> itemToHold = new List<ObjectnType>();
    private ItemType currentType;
    [SerializeField] private ItemType item;
    private void Start()
    {
        currentType = ItemType.NONE;
        timer.gameObject.SetActive(false);
    }
    public override ItemType Proces()
    {
        if (currentType == ItemType.NONE) return ItemType.NONE;
        //base.Proces();
        procesStarted = true;
        if (procesStarted == true && timer.gameObject.activeSelf == false)
        {
            timer.gameObject.SetActive(true);
        }       
        currentTime += Time.deltaTime;
        timer.UpdateClock(currentTime, maxTime);
        if (currentTime >= maxTime)
        {
            procesStarted = false;
            timer.gameObject.SetActive(false);
            currentTime = 0;
            timer.UpdateClock(currentTime, maxTime);

            switch (currentType)
            {
                case ItemType.TOMATO:
                    
                    return ItemType.SILICETOMATO;
                
                case ItemType.LETTUCE:
                 
                    return ItemType.SILICELETTUCE;
                   
                case ItemType.CHEESE:
               
                    return ItemType.SILICECHEESE;
                 
                case ItemType.BREAD:
                   
                    return ItemType.SILICEBREAD;
                   
                case ItemType.MEAT:
                   
                    return ItemType.COOKEDMEAT;
                   
                default:
                    return ItemType.NONE;
                   
            }          
        }
      
        return ItemType.NONE;   
    }

    public override void ClearObject()
    {

       base.ClearObject();
        currentType = ItemType.NONE;
        itemToHold.ForEach(obj => obj.item.SetActive(false));
    }
    public bool PutItem(ItemType type)
    {    
        if (currentType != ItemType.NONE) return false;
        currentType = type;
        foreach (ObjectnType itemHold in itemToHold)
        {
            if (itemHold.type != type)
            {
                itemHold.item.SetActive(false);

            }
            else
            {
                itemHold.item.SetActive(true);

            }
        }
        return true;
    }
    //private bool FilterItem()
    //{
    //    switch (currentType)
    //    {
    //        case ItemType.TOMATO:
    //            return ItemType.SILICETOMATO;
    //        case ItemType.LETTUCE:
    //            return ItemType.SILICELETTUCE;
    //        case ItemType.CHEESE:
    //            return ItemType.SILICECHEESE;
    //        case ItemType.BREAD:
    //            return ItemType.SILICEBREAD;
    //        case ItemType.MEAT:
    //            return ItemType.COOKEDMEAT;
    //        default:
    //            break;
    //    }
    //    return false;
    //}


}
