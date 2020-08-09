using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectScript : MonoBehaviour
{
    //public bool hasItemSlot { get; private set; }

    //public bool allSlotsFull { get; private set; }

    //public List<IItemSlotScript> slotList { get; private set; }

    private Sprite interactionImage;

    //public IActionScript actionScript;

    // Start is called before the first frame update
    void Start()
    {
        //allSlotsFull = false;
        //slotList = new List<IItemSlotScript>(GetComponentsInChildren<IItemSlotScript>());
        //CheckForItemSlots();
        //GetObjectSlots();
    }


    //private void GetObjectSlots()
    //{

    //}

    //private void CheckForItemSlots()
    //{
    //    if (slotList.Count > 0)
    //    {
    //        //Debug.Log("slots found");
    //        hasItemSlot = true;
    //        slotList.ToString();
    //    }
    //}

    public Sprite GetInteractableImage()
    {
        return interactionImage;
    }

    //public void InteractionRequest(GameObject interactionRequester)
    //{
    //    if(interactionRequester != null)
    //    {
    //        Debug.Log("Interaction requester: " + interactionRequester.ToString());
    //        //Debug.Log("actio script: " + actionScript.ToString());
    //        GetComponent<IActionScript>().Interact(interactionRequester);
    //        //actionScript.Interact(interactionRequester);
    //    }
    //}

    //public Transform GetSlotTransform(GameObject requester)
    //{
    //    Transform freeSlot = null;
    //    if (hasItemSlot && !allSlotsFull)
    //    {
    //        freeSlot = FindFreeSlot(requester);
    //    }

    //    return freeSlot;
    //}

    //private Transform FindFreeSlot(GameObject requester)
    //{
    //    Transform freeSlotTransform = null;


    //    Debug.Log("object slot list: " + slotList.ToString());

    //    for (int i = 0; i < slotList.Count; i++)
    //    {
    //        if (!slotList[i].isSlotFull)
    //        {
    //            freeSlotTransform = slotList[i].slotTransform;
    //        }
    //    }

    //    if(freeSlotTransform == null)
    //    {
    //        allSlotsFull = true;
    //    }
    //    else
    //    {
    //        allSlotsFull = false;
    //    }

    //    Debug.Log(freeSlotTransform.ToString());

    //    return freeSlotTransform;
    //}
}
