﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchActionScript : AbstractPickableObjectScript, IInteractionLogicScript, IActionScript
{

    //public bool isPickable { get; private set; }
    //public bool isDetached { get; private set; }

    //public Transform parentTransform { get; private set; }

    public bool isTorchLit { get; private set; }

    public bool isInHolder { get; private set; }

    public Material unlitTorch;
    public Material litTorch;

    public GameObject torchHead;

    // Start is called before the first frame update
    void Start()
    {
        isPickable = true;
        isDetached = true;
        isTorchLit = false;
        isInHolder = false;
        torchHead.GetComponent<MeshRenderer>().material = unlitTorch;
        parentTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        Transform requesterItemSlot = null;

        if (interactionRequester != null)
        {
            string requesterTag = interactionRequester.tag;

            Debug.Log("made it into torch's request");

            if (requesterTag == "Player" && isInHolder)
            {
                ToggleTorch();
            }
            else
            {
                requesterItemSlot = interactionRequester.GetComponent<IInteractionLogicScript>().GetSlotTransform(gameObject);
                GetPickedUp(requesterItemSlot);
            }

            if (requesterTag == "TorchHolder")
            {
                isInHolder = true;
            }
            else
            {
                isInHolder = false;
            }

            if (requesterTag == "Bowl")
            {
                SetKinematic(false);
            }
        }
    }

    public void PerformAction()
    {

    }

    //public void GetPickedUp(Transform newParent)
    //{
    //    if (newParent != null)
    //    {
    //        bool parentCanHoldItems = newParent.GetComponentInParent<IInteractionLogicScript>().hasItemSlot;
    //        bool parentHasFreeSlot = !newParent.GetComponentInParent<IInteractionLogicScript>().allSlotsFull;
    //        if (parentCanHoldItems && parentHasFreeSlot)
    //        {
    //            //if (newParent.gameObject != parentTransform.gameObject)
    //            //{
    //            //    parentTransform.gameObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
    //            //}
    //            parentTransform = newParent;
    //            SetKinematic(true);
    //            transform.SetParent(parentTransform, false);
    //            transform.position = parentTransform.position;
    //            transform.rotation = parentTransform.rotation;

    //            isDetached = false;

    //            //if (parentTransform.tag == "TorchHolder")
    //            //{
    //            //    isInHolder = true;
    //            //}
    //        }
    //    }        
    //}

    //public void GetDropped()
    //{
    //    parentTransform.GetComponentInParent<IInteractionLogicScript>().InteractionRequest(gameObject);
    //    parentTransform = null;
    //    transform.SetParent(null);
    //    SetKinematic(true);

    //    isDetached = true;
    //}   

    //public void SetKinematic(bool isKinematic)
    //{
    //    gameObject.GetComponent<Rigidbody>().isKinematic = isKinematic;
    //}

    //public void TogglePickability()
    //{

    //}

    private void ToggleTorch()
    {
        if (isTorchLit)
        {
            torchHead.GetComponent<MeshRenderer>().material = unlitTorch;
        }
        else
        {
            torchHead.GetComponent<MeshRenderer>().material = litTorch;
        }
        isTorchLit = !isTorchLit;
    }
}