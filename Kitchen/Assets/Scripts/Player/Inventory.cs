using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ObjectnType
{
    public GameObject item;
    public ItemType type;
}
public class Inventory : MonoBehaviour
{
    Animator anim;
    [SerializeField] private List<ObjectnType> itemsToHold = new List<ObjectnType>(); 
    private ItemType currentType;
    public ItemType CurrentType { get { return currentType; } }
    private void Start()
    {
        currentType = ItemType.NONE;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Debug.Log(currentType);
        if(currentType == ItemType.NONE)
        {
            anim.SetBool("Take", false);
            //ThirdPersonCH.MoveSpeed = 3.5f;
        }
        if (currentType != ItemType.NONE)
        {
            anim.SetBool("Take", true);
            //ThirdPersonCH.MoveSpeed = 3.5f;
        }
    }
    public void TakeItem(ItemType type)
    {
        if (currentType != ItemType.NONE) return;
        currentType = type;
        foreach(ObjectnType itemHold in itemsToHold)
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
    }
    public ItemType PutItem()
    {
        if (currentType == ItemType.NONE) return ItemType.NONE; 
        return currentType;

    }
    public void ClearHand()
    {
        currentType = ItemType.NONE; 
        itemsToHold.ForEach(obj => obj.item.SetActive(false));
    }

    public ItemType GetItem()
    {
        return currentType;
    }
}
