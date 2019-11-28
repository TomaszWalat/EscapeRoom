using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemSlotScript
{
    string slotName { get; }

    bool isSlotFull { get; }

    Transform slotTransform { get; }

    GameObject objectInSlot { get; }

    void HoldItem(GameObject item);

    GameObject GiveHeldItem();

    void DropHeldItem();
}
