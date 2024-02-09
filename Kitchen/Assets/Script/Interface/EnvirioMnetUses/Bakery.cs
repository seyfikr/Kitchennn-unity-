using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

using UnityEngine;

public class Bakery :MonoBehaviour ,IPutItemFull
{
    private bool isFull;
    [SerializeField] private GameObject cookedItem;
    [SerializeField] private UITimer timer;
    [SerializeField] private BakeryBox bakeryBox;
    private float currentTime,cookTime=3;

    void Start()
    {
        timer.gameObject.SetActive(false);
        cookedItem.SetActive(false);
    }
    private void Update()
    {
        if (isFull)
        {
            timer.gameObject.SetActive(true);
            currentTime += Time.deltaTime;
            timer.UpdateClock(currentTime, cookTime);
            if (currentTime >= cookTime)
            {
                currentTime = 0;
                cookedItem.SetActive(true);                
                timer.gameObject.SetActive(false);
                bakeryBox.SetType(ItemType.COOKEDMEAT);
                bakeryBox.canTake = true;
                isFull = false;
          
            }
        }
    }
    public void CoocedMeatClose()
    {
        cookedItem.SetActive(false);
    }
    public bool PutItem(ItemType item)
    {
        if(item!=ItemType.MEAT) return false;
        if (isFull) return false;
        isFull = true;
      
     return true;
       
    }

   
}
