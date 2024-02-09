using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField] private Image Timer;
    public void UpdateClock(float amount,float maxValue)
    {
        Timer.fillAmount=amount/maxValue;
    }
}
