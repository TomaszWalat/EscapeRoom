using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSlotHolderScript : MonoBehaviour
{
    public bool hasItemSlot { get; protected set;  }

    public bool allSlotsFull { get; protected set; }

    public List<IItemSlotScript> slotList { get; protected set; }

    protected void FindItemSlots()
    {
        slotList = new List<IItemSlotScript>(GetComponentsInChildren<IItemSlotScript>());
        
        if(slotList.Count > 0)
        {
            hasItemSlot = true;
        }
    }

    protected void CheckIfSlotAreFull()
    {
        IItemSlotScript freeSlot = FindFreeSlot(gameObject);
        if(freeSlot != null)
        {
            allSlotsFull = false;
        }
    }

    protected IItemSlotScript FindFreeSlot(GameObject requester)
    {
        IItemSlotScript freeSlotScript = null;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (!slotList[i].isSlotFull)
            {
                freeSlotScript = slotList[i];
            }
        }
        return freeSlotScript;
    }

    protected IItemSlotScript FindSlotByName(string name)
    {
        IItemSlotScript slotScript = null;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].slotName == name)
            {
                slotScript = slotList[i];
            }
        }
        return slotScript;
    }

    protected GameObject FindObjectByTag(string tag)
    {
        GameObject temp = null;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].objectInSlot != null && slotList[i].objectInSlot.tag == tag)
            {
                temp = slotList[i].objectInSlot;
            }
        }

        return temp;
    }

    protected bool FindObject(GameObject objectToFind)
    {
        bool objectFound = false;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].objectInSlot == objectToFind)
            {
                objectFound = true;
            }
        }

        return objectFound;
    }

    protected IItemSlotScript GetSlotOfObject(GameObject objectToFind)
    {
        IItemSlotScript objectSlot = null;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].objectInSlot == objectToFind)
            {
                objectSlot = slotList[i].objectInSlot.GetComponent<IItemSlotScript>();
            }
        }

        return objectSlot;
    }

    //protected virtual Transform GetSlotTransform(GameObject requester)
    //{
    //    IItemSlotScript freeSlot = null;
    //    if (hasItemSlot)
    //    {
    //        freeSlot = FindFreeSlot(requester);
    //    }

    //    //freeSlot = m_RightHand.transform;

    //    return freeSlot;
    //}

    protected void HoldItem(GameObject item)
    {
        if (!allSlotsFull)
        {
            IItemSlotScript freeSlot = FindFreeSlot(item);

            freeSlot.HoldItem(item);

            CheckIfSlotAreFull();
            //item.GetComponent<Rigidbody>().isKinematic = true;
            //m_RightHand.GetComponent<IItemSlotScript>().HoldItem(item);
            //isRightHandOccupied = m_RightHand.GetComponent<HandSlotScript>().isSlotFull;
        }
    }

    //protected virtual GameObject GiveItem()
    //{
    //    GameObject temp = null;
    //    if (isRightHandOccupied)
    //    {
    //        isRightHandOccupied = false;
    //        temp = m_RightHand.GetComponent<IItemSlotScript>().GiveHeldItem();
    //    }
    //    return temp;
    //}

    protected void DropItem(GameObject itemToDrop)
    {
        int objectIndex = 0;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].objectInSlot == itemToDrop)
            {
                objectIndex = i;
            }
        }

        slotList[objectIndex].DropHeldItem();
    }
}
