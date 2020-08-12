using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayLogicScript : MonoBehaviour
{
    [SerializeField]
    private bool isDoorwayOpen;
    [SerializeField]
    private GameObject m_doorSlab;
    [SerializeField]
    private GameObject m_doorPortalParticles;
    [SerializeField]
    private InGameEventControllerScript m_eventController;
    // Start is called before the first frame update
    void Start()
    {
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
}
