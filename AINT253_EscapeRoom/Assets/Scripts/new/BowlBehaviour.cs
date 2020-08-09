using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlBehaviour : MonoBehaviour, IObjectReciever, InteractableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool RecieveObject(GameObject incomingObject)
    {
        bool objectRecieved = false;

        return objectRecieved;
    }

    public GameObject TransmitObject()
    {
        return null;
    }

    public void interactionRequest(GameObject interactionRequester)
    {

    }
}
