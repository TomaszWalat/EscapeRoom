using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerLogicScript : MonoBehaviour, IInteractionLogicScript
{
    //[SerializeField]
    //private GameObject daggerBlood;

    [SerializeField]
    private GameObject altarBlood;

    [SerializeField]
    private GameObject altar;

    [SerializeField]
    private bool daggerUsed;

    [SerializeField]
    private InGameEventControllerScript m_eventController;

    // Start is called before the first frame update
    void Start()
    {
        daggerUsed = false;
        //daggerBlood.SetActive(false);
        altarBlood.SetActive(false);
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if (interactionRequester != null && !daggerUsed && m_eventController.GetPuzzleOneStatus() && m_eventController.GetAllLoreExplored())
        {
            if(interactionRequester.tag == "Player")
            {
                daggerUsed = true;
                altarBlood.SetActive(true);
                //daggerBlood.SetActive(true);

                altar.GetComponent<IInteractionLogicScript>().InteractionRequest(altarBlood);
            }
        }
    }
}
