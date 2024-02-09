using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Functionanlity : MonoBehaviour
{
    public  float maxTime=2;
    public float currentTime;
    public UITimer timer;
    public bool procesStarted;
    public virtual ItemType Proces()
    {
        return ItemType.NONE;
    }
    public virtual void ClearObject()
    {

    }
    public void ResetTimer()
    {

        currentTime = 0;
        timer.gameObject.SetActive(false);
        timer.UpdateClock(currentTime, maxTime);
    }
}
