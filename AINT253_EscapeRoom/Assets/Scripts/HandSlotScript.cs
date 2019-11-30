using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlotScript : MonoBehaviour, IItemSlotScript
{
    private bool isHandUp;

    public string slotName { get; private set; }

    public bool isSlotFull { get; private set; }

    public GameObject objectInSlot { get; private set; }

    public Transform slotTransform { get; private set; }

    public Transform handSlotTransform;
    public GameObject handModel;

    private void Start()
    {
        isHandUp = true;
        isSlotFull = false;

        slotTransform = handSlotTransform;
    }

    public void HoldItem(GameObject item)
    {
        Debug.Log("hand is picking up item");
        objectInSlot = item;
        isSlotFull = true;
        ToggleHandModel();
    }

    public GameObject GiveHeldItem()
    {
        GameObject temp = objectInSlot;

        objectInSlot = null;
        isSlotFull = false;

        ToggleHandModel();

        return temp;
    }

    public void DropHeldItem()
    {
        //objectInSlot.transform.parent = null;

        //objectInSlot.GetComponent<IPickableObjectScript>().isDetached = true;

        objectInSlot = null;
        isSlotFull = false;

        ToggleHandModel();
    }

    private void ToggleHandModel()
    {
        if(isHandUp)
        {
            handModel.SetActive(false);

            isHandUp = false;
        }
        else
        {
            handModel.SetActive(true);

            isHandUp = true;
        }
    }
}
