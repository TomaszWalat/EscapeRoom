using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchHolderSlotScript : MonoBehaviour, IItemSlotScript
{
    [field: SerializeField]
    public string slotName { get; private set; }
    [field: SerializeField]
    public bool isSlotFull { get; private set; }
    [field: SerializeField]
    public GameObject objectInSlot { get; private set; }
    [field: SerializeField]
    public Transform slotTransform { get; private set; }
    
    public Transform torchSlotTransform;

    private void Start()
    {
        isSlotFull = false;

        slotTransform = torchSlotTransform;
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
