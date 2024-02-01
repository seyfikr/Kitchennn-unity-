using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CutBoard : MonoBehaviour, IPutItemFull
{
    [SerializeField] private List<ObjectnType> itemToHold = new List<ObjectnType>();
    private ItemType currentType;
    private void Start()
    {
        currentType = ItemType.NONE;
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
    [SerializeField] private ItemType item;

}
