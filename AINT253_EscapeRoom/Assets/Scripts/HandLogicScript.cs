using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class HandLogicScript : AbstractSlotHolderScript, IInteractionLogicScript
{

    //public bool hasItemSlot { get; private set; }

    //public bool allSlotsFull { get; private set; }

    //public List<IItemSlotScript> slotList { get; private set; }

    public bool isRightHandOccupied;
    public bool isLeftHandOccupied;

    public GameObject m_RightHand;
    public GameObject m_LeftHand;

    private IItemSlotScript m_RightHandSlot;
    private IItemSlotScript m_LeftHandSlot;

    // Start is called before the first frame update
    void Start()
    {
        isRightHandOccupied = false;
        isLeftHandOccupied = false;
        allSlotsFull = false;
        //allSlotsFull = false;
        //slotList = new List<IItemSlotScript>(GetComponentsInChildren<IItemSlotScript>());

        FindItemSlots();
        //Debug.Log(slotList.ToString());
        //CheckIfSlotAreFull();

        m_RightHandSlot = m_RightHand.GetComponent<IItemSlotScript>();
        m_LeftHandSlot = m_LeftHand.GetComponent<IItemSlotScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isRightHandOccupied = m_RightHandSlot.isSlotFull;
        isLeftHandOccupied = m_LeftHandSlot.isSlotFull;

        if (Input.GetKey(KeyCode.Q))
        {
            UnityEngine.Debug.Log("Q is pressed");
            if (Input.GetKey(KeyCode.Mouse1))
            {
                UnityEngine.Debug.Log("M1 is pressed");
                if (m_RightHandSlot.isSlotFull)
                {
                    m_RightHandSlot.objectInSlot.GetComponent<PickableObjectScript>().GetDropped();
                    //m_RightHandSlot.DropHeldItem();
                    DropItem(m_RightHandSlot.objectInSlot);
                    //isRightHandOccupied = false;
                }
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                UnityEngine.Debug.Log("M0 is pressed");
                if (m_LeftHandSlot.isSlotFull)
                {
                    m_LeftHandSlot.objectInSlot.GetComponent<PickableObjectScript>().GetDropped();
                    //m_LeftHandSlot.DropHeldItem();
                    DropItem(m_LeftHandSlot.objectInSlot);
                    //isLeftHandOccupied = false;
                }
            }
        }
    }

    //private void CheckForItemSlots()
    //{
    //    if(slotList.Count > 0)
    //    {
    //        Debug.Log("slots found");
    //        hasItemSlot = true;
    //        Debug.Log(slotList.ToString());
    //    }
    //}

    public void InteractionRequest(GameObject observedObject)
    {
        if(observedObject != null)
        {
            if(hasItemSlot)
            {
                string observedTag = observedObject.tag;

                bool observedHasSlots = false;
                bool observedIsNotFull = false;
                if (observedObject.TryGetComponent(out AbstractSlotHolderScript slotHolderScript))
                {
                    //Debug.Log("I am: " + gameObject.ToString());
                    //Debug.Log("found a slot holder in observed: " + slotHolderScript.ToString());

                    observedHasSlots = slotHolderScript.hasItemSlot;
                    observedIsNotFull = !slotHolderScript.allSlotsFull;
                }

                //bool isRightSlotFull = m_RightHandSlot.isSlotFull;
                GameObject rightHandSlotObject = null;
                string rightHandSlotObjTag = "";
                if (isRightHandOccupied)
                {
                    //Debug.Log("Right hand is full");
                    rightHandSlotObject = m_RightHandSlot.objectInSlot;
                    rightHandSlotObjTag = rightHandSlotObject.tag;
                }

                //bool isLeftSlotFull = m_LeftHandSlot.isSlotFull;
                GameObject leftHandSlotObject = null;
                string leftHandSlotObjTag = "";
                if (isLeftHandOccupied)
                {
                    //Debug.Log("Left hand is full");
                    leftHandSlotObject = m_LeftHandSlot.objectInSlot;
                    leftHandSlotObjTag = leftHandSlotObject.tag;
                }

                if (observedTag == "Bowl")
                {
                    if (observedHasSlots && observedIsNotFull)
                    {
                        if (isRightHandOccupied)
                        {
                            if (rightHandSlotObjTag == "Torch" && rightHandSlotObject.GetComponent<TorchLogicScript>().isTorchLit)// || m_RightHandSlot.objectInSlot.tag == "Lighter")
                            {
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(rightHandSlotObject);
                                //isRightHandOccupied = true;
                            }
                            else if (m_RightHandSlot.objectInSlot.tag == "Lighter")
                            {
                                m_RightHandSlot.objectInSlot.GetComponent<PickableObjectScript>().GetDropped();
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(rightHandSlotObject);
                                DropItem(rightHandSlotObject);
                            }
                            else
                            {
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(rightHandSlotObject);
                                //m_RightHandSlot.DropHeldItem();
                                DropItem(rightHandSlotObject);
                                //isRightHandOccupied = false;
                            }
                        }
                        else if (isLeftHandOccupied)
                        {
                            if (leftHandSlotObjTag == "Torch" && leftHandSlotObject.GetComponent<TorchLogicScript>().isTorchLit)// || m_LeftHandSlot.objectInSlot.tag == "Lighter")
                            {
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(leftHandSlotObject);
                                //isLeftHandOccupied = true;
                            }
                            else if (m_LeftHandSlot.objectInSlot.tag == "Lighter")
                            {
                                m_LeftHandSlot.objectInSlot.GetComponent<PickableObjectScript>().GetDropped();
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(leftHandSlotObject);
                                DropItem(leftHandSlotObject);
                            }
                            else //if (m_LeftHandSlot.objectInSlot.tag == "Lighter")
                            {
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(leftHandSlotObject);
                                //m_LeftHandSlot.DropHeldItem();
                                DropItem(leftHandSlotObject);
                                //isLeftHandOccupied = false;
                            }
                        }
                    }
                }
                else if (observedTag == "TorchHolder")
                {
                    if (observedHasSlots)
                    {

                        if (observedIsNotFull)
                        {
                            if (isRightHandOccupied && rightHandSlotObjTag == "Torch")
                            {
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(rightHandSlotObject);
                                //m_RightHandSlot.DropHeldItem();
                                DropItem(rightHandSlotObject);
                                //isRightHandOccupied = false;
                            }
                            else if (isLeftHandOccupied && leftHandSlotObjTag == "Torch")
                            {
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(leftHandSlotObject);
                                //m_LeftHandSlot.DropHeldItem();
                                DropItem(leftHandSlotObject);
                                //isLeftHandOccupied = false;
                            }
                        }
                        else
                        {
                            observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                            //isRightHandOccupied = true;
                        }
                    }
                }
                else if (observedTag == "ClayPot")
                {
                    if (!isRightHandOccupied)
                    {
                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                        //isRightHandOccupied = true;
                    }
                    else if (!isLeftHandOccupied)
                    {
                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                        //isLeftHandOccupied = true;
                    }

                }
                else if (observedTag == "Ingredient")
                {
                    if (!isRightHandOccupied)
                    {
                        HoldItem(observedObject);

                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                        //isRightHandOccupied = true;
                    }
                    else if (!isLeftHandOccupied)
                    {
                        HoldItem(observedObject);

                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                        //isLeftHandOccupied = true;
                    }
                }
                else if (observedTag == "Torch")
                {
                    if (!isRightHandOccupied)
                    {
                        //    Debug.Log("Right H - Torch is ObsObj");
                        //    Debug.Log("Left H ObjTag - " + leftHandSlotObjTag);
                        if (leftHandSlotObjTag == "Lighter")
                        {
                            //Debug.Log("Right H - Lighter in L hand");
                            observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(leftHandSlotObject);
                        }
                        HoldItem(observedObject);
                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                        //isRightHandOccupied = true;
                        
                    }
                    else if (!isLeftHandOccupied)
                    {
                        //Debug.Log("Left H - Torch is ObsObj");
                        //Debug.Log("Right H ObjTag - " + rightHandSlotObjTag);
                        if (rightHandSlotObjTag == "Lighter")
                        {
                            //Debug.Log("Left H - Lighter in R hand");
                            observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(rightHandSlotObject);
                        }
                        HoldItem(observedObject);
                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                        //isLeftHandOccupied = true;
                        
                    }
                }
                //else if (observedTag == "FirePit")
                //{
                //    if (rightHandSlotObjTag == "Torch")
                //    {
                //        rightHandSlotObject.GetComponent<IInteractionLogicScript>().InteractionRequest(observedObject);
                //    }
                //    else if (leftHandSlotObjTag == "Torch")
                //    {
                //        leftHandSlotObject.GetComponent<IInteractionLogicScript>().InteractionRequest(observedObject);
                //    }
                //}
                else if (observedTag == "Lighter")
                {
                    if (!isRightHandOccupied)
                    {
                        HoldItem(observedObject);
                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                        //isLeftHandOccupied = true;
                    }
                    else if (!isLeftHandOccupied)
                    {
                        HoldItem(observedObject);
                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                        //isLeftHandOccupied = true;
                    }
                }
                else if (observedTag == "Dagger" || observedTag == "Info_puzzleClue" || observedTag == "Altar")
                {
                    observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                }
            }
            //Debug.Log("made it into player interaction request");
            //string observedTag = observedObject.tag;
            //Debug.Log("requester tag: " + observedTag.ToString());

            //if (observedTag == "Bowl")
            //{
            //    if (hasItemSlot)
            //    {
            //        if (isRightHandOccupied)
            //        {
            //            bool observedHadSlot = observedObject.GetComponent<IInteractionLogicScript>().hasItemSlot;
            //            bool observedIsNotFull = !observedObject.GetComponent<IInteractionLogicScript>().allSlotsFull;
            //            if (observedHadSlot && observedIsNotFull)
            //            {
            //                Debug.Log("-------1");
            //                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(GiveItem());
            //            }
            //        }
            //    }
            //}
            //else if (observedTag == "TorchHolder")
            //{
            //    if(hasItemSlot)
            //    {
            //        bool observedHadSlot = observedObject.GetComponent<IInteractionLogicScript>().hasItemSlot;
            //        bool observedIsNotFull = !observedObject.GetComponent<IInteractionLogicScript>().allSlotsFull;
            //        if (observedHadSlot && observedIsNotFull)
            //        {
            //            observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(FindItemByTag("Torch"));
            //        }
            //        else if(!observedIsNotFull)
            //        {
            //            observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
            //        }
            //    }
            //}
            //else if (observedTag == "ClayPot")
            //{
            //    observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
            //}
            //else if (observedTag == "Torch")
            //{
            //    if(FindObject(observedObject))
            //    {
            //        //DropItem(observedObject);
            //    }
            //    else
            //    {
            //        HoldItem(observedObject);
            //        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
            //    }
            //}
            //else if (observedTag == "Ingredient")
            //{
            //    //if (FindObject(observedObject))
            //    //{
            //    //    DropItem(observedObject);
            //    //}
            //    //else
            //    //{
            //        HoldItem(observedObject);
            //        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
            //    //}
            //}
        }
        //allSlotsFull = isRightHandOccupied;
        CheckIfSlotAreFull();
    }

    //public Transform GetSlotTransform(GameObject requester)
    //{
    //    Transform freeSlot = null;
    //    //if(hasItemSlot)
    //    //{
    //    //    freeSlot = FindFreeSlot(requester);
    //    //}

    //    freeSlot = m_RightHand.transform;

    //    return freeSlot;
    //}

    //private Transform FindFreeSlot(GameObject requester)
    //{
    //    Transform freeSlotTransform = null;

    //    for(int i = 0; i < slotList.Count; i++)
    //    {
    //        if(!slotList[i].isSlotFull)
    //        {
    //            Debug.Log("I'm serching for a free slot");
    //            freeSlotTransform = slotList[i].slotTransform;
    //        }
    //    }
    //    Debug.Log("free slot: " + freeSlotTransform.ToString());

    //    return freeSlotTransform;
    //}

    //public GameObject FindObjectByTag(string tag)
    //{
    //    GameObject temp = null;

    //    for (int i = 0; i < slotList.Count; i++)
    //    {
    //        if (slotList[i].objectInSlot != null && slotList[i].objectInSlot.tag == tag)
    //        {
    //            temp = slotList[i].objectInSlot;
    //        }
    //    }

    //    return temp;
    //}

    //public bool FindObject(GameObject objectToFind)
    //{
    //    bool objectFound = false;

    //    for (int i = 0; i < slotList.Count; i++)
    //    {
    //        if (slotList[i].objectInSlot == objectToFind)
    //        {
    //            objectFound = true;
    //        }
    //    }

    //    return objectFound;
    //}

    //public IItemSlotScript GetSlotOfObject(GameObject objectToFind)
    //{
    //    return
    //}

    //public void HoldItem(GameObject item)
    //{
    //    if(!isRightHandOccupied)
    //    {
    //        //item.GetComponent<Rigidbody>().isKinematic = true;
    //        m_RightHand.GetComponent<IItemSlotScript>().HoldItem(item);
    //        isRightHandOccupied = m_RightHand.GetComponent<HandSlotScript>().isSlotFull;
    //    }
    //}

    //public GameObject GiveItem()
    //{
    //    GameObject temp = null;
    //    if(isRightHandOccupied)
    //    {
    //        isRightHandOccupied = false;
    //        temp = m_RightHand.GetComponent<IItemSlotScript>().GiveHeldItem();
    //    }
    //    return temp;
    //}

    //public void DropItem(GameObject itemToDrop)
    //{
    //    int objectIndex = 0;

    //    for(int i = 0; i < slotList.Count; i++)
    //    {
    //        if(slotList[i].objectInSlot == itemToDrop)
    //        {
    //            objectIndex = i;
    //        }
    //    }

    //    slotList[objectIndex].DropHeldItem();
    //}
}
