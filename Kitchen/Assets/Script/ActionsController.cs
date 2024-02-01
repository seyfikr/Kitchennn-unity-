using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class ActionsController : MonoBehaviour
{
    private Animator anim;
    private Inverntory inventory;
    private ThirdPersonController ThirdPersonCH;
    private ItemType currentItem;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        inventory = GetComponent<Inverntory>();
        ThirdPersonCH = GetComponent<ThirdPersonController>();
    }
    public void TakeItems()
    {
        
        Ray ray =new Ray(transform.position + Vector3.up, transform.forward);
        if(Physics.Raycast(ray,out RaycastHit hit, 1))
        {
            if(hit.collider.TryGetComponent<ItemBox>(out ItemBox itemBox))
            {
                currentItem = itemBox.GetItem();
                inventory.TakeItem(itemBox.GetItem());
                anim.SetBool("Take",true);
                ThirdPersonCH.MoveSpeed = 3.5f;
            }
            else if (hit.collider.TryGetComponent<IPutItemFull>(out IPutItemFull itemPutBox))
            {
                
                    bool status = itemPutBox.PutItem(inventory.GetItem());
                    if (status == true)
                    {

                        inventory.PutItem();
                        Debug.Log("aa");
                        inventory.ClearHand();
                
                    }
                    else
                    {
                 
                    

                    //return;

                }
                
                    anim.SetBool("Take", false);
                    ThirdPersonCH.MoveSpeed = 5f;             
            }
          
        }
      

    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green; 
    //    Gizmos.DrawLine(transform.position+Vector3.up,transform.position+Vector3.up+ transform.forward);
    //}
}
