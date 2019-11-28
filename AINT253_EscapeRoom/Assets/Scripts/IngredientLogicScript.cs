using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientActionScript : AbstractPickableObjectScript, IInteractionLogicScript
{
    public GameObject bowl { get; private set; }

    //public bool isPickable { get; private set; }
    //public bool isDetached { get; private set; }

    public bool isInBowl { get; private set; }

    //public Transform parentTransform { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        isPickable = true;
        isDetached = true;
        isInBowl = false;
        parentTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if(interactionRequester.TryGetComponent(out IInteractionLogicScript interactionLogicScript))
        {
            Transform requesterItemSlot = null;

            string requesterTag = interactionRequester.tag;

            requesterItemSlot = interactionLogicScript.GetSlotTransform(gameObject);

            //if (requesterItemSlot != parentTransform && parentTransform != null)// && requesterTag != "Player")
            //{
            //    Debug.Log("parent transform game object: " + parentTransform.gameObject.ToString());
            //    Debug.Log("parent transform tag: " + parentTransform.gameObject.tag);
            //    parentTransform.gameObject.GetComponentInParent<IInteractionLogicScript>().InteractionRequest(gameObject);
            //    Debug.Log("requester item slot: " + requesterItemSlot.ToString());

            //}
            //Debug.Log("my current parent: " + parentTransform.gameObject.ToString());
            //if(parentTransform != null && requesterItemSlot != parentTransform && parentTransform.gameObject.tag == "Bowl")
            //{
            //    Debug.Log("informing bowl I'm leaving it");
            //    parentTransform.gameObject.GetComponentInParent<IInteractionLogicScript>().InteractionRequest(gameObject);
            //}
            Debug.Log("made it into ingredients's request");
            GetPickedUp(requesterItemSlot);




            if (requesterTag == "Bowl")
            {
                SetKinematic(false);
            }
        }
    }

    //public void GetPickedUp(Transform newParent)
    //{
    //    if (newParent != null)
    //    {
    //        bool parentCanHoldItems = newParent.GetComponentInParent<IInteractionLogicScript>().hasItemSlot;
    //        bool parentHasFreeSlot = !newParent.GetComponentInParent<IInteractionLogicScript>().allSlotsFull;
    //        if (parentCanHoldItems && parentHasFreeSlot)
    //        {
    //            if (parentTransform != null && newParent != parentTransform)
    //            {
    //                GetDropped();
    //            }
    //            parentTransform = newParent;
    //            SetKinematic(true);
    //            transform.SetParent(parentTransform, true);
    //            transform.SetPositionAndRotation(newParent.position, newParent.rotation);
    //            //transform.position = parentTransform.position;
    //            //transform.rotation = parentTransform.rotation;

    //            isDetached = false;

    //            //if (parentTransform.tag == "Bowl")
    //            //{
    //            //    SetKinematic(true);
    //            //}
    //        }
    //    }
    //}

    //private void SetPosition()
    //{

    //}

    //public void GetDropped()
    //{
    //    parentTransform.GetComponentInParent<IInteractionLogicScript>().InteractionRequest(gameObject);
    //    parentTransform = null;
    //    transform.SetParent(null);
    //    SetKinematic(false);

    //    isDetached = true;
    //}

    //public void SetKinematic(bool isKinematic)
    //{
    //    gameObject.GetComponent<Rigidbody>().isKinematic = isKinematic;
    //}

    //public void TogglePickability()
    //{

    //}
}
