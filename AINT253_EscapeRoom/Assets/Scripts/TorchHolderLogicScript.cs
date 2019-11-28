﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchHolderActionScript : AbstractSlotHolderScript, IInteractionLogicScript//, IItemSlotScript
{
    public bool isSlotFull { get; private set; }

    public GameObject objectInSlot { get; private set; }

    public Transform slotTransform { get; private set; }

    public Transform torchHolderSlotTransform;

    // Start is called before the first frame update
    void Start()
    {
        isSlotFull = false;
        FindItemSlots();
        CheckIfSlotAreFull();
        slotTransform = torchHolderSlotTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if (interactionRequester != null)
        {
            string requesterTag = interactionRequester.tag;

            Debug.Log("made it into torch holder's request");

            if (requesterTag == "Player")
            {
                if (!isSlotFull)
                {
                    bool requesterHasSlot = interactionRequester.GetComponent<IInteractionLogicScript>().hasItemSlot;
                    bool requesterIsHoldingItem = interactionRequester.GetComponent<IInteractionLogicScript>().allSlotsFull;
                    if (requesterHasSlot && requesterIsHoldingItem)
                    {
                        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                    }
                    else if(requesterHasSlot && !requesterIsHoldingItem)
                    {
                        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(GiveItem());
                    }
                }
            }
            else if (requesterTag == "Torch")
            {
                if (interactionRequester != objectInSlot && !isSlotFull)
                {
                    HoldItem(interactionRequester);
                    //interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                }
                
            }
            //else if (requesterTag == "Ingredient")
            //{

            //}
        }
    }

    //public void HoldItem(GameObject item)
    //{
    //    objectInSlot = item;
    //    isSlotFull = true;
    //}

    public GameObject GiveHeldItem()
    {
        GameObject temp = objectInSlot;

        objectInSlot = null;

        return temp;
    }

    public void DropHeldItem()
    {
        //objectInSlot.transform.parent = null;

        //objectInSlot.GetComponent<IPickableObjectScript>().isDetached = true;

        objectInSlot = null;
    }
}