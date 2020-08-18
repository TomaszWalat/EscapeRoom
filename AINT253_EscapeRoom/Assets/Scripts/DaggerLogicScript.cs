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

    // Start is called before the first frame update
    void Start()
    {
        daggerUsed = false;
        //daggerBlood.SetActive(false);
        altarBlood.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if (interactionRequester != null && !daggerUsed)
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
