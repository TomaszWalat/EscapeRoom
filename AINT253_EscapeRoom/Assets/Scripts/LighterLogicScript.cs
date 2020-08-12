using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterLogicScript : PickableObjectScript, IInteractionLogicScript, IPuzzlePieceScript
{
    [field: SerializeField]
    public GameObject bowl { get; private set; }
    [field: SerializeField]
    public bool isInBowl { get; private set; }
    [field: SerializeField]
    public bool puzzlePieceComplete { get; private set; }

    int counterL = 0;

    // Start is called before the first frame update
    void Start()
    {
        isPickable = true;
        isDetached = true;
        isInBowl = false;
        parentTransform = gameObject.transform;
        puzzlePieceComplete = true;
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

            //Debug.Log(counterL + " L >>> I am: " + gameObject.ToString());
            //Debug.Log(counterL + " L >>> found a slot holder in parent: " + slotHolderScript.ToString());
            counterL++;

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
    //public void SignalObservers()
    //{

    //}
}
