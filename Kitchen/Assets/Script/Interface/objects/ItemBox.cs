using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour, ITakeItem
{
    [SerializeField] private ItemType item;
    public ItemType GetItem()
    {
        return item;
    }

 
}
