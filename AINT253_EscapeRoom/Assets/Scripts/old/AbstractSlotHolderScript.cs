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
            //Debug.Log("I am: " + gameObject);
            //Debug.Log("I have slots: " + hasItemSlot);
        }
    }

    protected void CheckIfSlotAreFull()
    {
        IItemSlotScript freeSlot = FindFreeSlot(gameObject);
        if(freeSlot != null)
        {
            allSlotsFull = false;
        }
        else
        {
            allSlotsFull = true;
        }
        //Debug.Log("I am: " + gameObject);
        //Debug.Log("I am full: " + allSlotsFull);


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

    public bool FindObject(GameObject objectToFind)
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

    public IItemSlotScript GetSlotOfObject(GameObject objectToFind)
    {
        IItemSlotScript objectSlot = null;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].objectInSlot == objectToFind)
            {
                objectSlot = slotList[i];
                //Debug.Log("found the object's slot");
            }
        }

        return objectSlot;
    }

    public int GetIndexOfSlot(IItemSlotScript slot)
    {
        int slotIndex = -1;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i] == slot)
            {
                slotIndex = i;
            }
        }

        return slotIndex;
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
        }
    }

    protected GameObject GiveItem(int slotIndex)
    {
        GameObject temp = null;
        if (slotList[slotIndex].isSlotFull)
        {
            temp = slotList[slotIndex].GiveHeldItem();
            CheckIfSlotAreFull();
        }
        return temp;
    }

    protected void DropItem(GameObject itemToDrop)
    {
        if(FindObject(itemToDrop))
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

            CheckIfSlotAreFull();
        }
    }

    protected void PrintSlotList()
    {
        Debug.Log("");
        Debug.Log("##### printing starting #####");
        Debug.Log("");
        Debug.Log("Number of slots: " + slotList.Count);
        Debug.Log(" ");
        for (int i = 0; i < slotList.Count - 1; i++)
        {
            Debug.Log("Slot " + i + ": " + slotList[i].ToString());
            if(slotList[i].objectInSlot != null)
            {
                Debug.Log("        Contents: " + slotList[i].objectInSlot.ToString());
            }
            else
            {
                Debug.Log("        Contents: null");
            }

        }
        Debug.Log("Slot " + (slotList.Count - 1) + ": " + slotList[slotList.Count - 1].ToString());
        Debug.Log("");
        Debug.Log("----- printing done -----");
        Debug.Log("");
    }
}
