using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlLogicScript : AbstractSlotHolderScript, IInteractionLogicScript, IActionScript, IPuzzlePieceScript
{
    //public bool allSlotsFull { get; private set; }
    //public bool hasItemSlot { get; private set; }

    //public GameObject objectInSlot { get; private set; }

    //public Transform slotTransform { get; private set; }

    //public List<IItemSlotScript> slotList { get; private set; }

    //public int bowlContentsSize { get; private set; }

    public Transform bowlHolderSlotTransform;

    public bool puzzlePieceComplete { get; private set; }

    public PuzzleElementScript puzzleElementScript;
    public BowlContentsTemplateScript contentsTemplateScript;
    public GameObject bowlModel;

    // Start is called before the first frame update
    void Start()
    {
        //slotList = new List<IItemSlotScript>();
        //allSlotsFull = false;
        FindItemSlots();
        CheckIfSlotAreFull();

        //contentsTemplateScript = GetComponentInChildren<BowlContentsTemplateScript>();
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
                    interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                }
                else if (requesterTag == "Ingredient" || requesterTag == "Torch")
                {
                    bool isTorchLit = false;

                    if(interactionRequester.TryGetComponent(out TorchLogicScript torchLogicScript))
                    {
                        isTorchLit = torchLogicScript.isTorchLit;
                    }

                    if (!isTorchLit)
                    {
                        if (!FindObject(interactionRequester))
                        {
                            HoldItem(interactionRequester);
                            interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);

                            BowlSlotScript newSlot = gameObject.AddComponent<BowlSlotScript>();
                            newSlot.bowlSlotTransform = bowlHolderSlotTransform;
                            newSlot.slotTransform = bowlHolderSlotTransform;
                            slotList.Add(newSlot);
                        }
                        else if (FindObject(interactionRequester))
                        {
                            BowlSlotScript temp = GetSlotOfObject(interactionRequester) as BowlSlotScript;

                            int requesterSlotIndex = GetIndexOfSlot(GetSlotOfObject(interactionRequester));
                            DropItem(interactionRequester);

                            if (requesterSlotIndex > 0)
                            {
                                if (!temp.isSlotFull)
                                {
                                    temp.SelfDestruct();
                                    slotList.RemoveAt(requesterSlotIndex);
                                }
                            }
                        }
                    }
                    else if(isTorchLit)
                    {
                        //Debug.Log("about to call perform action");
                        PerformAction();
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
        //Debug.Log("preform action called");
        if(CheckBowlContents())
        {
            //Debug.Log("bow contents is correct");
            puzzlePieceComplete = true;
            puzzleElementScript.AddPuzzlePiece(gameObject);
            bowlModel.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public bool CheckBowlContents()
    {
        bool ritualComplete = false;
        //Debug.Log("0");
        //Debug.Log("rutual status: " + ritualComplete);
        if(slotList.Count == contentsTemplateScript.puzzleTemplateList.Count + 1)
        {
            //Debug.Log("1");
            ritualComplete = true;
        //Debug.Log("rutual status: " + ritualComplete);
            for (int i = 0; i < contentsTemplateScript.puzzleTemplateList.Count; i++)
            {
                //Debug.Log("1." + i);

                bool itemFound = false;
                //Debug.Log("item found: " + itemFound);

                for (int j = 0; j < slotList.Count -1; j++)
                {
                    //Debug.Log("1." + i + "." + j);

                    //Debug.Log("template object type: " + (contentsTemplateScript.puzzleTemplateList[i] as IngredientLogicScript).gameObject.name.ToString() + "(Clone)");
                    //Debug.Log("ingredient type: " + slotList[i].objectInSlot.name.ToString());

                    if ((contentsTemplateScript.puzzleTemplateList[i] as IngredientLogicScript).gameObject.name + "(Clone)" == slotList[j].objectInSlot.name)
                    {
                        //Debug.Log("2");

                        itemFound = true;
                        //Debug.Log("item found: " + itemFound);
                    }
                }
                //Debug.Log("item found: " + itemFound);

                if (!itemFound)
                {
                    //Debug.Log("3");

                    ritualComplete = false;
                }
                //Debug.Log("rutual status: " + ritualComplete);
            }
            //Debug.Log("rutual status: " + ritualComplete);
        }
        //Debug.Log("rutual status: " + ritualComplete);

        //for(int i = 0; i < slotList.Count; i++)
        //{
        //    for(int j = 0; j < contentsTemplateScript.puzzleTemplateList.Count; j++)
        //    {
        //        if(!(contentsTemplateScript.puzzleTemplateList[j].GetType() == slotList[i].GetType()))
        //        {
        //            ritualComplete = false;
        //        }
        //    }
        //}

        return ritualComplete;
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
