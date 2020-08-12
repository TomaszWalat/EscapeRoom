using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PickableObjectScript : MonoBehaviour
{
    [field: SerializeField]
    public bool isPickable { get; protected set; }
    [field: SerializeField]
    public bool isDetached { get; protected set; }
    [field: SerializeField]
    public Transform parentTransform { get; protected set; }

    int counterP = 0;

    //void GetPickedUp(Transform parentTransform);

    //void GetDropped();

    //void TogglePickability();

    //void SetKinematic(bool isKinematic);

    protected void GetPickedUp(Transform newParent)
    {
        if (newParent != null)
        {
            parentTransform = newParent;
            SetKinematic(true);
            transform.SetParent(parentTransform, true);
            transform.SetPositionAndRotation(newParent.position, newParent.rotation);

            isDetached = false;
        }
    }



    public void GetDropped()
    {
        //UnityEngine.Debug.Log(counterP + " P >>> I am " + this.ToString());
        //UnityEngine.Debug.Log(counterP + " P >>> My parent is " + parentTransform);
        counterP++;
        parentTransform.GetComponentInParent<IInteractionLogicScript>().InteractionRequest(gameObject);
        parentTransform = null;
        transform.SetParent(null);
        SetKinematic(false);

        isDetached = true;
    }

    protected void SetKinematic(bool isKinematic)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = isKinematic;
    }

    public void SetPickability(bool canBePickedUp)
    {
        isPickable = canBePickedUp;
    }
}
