using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPickableObjectScript : MonoBehaviour
{
    public bool isPickable { get; protected set; }

    public bool isDetached { get; protected set; }

    public Transform parentTransform { get; protected set; }

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



    protected void GetDropped()
    {
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

    protected void SetPickability(bool canBePickedUp)
    {
        isPickable = canBePickedUp;
    }
}
