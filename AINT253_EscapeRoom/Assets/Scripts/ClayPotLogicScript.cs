using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayPotActionScript : MonoBehaviour, IInteractionLogicScript
{
    public GameObject potContents;

    public float itemPickUpDelay;

    private bool canSpawnItem;

    // Start is called before the first frame update
    void Start()
    {
        canSpawnItem = true;
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if(canSpawnItem)
        {
            if (interactionRequester != null)
            {
                string requesterTag = interactionRequester.tag;

                Debug.Log("made it into clay pots's request");

                if (requesterTag == "Player")
                {
                    bool requesterHasSlot = interactionRequester.GetComponent<IInteractionLogicScript>().hasItemSlot;
                    bool requesterIsHoldingItem = interactionRequester.GetComponent<IInteractionLogicScript>().allSlotsFull;
                    
                    if (requesterHasSlot && !requesterIsHoldingItem)
                    {
                        GameObject temp;
                        canSpawnItem = false;
                        temp = Instantiate(potContents, transform.position, Quaternion.identity);
                        temp.GetComponent<InteractableObjectScript>();
                        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(temp);

                        Debug.Log(temp.ToString());
                        Invoke("DelayPickUp", itemPickUpDelay);
                    }
                }
            }
        }
    }

    private void DelayPickUp()
    {
        canSpawnItem = true;
    }
}
