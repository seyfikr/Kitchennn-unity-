using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
[System.Serializable]
public class ObjectnType
{
    public GameObject item;
    public ItemType type;
}

public class Inverntory : MonoBehaviour
{
    [SerializeField] private List<ObjectnType> itemToHold=new List<ObjectnType>();
    private ItemType currentType;
    private void Start()
    {
        currentType = ItemType.NONE;
    }
    public void TakeItem(ItemType type)
    {

        //if(currentType == ItemType.PLATE)
        //{

        //}
        if (currentType != ItemType.NONE) return;
        currentType = type;
        foreach(ObjectnType itemHold in itemToHold)
        {
            if(itemHold.type != type)
            {
                itemHold.item.SetActive(false);
              
            }
            else
            {
                itemHold.item.SetActive(true);
                
            }
        }
    }
    public ItemType PutItem()
    {
        if (currentType == ItemType.NONE) return ItemType.NONE;
        
        itemToHold.ForEach(obj => obj.item.SetActive(false));
        return currentType;
    }
    public void ClearHand()
    {
        currentType = ItemType.NONE;
    }
    public ItemType GetItem()
    {
        return currentType;
      
    }
}
