using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoorwayLogicScript : MonoBehaviour, IInteractionLogicScript
{
    [SerializeField]
    private bool isDoorwayOpen;
    [SerializeField]
    private GameObject m_doorSlab;
    [SerializeField]
    private GameObject m_doorPortalParticles;
    [SerializeField]
    private InGameEventControllerScript m_eventController;

    [SerializeField]
    private bool hasBeenClicked;
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    private Text textStorage;

    // Start is called before the first frame update
    void Start()
    {
        hasBeenClicked = false;
        isDoorwayOpen = false;
        m_doorPortalParticles.SetActive(false);
        m_doorSlab.SetActive(true);
    }

    public void OpenDoorway()
    {
        m_doorSlab.SetActive(false);
        m_doorPortalParticles.SetActive(true);
        isDoorwayOpen = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && isDoorwayOpen)
        {
            m_eventController.Exit();
        }
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if (interactionRequester != null)
        {
            if (interactionRequester.tag == "Player")
            {
                if (!hasBeenClicked)
                {
                    Debug.Log("Analysing door");
                    hasBeenClicked = true;
                    textMeshProUGUI.text += textStorage.text;
                }
            }
        }
    }

    public bool GetHasBeenClicked()
    {
        return hasBeenClicked;
    }
}
