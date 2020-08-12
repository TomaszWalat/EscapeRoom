using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchHolderLogicScript : AbstractSlotHolderScript, IInteractionLogicScript, IPuzzlePieceScript
{
    public bool puzzlePieceComplete { get; private set; }
    //public bool isSlotFull { get; private set; }

    //public GameObject objectInSlot { get; private set; }

    //public Transform slotTransform { get; private set; }

    //public Transform torchHolderSlotTransform;

    public PuzzleElementScript puzzleElementScript;

    public bool isPuzzleTorch;

    // Start is called before the first frame update
    void Start()
    {
        //isSlotFull = false;
        FindItemSlots();
        CheckIfSlotAreFull();
        //slotTransform = torchHolderSlotTransform;
        SetPuzzlePiece();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //CheckPuzzlePiece();
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if (interactionRequester != null)
        {
            if (hasItemSlot)// && !allSlotsFull)
            {
                string requesterTag = interactionRequester.tag;

                bool requesterHasSlot = false;
                bool requesterIsNotFull = false;

                //GameObject objectInSlot = slotList[0].objectInSlot;

                if (interactionRequester.TryGetComponent(out AbstractSlotHolderScript slotHolderScript))
                {
                    //Debug.Log("I am: " + gameObject.ToString());
                    //Debug.Log("found a slot holder in requester: " + slotHolderScript.ToString());

                    requesterHasSlot = slotHolderScript.hasItemSlot;
                    requesterIsNotFull = !slotHolderScript.allSlotsFull;
                }

                if(requesterTag == "Player")
                {
                    if(requesterHasSlot && requesterIsNotFull && slotList[0].isSlotFull)
                    {
                        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(slotList[0].objectInSlot);
                    }
                }
                else if(requesterTag == "Torch")
                {
                    if(!FindObject(interactionRequester) && !allSlotsFull)
                    {
                        HoldItem(interactionRequester);
                        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                    }
                    else if(FindObject(interactionRequester))
                    {
                        DropItem(interactionRequester);
                    }
                }
            }
        }

        CheckIfSlotAreFull();

        
        CheckPuzzlePiece();

        if (puzzlePieceComplete && isPuzzleTorch)
        {
            //Debug.Log("element script: " + puzzleElementScript.ToString());
            puzzleElementScript.AddPuzzlePiece(gameObject);
            //puzzleElementScript.CheckPieces();
        }
        else if (!puzzlePieceComplete && isPuzzleTorch)
        {
            puzzleElementScript.RemovePuzzlePiece(gameObject);
        }
        puzzleElementScript.CheckPieces();
        //if (interactionRequester != null)
        //{
        //    string requesterTag = interactionRequester.tag;

        //    Debug.Log("made it into torch holder's request");

        //    if (requesterTag == "Player")
        //    {
        //        if (!isSlotFull)
        //        {
        //            bool requesterHasSlot = interactionRequester.GetComponent<IInteractionLogicScript>().hasItemSlot;
        //            bool requesterIsHoldingItem = interactionRequester.GetComponent<IInteractionLogicScript>().allSlotsFull;
        //            if (requesterHasSlot && requesterIsHoldingItem)
        //            {
        //                interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
        //            }
        //            else if(requesterHasSlot && !requesterIsHoldingItem)
        //            {
        //                interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(GiveItem());
        //            }
        //        }
        //    }
        //    else if (requesterTag == "Torch")
        //    {
        //        if (interactionRequester != objectInSlot && !isSlotFull)
        //        {
        //            HoldItem(interactionRequester);
        //            //interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
        //        }

        //    }
        //else if (requesterTag == "Ingredient")
        //{

        //}

    }

    //public void HoldItem(GameObject item)
    //{
    //    objectInSlot = item;
    //    isSlotFull = true;
    //}

    //public GameObject GiveHeldItem()
    //{
    //    GameObject temp = objectInSlot;

    //    objectInSlot = null;

    //    return temp;
    //}

    //public void DropHeldItem()
    //{
    //    //objectInSlot.transform.parent = null;

    //    //objectInSlot.GetComponent<IPickableObjectScript>().isDetached = true;

    //    objectInSlot = null;
    //}

    private void SetPuzzlePiece()
    {
        if(isPuzzleTorch)
        {
            puzzlePieceComplete = false;
        }
        else
        {
            puzzlePieceComplete = true;
        }
    }

    private void CheckPuzzlePiece()
    {
        Debug.Log("checking puzzle piece - " + gameObject.ToString());
        Debug.Log("completion status: " + puzzlePieceComplete);

        if (isPuzzleTorch)// && slotList[0] != null)
        {
            if(slotList[0].objectInSlot != null)
            {
                if (slotList[0].objectInSlot.GetComponent<TorchLogicScript>().isTorchLit)
                {
                    puzzlePieceComplete = true;
                }
                else
                {
                    puzzlePieceComplete = false;
                }
            }
            else
            {
                puzzlePieceComplete = false;
            }
        }
        else
        {
            if(slotList.Count > 0)
            {
                if (!(slotList[0].objectInSlot.GetComponent<TorchLogicScript>().isTorchLit))
                {
                    puzzlePieceComplete = true;
                }
                else
                {
                    puzzlePieceComplete = false;
                }
            }
            else
            {
                puzzlePieceComplete = true;
            }
            
        }
        Debug.Log("completion status: " + puzzlePieceComplete);
    }
}
