using System.Collections;
using System.Collections.Generic;
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
        //allSlotsFull = false;
        //slotList = new List<IItemSlotScript>(GetComponentsInChildren<IItemSlotScript>());

        FindItemSlots();
        //Debug.Log(slotList.ToString());
        CheckIfSlotAreFull();

        m_RightHandSlot = m_RightHand.GetComponent<IItemSlotScript>();
        m_LeftHandSlot = m_LeftHand.GetComponent<IItemSlotScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
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


                if (observedTag == "Bowl")
                {
                    if(observedHasSlots && observedIsNotFull)
                    {
                        if (m_RightHandSlot.isSlotFull)
                        {
                            if(m_RightHandSlot.objectInSlot.tag == "Torch" && m_RightHandSlot.objectInSlot.GetComponent<TorchLogicScript>().isTorchLit)
                            {
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(m_RightHandSlot.objectInSlot);
                            }
                            else
                            {
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(m_RightHandSlot.objectInSlot);
                                m_RightHandSlot.DropHeldItem();
                            }
                            
                            
                        }
                    }
                }
                else if(observedTag == "TorchHolder")
                {
                    if (observedHasSlots)
                    {

                        if (observedIsNotFull)
                        {
                            if (m_RightHandSlot.isSlotFull && m_RightHandSlot.objectInSlot.tag == "Torch")
                            {
                                observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(m_RightHandSlot.objectInSlot);
                                m_RightHandSlot.DropHeldItem();
                            }
                        }
                        else
                        {
                            observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                        }
                    }
                }
                else if(observedTag == "ClayPot")
                {
                    if(!m_RightHandSlot.isSlotFull)
                    {
                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                    }

                }
                else if(observedTag == "Ingredient")
                {
                    if (!m_RightHandSlot.isSlotFull)
                    {
                        HoldItem(observedObject);

                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                    }
                }
                else if(observedTag == "Torch")
                {
                    if(!m_RightHandSlot.isSlotFull)
                    {
                        HoldItem(observedObject);
                        observedObject.GetComponent<IInteractionLogicScript>().InteractionRequest(gameObject);
                    }
                }
                else if(observedTag == "FirePit")
                {
                    if(m_RightHandSlot.objectInSlot.tag == "Torch")
                    {
                        m_RightHandSlot.objectInSlot.GetComponent<IInteractionLogicScript>().InteractionRequest(observedObject);
                    }
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
