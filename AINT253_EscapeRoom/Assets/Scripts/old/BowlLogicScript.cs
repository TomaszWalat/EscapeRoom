using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
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

    [field: SerializeField]
    public bool puzzlePieceComplete { get; private set; }

    public PuzzleElementScript puzzleElementScript;
    public BowlContentsTemplateScript contentsTemplateScript;
    public GameObject bowlParticles;

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

                //if (requesterTag == "Player")
                //{
                //    interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                //}
                if (requesterTag == "Ingredient" || requesterTag == "Torch")
                {
                    //if (requesterTag == "Lighter")
                    //{
                    //    if (CheckBowlContents())
                    //    { 

                    //    }
                    //}
                    bool isTorchLit = false;

                    if (interactionRequester.TryGetComponent(out TorchLogicScript torchLogicScript))
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
                    else if (isTorchLit)
                    {
                        //Debug.Log("about to call perform action");
                        PerformAction();
                    }

                }
                else if (requesterTag == "Lighter")
                {
                    bool lighterIsIngredient = false;

                    Debug.Log("We have a Lighter");
                    lighterIsIngredient = contentsTemplateScript.IsPieceOnTemplate(interactionRequester.GetComponent<IPuzzlePieceScript>());
                    Debug.Log("Lighter is puzzle piece === " + lighterIsIngredient);

                    if(lighterIsIngredient)
                    {
                        if (!FindObject(interactionRequester))
                        {
                            HoldItem(interactionRequester);
                            interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);

                            BowlSlotScript newSlot = gameObject.AddComponent<BowlSlotScript>();
                            newSlot.bowlSlotTransform = bowlHolderSlotTransform;
                            newSlot.slotTransform = bowlHolderSlotTransform;
                            slotList.Add(newSlot);

                            if (requesterTag == "Lighter")
                            {
                                PerformAction();
                            }
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
                    else
                    {
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
            //DeactivateItems();
            Invoke("DeleteItemsInSlots", 1.0f);
            //Debug.Log("bow contents is correct");
            puzzlePieceComplete = true;
            puzzleElementScript.AddPuzzlePiece(gameObject);
            bowlParticles.SetActive(true);
            puzzleElementScript.CheckPieces();
        }
    }

    private void DeactivateItems()
    {
        foreach (IItemSlotScript item in slotList)
        {
            if (item.objectInSlot != null)
            {
                item.objectInSlot.GetComponent<PickableObjectScript>().SetPickability(false);
            }
        }
    }

    private void DeleteItemsInSlots()
    {
        foreach (IItemSlotScript item in slotList)
        {
            if (item.objectInSlot != null)
            {
                GameObject temp = item.objectInSlot;

                item.DropHeldItem();

                Destroy(temp);
            }
        }
    }

    public bool CheckBowlContents()
    {
        bool ritualComplete = false;
        //Debug.Log("0");
        //Debug.Log("rutual status: " + ritualComplete);
        if(slotList.Count >= contentsTemplateScript.puzzleTemplateList.Count + 1)
        {
            //Debug.Log("1");
            ritualComplete = true;

            //string ingredientType = "ingredient";

        //Debug.Log("rutual status: " + ritualComplete);
            for (int i = 0; i < contentsTemplateScript.puzzleTemplateList.Count; i++)
            {
                //try
                //{
                //    contentsTemplateScript.puzzleTemplateList[i] as LighterLogicScript;
                //}
                //catch (Exception e)
                //{
                //    ingredientType
                //}

                //Debug.Log("1." + i);

                bool itemFound = false;
                //Debug.Log("item found: " + itemFound);

                for (int j = 0; j < slotList.Count; j++)
                {
                    //Debug.Log("1." + i + "." + j);

                    if (slotList[j].objectInSlot != null)
                    {
                        Debug.Log("template object type: " + ((contentsTemplateScript.puzzleTemplateList[i] as PickableObjectScript).gameObject.name.ToString()));

                        //if(contentsTemplateScript.puzzleTemplateList[i].TryGetComponent<IngredientLogicScript>(out IngredientLogicScript ingredientLogicScript))
                        //{
                        //    Debug.Log("@@@@@@@@@@@@@ This works @@@@@@@@@@@@@@");
                        //}

                        if ((contentsTemplateScript.puzzleTemplateList[i] as PickableObjectScript).gameObject.name == slotList[j].objectInSlot.name.Replace("(Clone)", ""))
                        {
                            //Debug.Log("2");

                            Debug.Log("ingredient type: " + slotList[i].objectInSlot.name.ToString().Replace("(Clone)", ""));
                            itemFound = true;
                            //Debug.Log("item found: " + itemFound);
                        }


                        //if ((contentsTemplateScript.puzzleTemplateList[i] as IngredientLogicScript).gameObject.name + "(Clone)" == slotList[j].objectInSlot.name)
                        //{
                        //    //Debug.Log("2");

                        //    itemFound = true;
                        //    //Debug.Log("item found: " + itemFound);
                        //}
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
