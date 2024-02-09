using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
  
    public LayerMask ClickableLayer;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ClickableLayer))
            {
                IControl control = hit.collider.GetComponent<IControl>();
                if(control != null)
                {
                    control.Click();
                }
            }
          


        }
    }
}
