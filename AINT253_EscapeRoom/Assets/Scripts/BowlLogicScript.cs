using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlActionScript : AbstractSlotHolderScript, IInteractionLogicScript, IActionScript
{
    //public bool allSlotsFull { get; private set; }
    //public bool hasItemSlot { get; private set; }

    //public GameObject objectInSlot { get; private set; }

    public Transform slotTransform { get; private set; }

    //public List<IItemSlotScript> slotList { get; private set; }

    //public int bowlContentsSize { get; private set; }

    public Transform bowlSlotTransform;

    // Start is called before the first frame update
    void Start()
    {
        //slotList = new List<IItemSlotScript>();
        //allSlotsFull = false;
        FindItemSlots();
        CheckIfSlotAreFull();

        slotTransform = bowlSlotTransform;
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if(interactionRequester != null)
        {
            string requesterTag = interactionRequester.tag;

            Debug.Log("made it into bowl's request");

            if (requesterTag == "Player")
            {
                interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
            }
            else if (requesterTag == "Ingredient" || requesterTag == "Torch")
            {
                //if (!bowlContents.Contains(interactionRequester))
                //{
                //    Debug.Log("-------2");
                //    interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                //    HoldItem(interactionRequester);
                //}
                //else 
                Debug.Log("----------");
                if(FindObject(interactionRequester))
                {
                    Debug.Log("detaching requester");
                    DetachItem(interactionRequester);
                }
                else
                {
                    Debug.Log("-------2");
                    interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                    HoldItem(interactionRequester);
                }
            }
            //else if (requesterTag == "Torch")
            //{
            //    if (!FindObject(interactionRequester))
            //    {
            //        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
            //        HoldItem(interactionRequester);
            //    }
            //    else if (FindObject(interactionRequester))
            //    {
            //        DetachItem(interactionRequester);
            //    }
            //}
        }
    }

    public void PerformAction()
    {

    }

    //public Transform FindFreeSlot(GameObject requester)
    //{
    //    return
    //}

    //public GameObject FindObjectByTag(string tag)
    //{
    //    return
    //}

    //public bool FindObject(GameObject objectToFind)
    //{
    //    return
    //}

    //public IItemSlotScript GetSlotOfObject(GameObject objectToFind)
    //{
    //    return
    //}

    private new void HoldItem(GameObject item)
    {
        AddToBowl(item);
    }

    private void AddToBowl(GameObject item)
    {
        BowlSlotScript newSlot = new BowlSlotScript();
        newSlot.HoldItem(item);

        slotList.Add(newSlot);
    }

    public void DetachItem(GameObject item)
    {
        if(bowlContents.Contains(item))
        {
            int itemIndex = 0;
            bool itemFound = false;
            for (int i = 0; i < bowlContents.Count; i++)
            {
                if (item == bowlContents[i])
                {
                    itemIndex = i;
                    itemFound = true;
                }
            }
            if (itemFound)
            {
                bowlContents[itemIndex] = null;
            }
        }
    }

    //public void HoldItem(GameObject item)
    //{
    //    AddToBowl(item);
    //}

    public GameObject GiveItem()
    {
        return null;
    }

    public void DropHeldItem()
    {
    }
}
