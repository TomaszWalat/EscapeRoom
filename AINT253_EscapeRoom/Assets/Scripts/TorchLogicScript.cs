using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class TorchLogicScript : PickableObjectScript, IInteractionLogicScript, IActionScript
{

    //public bool isPickable { get; private set; }
    //public bool isDetached { get; private set; }

    //public Transform parentTransform { get; private set; }
    [field: SerializeField]
    public bool isTorchLit { get; private set; }
    [field: SerializeField]
    public bool isInHolder { get; private set; }

    //public Material unlitTorch;
    //public Material litTorch;

    public GameObject torchHead;

    // Start is called before the first frame update
    void Start()
    {
        isPickable = true;
        isDetached = true;
        isTorchLit = false;
        isInHolder = false;
        torchHead.SetActive(false);//torchHead.GetComponent<MeshRenderer>().material = unlitTorch;
        parentTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if (interactionRequester.TryGetComponent(out AbstractSlotHolderScript slotHolderScript))
        {
            bool parentHasSlots = false;
            bool parentIsNotFull = false;

            string requesterTag = interactionRequester.tag;

            //Debug.Log("I am: " + gameObject.ToString());
            //Debug.Log("found a slot holder in parent: " + slotHolderScript.ToString());

            parentHasSlots = slotHolderScript.hasItemSlot;
            parentIsNotFull = !slotHolderScript.allSlotsFull;

            if (parentHasSlots)// && parentIsNotFull)
            {
                Transform newParentTransform = null;

                if (slotHolderScript.FindObject(gameObject))
                {
                    //Debug.Log("Torch - I'm already with this parent ---------------");
                    IItemSlotScript parentSlot = slotHolderScript.GetSlotOfObject(gameObject);

                    newParentTransform = parentSlot.slotTransform;
                }

                if (parentTransform != null && newParentTransform != parentTransform)
                {
                    GetDropped();
                }

                //Debug.Log("current parent transform: " + parentTransform);
                //Debug.Log("new parent transform: " + newParentTransform);
                GetPickedUp(newParentTransform);
            }

            if (requesterTag == "Bowl")
            {
                SetKinematic(false);
            }
            //Debug.Log("1");

            //if(isInHolder && parentTransform.GetComponentInParent<AbstractSlotHolderScript>().FindObject(gameObject))
            //{
            //    if(requesterTag == "Player")
            //    {
            //        ToggleTorch();
            //    }
            //}
            //else
            //{
            //    if (parentHasSlots && parentIsNotFull)
            //    {
            //        Debug.Log("2");

            //        Transform newParentTransform = null;

            //        if (slotHolderScript.FindObject(gameObject))
            //        {
            //            Debug.Log("3");

            //            IItemSlotScript parentSlot = slotHolderScript.GetSlotOfObject(gameObject);

            //            newParentTransform = parentSlot.slotTransform;
            //        }


            //        if (parentTransform != null)// && !parentTransform.GetComponentInParent<AbstractSlotHolderScript>().FindObject(gameObject))
            //        {
            //            Debug.Log("5");

            //            if (parentTransform != null && newParentTransform != parentTransform)
            //            {
            //                Debug.Log("6");

            //                GetDropped();
            //                isInHolder = false;
            //            }

            //            GetPickedUp(newParentTransform);

            //            if (parentTransform.tag == "TorchHolder")
            //            {
            //                Debug.Log("7");

            //                isInHolder = true;
            //            }

            //            if (parentTransform.tag == "Bowl")
            //            {
            //                Debug.Log("8");

            //                SetKinematic(false);
            //            }
            //        }
            //        else if (requesterTag == "Player" && isInHolder)
            //        {
            //            Debug.Log("4");

            //            ToggleTorch();
            //        }
            //    }
            //}


        }

        if(interactionRequester.tag == "FirePit" || interactionRequester.tag == "Lighter")
        {
            ToggleTorch();
        }

        //Transform requesterItemSlot = null;

        //if (interactionRequester != null)
        //{
        //    string requesterTag = interactionRequester.tag;

        //    Debug.Log("made it into torch's request");

            

        //    if (requesterTag == "Bowl")
        //    {
        //        SetKinematic(false);
        //    }
        //}
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
        //UnityEngine.Debug.Log("Getting toggled >>> " + isTorchLit + " ---> " + !isTorchLit);
        if (isTorchLit)
        {
            torchHead.SetActive(!isTorchLit);//torchHead.GetComponent<MeshRenderer>().material = unlitTorch;
        }
        else
        {
            torchHead.SetActive(!isTorchLit);//torchHead.GetComponent<MeshRenderer>().material = litTorch;
        }
        isTorchLit = !isTorchLit;


    }
}
