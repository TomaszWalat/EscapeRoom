using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionBehaviour : MonoBehaviour, IObjectReciever, IObjectTransmitter, InteractableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interactWith(GameObject interactionObject)
    {
        if (interactionObject.TryGetComponent<InteractableObject>(out InteractableObject iO))
        { 
            
        }
    }

    public GameObject TransmitObject()
    {
        return null;
    }

    public bool RecieveObject(GameObject incomingObject) 
    {
        bool objectRecieved = false;

        return objectRecieved;
    }

    public void interactionRequest(GameObject interactionRequester)
    { 
    
    }
}
