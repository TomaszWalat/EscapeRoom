using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchHolderBehaviour : MonoBehaviour, IObjectReciever, IObjectTransmitter, InteractableObject
{
    [SerializeField]
    private GameObject torchOrigin;
    [SerializeField]
    private GameObject torchOriginChild;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeObject(GameObject objectRecieved)
    {
        if(objectRecieved.TryGetComponent<TorchBehaviour>(out TorchBehaviour tb))
        {
            //torchOrigin.AddComponent(objectRecieved);
            objectRecieved.transform.parent = transform;
            torchOriginChild = objectRecieved;
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
