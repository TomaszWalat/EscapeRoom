using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSlotHolderScript : MonoBehaviour
{
    public bool hasItemSlot { get; protected set;  }

    public bool allSlotsFull { get; protected set; }

    [field: SerializeField]
    public List<IItemSlotScript> slotList { get; protected set; }

    private int numberOfSlots = 0;
    private int numberOfFreeSlots = 0;

    protected void FindItemSlots()
    {
        slotList = new List<IItemSlotScript>(GetComponentsInChildren<IItemSlotScript>());

        numberOfSlots = slotList.Count;
        numberOfFreeSlots = slotList.Count;

        if(slotList.Count > 0)
        {
            hasItemSlot = true;
            
        }
        //Debug.Log("I am: " + gameObject);
        //Debug.Log("I have slots: " + hasItemSlot);
        //Debug.Log("I am method: FindItemSlots()");
        //PrintSlotList();
    }

    protected bool CheckIfSlotAreFull()
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
        //Debug.Log("I am method: CheckIfSlotAreFull()");
        ////PrintSlotList();

        return true;// (numberOfSlots > numberOfFreeSlots);
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
        //Debug.Log("I am method: FindFreeSlot()");
        //PrintSlotList();
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
        //Debug.Log("I am method: FindSlotByName()");
        //PrintSlotList();
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
        //Debug.Log("I am method: FindObjectByTag()");
        //PrintSlotList();
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
        //Debug.Log("I am method: FindObject()");
        //PrintSlotList();
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
        //Debug.Log("I am method: GetSlotOfObject()");
        //PrintSlotList();
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
        //Debug.Log("I am method: GetIndexOfSlot()");
        //PrintSlotList();
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

            //numberOfFreeSlots--;

            CheckIfSlotAreFull();
            //Debug.Log("I am method: HoldItem()");
            //PrintSlotList();
        }
    }

    protected GameObject GiveItem(int slotIndex)
    {
        GameObject temp = null;
        if (slotList[slotIndex].isSlotFull)
        {
            temp = slotList[slotIndex].GiveHeldItem();

            //numberOfFreeSlots++;

            CheckIfSlotAreFull();
        }
        //Debug.Log("I am method: GiveItem()");
        //PrintSlotList();
        return temp;
    }

    protected void DropItem(GameObject itemToDrop)
    {

        Debug.Log("I am method: DropItem()");
        //int objectIndex = -1;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].objectInSlot == itemToDrop)
            {
                //objectIndex = i;
                slotList[i].DropHeldItem();
                //numberOfFreeSlots++;
            }
        }

        //if (objectIndex > -1)
        //{
        //    slotList[objectIndex].DropHeldItem();
        //}


        Debug.Log("I am method: DropItem() 2");

        CheckIfSlotAreFull();
        //Debug.Log("I am method: DropItem()");
        //PrintSlotList();
    }

    //protected void DropItem(GameObject itemToDrop)
    //{
    //    if (itemToDrop != null)
    //    {
    //        if (FindObject(itemToDrop))
    //        {
    //            int objectIndex = 0;

    //            for (int i = 0; i < slotList.Count; i++)
    //            {
    //                if (slotList[i].objectInSlot == itemToDrop)
    //                {
    //                    objectIndex = i;
    //                }
    //            }

    //            slotList[objectIndex].DropHeldItem();

    //            numberOfFreeSlots++;

    //            CheckIfSlotAreFull();
    //            Debug.Log("I am method: DropItem()");
    //PrintSlotList();
    //        }
    //    }
    //}

    protected void PrintSlotList()
    {
        //Debug.Log("");
        Debug.Log("##### printing starting #####");
        //Debug.Log("");
        Debug.Log("Number of slots: " + slotList.Count);
        Debug.Log("Number of slots field: " + numberOfSlots);
        Debug.Log("Number of free slots field: " + numberOfFreeSlots);
        //Debug.Log(" ");
        //for (int i = 0; i < slotList.Count; i++)
        //{
        //    Debug.Log("Slot " + i + ": " + slotList[i].ToString());
        //    if(slotList[i].objectInSlot != null)
        //    {
        //        Debug.Log("        Contents: " + slotList[i].objectInSlot.ToString());
        //    }
        //    else
        //    {
        //        Debug.Log("        Contents: null");
        //    }

        //}
        //Debug.Log("Slot " + (slotList.Count - 1) + ": " + slotList[slotList.Count - 1].ToString());
        //Debug.Log("");
        Debug.Log("----- printing done -----");
        Debug.Log("");
    }
}
