using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlLogicScript : AbstractSlotHolderScript, IInteractionLogicScript, IActionScript
{
    //public bool allSlotsFull { get; private set; }
    //public bool hasItemSlot { get; private set; }

    //public GameObject objectInSlot { get; private set; }

    //public Transform slotTransform { get; private set; }

    //public List<IItemSlotScript> slotList { get; private set; }

    //public int bowlContentsSize { get; private set; }

    //public Transform bowlSlotTransform;

    // Start is called before the first frame update
    void Start()
    {
        //slotList = new List<IItemSlotScript>();
        //allSlotsFull = false;
        FindItemSlots();
        CheckIfSlotAreFull();

        //slotTransform = bowlSlotTransform;
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if (interactionRequester != null)
        {
            if (hasItemSlot && !allSlotsFull)
            {
                string requesterTag = interactionRequester.tag;

                //////bool requesterHasSlot = false;
                //////bool requesterIsNotFull = false;

                //GameObject objectInSlot = FindObjectByTag("Torch");

                //////if (interactionRequester.TryGetComponent(out AbstractSlotHolderScript slotHolderScript))
                //////{
                //////    Debug.Log("I am: " + gameObject.ToString());
                //////    Debug.Log("found a slot holder in requester: " + slotHolderScript.ToString());

                //////    requesterHasSlot = slotHolderScript.hasItemSlot;
                //////    requesterIsNotFull = !slotHolderScript.allSlotsFull;
                //////}

                if (requesterTag == "Player")
                {
                    //interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                }
                else if (requesterTag == "Ingredient" || requesterTag == "Torch")
                {
                    if (!FindObject(interactionRequester))
                    {
                        HoldItem(interactionRequester);
                        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);

                        BowlSlotScript newSlot = new BowlSlotScript();
                        slotList.Add(newSlot);
                    }
                    else if(FindObject(interactionRequester))
                    {
                        int requesterIndex = GetIndexOfSlot(GetSlotOfObject(interactionRequester));
                        DropItem(interactionRequester);
                        if(requesterIndex > 0)
                        {
                            if(!slotList[requesterIndex].isSlotFull)
                            {
                                slotList.RemoveAt(requesterIndex);
                            }
                        }
                    }
                }
            }
        }

        CheckIfSlotAreFull();

        //if (interactionRequester != null)
        //{
        //    string requesterTag = interactionRequester.tag;

        //    Debug.Log("made it into bowl's request");

        //    if (requesterTag == "Player")
        //    {
        //        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
        //    }
        //    else if (requesterTag == "Ingredient" || requesterTag == "Torch")
        //    {
        //        //if (!bowlContents.Contains(interactionRequester))
        //        //{
        //        //    Debug.Log("-------2");
        //        //    interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
        //        //    HoldItem(interactionRequester);
        //        //}
        //        //else 
        //        Debug.Log("----------");
        //        if(FindObject(interactionRequester))
        //        {
        //            Debug.Log("detaching requester");
        //            DetachItem(interactionRequester);
        //        }
        //        else
        //        {
        //            Debug.Log("-------2");
        //            interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
        //            HoldItem(interactionRequester);
        //        }
        //    }
        //    //else if (requesterTag == "Torch")
        //    //{
        //    //    if (!FindObject(interactionRequester))
        //    //    {
        //    //        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
        //    //        HoldItem(interactionRequester);
        //    //    }
        //    //    else if (FindObject(interactionRequester))
        //    //    {
        //    //        DetachItem(interactionRequester);
        //    //    }
        //    //}
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

    //private new void HoldItem(GameObject item)
    //{
    //    AddToBowl(item);
    //}

    //private void AddToBowl(GameObject item)
    //{
    //    BowlSlotScript newSlot = new BowlSlotScript();
    //    newSlot.HoldItem(item);

    //    slotList.Add(newSlot);
    //}

    //public void RemoveObjectSlot(int objectSlotIndex)
    //{
    //    if(!slotList[objectSlotIndex].isSlotFull && objectSlotIndex != 0)
    //    {
    //        slotList.RemoveAt(objectSlotIndex);
    //    }
    //}

    //public void HoldItem(GameObject item)
    //{
    //    AddToBowl(item);
    //}

    //public GameObject GiveItem()
    //{
    //    return null;
    //}

    //public void DropHeldItem()
    //{
    //}
}
