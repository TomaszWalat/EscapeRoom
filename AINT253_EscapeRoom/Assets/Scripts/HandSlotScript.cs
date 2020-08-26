using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlotScript : MonoBehaviour, IItemSlotScript
{
    [SerializeField]
    private bool isHandUp;
    [field: SerializeField]
    public string slotName { get; private set; }
    [field: SerializeField]
    public bool isSlotFull { get; private set; }
    [field: SerializeField]
    public GameObject objectInSlot { get; private set; }
    [field: SerializeField]
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
        //Debug.Log("hand is picking up item");
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
