using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchHolderSlotScript : MonoBehaviour, IItemSlotScript
{
    public string slotName { get; private set; }

    public bool isSlotFull { get; private set; }

    public GameObject objectInSlot { get; private set; }

    public Transform slotTransform { get; private set; }

    public Transform bowlSlotTransform;

    private void Start()
    {
        isSlotFull = false;

        slotTransform = bowlSlotTransform;
    }

    public void HoldItem(GameObject item)
    {
        objectInSlot = item;
        isSlotFull = true;
    }

    public GameObject GiveHeldItem()
    {
        GameObject temp = objectInSlot;

        objectInSlot = null;
        isSlotFull = false;

        return temp;
    }

    public void DropHeldItem()
    {
        objectInSlot = null;
        isSlotFull = false;
    }
}
