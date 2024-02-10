using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ActionController : MonoBehaviour
{
    private Animator anim;
    private Inventory inventory;
    private ThirdPersonController ThirdPersonCH;
    private Functionality currentFunction;

    private bool isWorking = false;
    bool isTouching = false;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        inventory = GetComponent<Inventory>();
        ThirdPersonCH = GetComponent<ThirdPersonController>();

    }
    private void Update()
    {


        if (isTouching)
        {
            if (!isWorking)
            {

                StartProcessAction();
            }
            else
            {
                DoActionProces();
            }
        }
        else if (!isTouching)
        {
            if (isWorking)
            {
                currentFunction?.ResetTimer();

            }
        }
    }
    public void OneTouch()
    {
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 1))
        {
            if (hit.collider.TryGetComponent<ItemBox>(out ItemBox itemBox))
            {
                inventory.TakeItem(itemBox.GetItem());
                //anim.SetBool("Take", true);
                ////ThirdPersonCH.MoveSpeed = 3.5f;
            }
            //eti al?rken animasyon hatas?burdan kaynakl? ??z
            if (hit.collider.TryGetComponent<IPutItemFull>(out IPutItemFull itemPutBox))
            {

                bool status = itemPutBox.PutItem(inventory.GetItem());
                if (status == true)
                {
                    inventory.PutItem();
                    inventory.ClearHand();

                }
                //anim.SetBool("Take", false);
                //ThirdPersonCH.MoveSpeed = 5f;
            }

        }

    }
    //public void OneTouch2()
    //{
    //    Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
    //    if (Physics.Raycast(ray, out RaycastHit hit, 1))
    //    {

    //         if (hit.collider.TryGetComponent<IPutItemFull>(out IPutItemFull itemPutBox))
    //        {

    //            bool status = itemPutBox.PutItem(inventory.GetItem());
    //            if (status == true)
    //            {
    //                inventory.PutItem();
    //                inventory.ClearHand();

    //                Debug.Log("b");
    //            }

    //            anim.SetBool("Take", false);
    //            ThirdPersonCH.MoveSpeed = 5f;
    //        }
    //    }
    //}
    private void StartProcessAction()
    {

        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 1))
        {
            if (hit.collider.TryGetComponent<Functionality>(out Functionality itemProcess))
            {


                currentFunction = itemProcess;
                isWorking = true;
                anim.SetBool("Take", true);
                ThirdPersonCH.MoveSpeed = 3.5f;
            }


        }

    }
    private void DoActionProces()
    {
        if (!isWorking)
        {
            return;
        }
        ItemType item = currentFunction.Process();
        if (item != ItemType.NONE)
        {
            currentFunction.ClearObject();
            inventory.TakeItem(item);
            isWorking = false;
        }
        inventory.TakeItem(currentFunction.Process());
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green; 
    //    Gizmos.DrawLine(transform.position+Vector3.up,transform.position+Vector3.up+ transform.forward);
    //}
    public void PointerDown()
    {
        isTouching = true;
        //Debug.Log
        //    (isTouching);
    }
    public void PointerUp()
    {
        isTouching = false;
        //Debug.Log
        //    (isTouching);
    }


}
