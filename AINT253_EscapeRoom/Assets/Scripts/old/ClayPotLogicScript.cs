using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayPotLogicScript : MonoBehaviour, IInteractionLogicScript
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

                bool requesterHasSlot = false;
                bool requesterIsNotFull = false;

                if (interactionRequester.TryGetComponent(out AbstractSlotHolderScript slotHolderScript))
                {
                    //Debug.Log("I am: " + gameObject.ToString());
                    //Debug.Log("found a slot holder in requester: " + slotHolderScript.ToString());

                    requesterHasSlot = slotHolderScript.hasItemSlot;
                    requesterIsNotFull = !slotHolderScript.allSlotsFull;
                }

                if (requesterTag == "Player")
                {
                    if (requesterHasSlot && requesterIsNotFull)
                    {
                        GameObject temp;
                        canSpawnItem = false;
                        temp = Instantiate(potContents, transform.position, Quaternion.identity);
                        //Debug.Log("ingredient spawned: " + temp.ToString());
                        //temp.name.Replace("(Clone)", "");
                        //Debug.Log("ingredient spawned: " + temp.name.ToString());
                        interactionRequester.GetComponent<IInteractionLogicScript>().InteractionRequest(temp);

                        //Debug.Log(temp.ToString());
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
