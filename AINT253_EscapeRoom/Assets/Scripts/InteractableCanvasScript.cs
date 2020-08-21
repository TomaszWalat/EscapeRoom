using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class InteractableCanvasScript : MonoBehaviour
{

    [SerializeField]
    private bool isCursorFree;

    [SerializeField]
    private bool isMapOpen;
    [SerializeField]
    private GameObject mapPanel;
    [SerializeField]
    private GameObject mapCamera;

    [SerializeField]
    private bool isPauseMenuOpen;
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private bool isLogOpen;
    [SerializeField]
    private GameObject logPanel;

    [SerializeField]
    private bool isInteractiblePanelUp;
    [SerializeField]
    private GameObject interactablePanel;

    [SerializeField]
    private bool isControlsPanelUp;
    [SerializeField]
    private GameObject controlsPanel;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isCursorFree = false;
        isMapOpen = false;
        isPauseMenuOpen = false;
        isLogOpen = false;
        isInteractiblePanelUp = true;
        isControlsPanelUp = false;

        //Cursor.lockState = CursorLockMode.Locked;
        interactablePanel.SetActive(true);
        mapPanel.SetActive(false);
        mapCamera.SetActive(false);
        pausePanel.SetActive(false);
        logPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isLogOpen && !isPauseMenuOpen)
        {
            //ToggleInteractablePanel();
            ToggleLevelMap();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isMapOpen && !isPauseMenuOpen)
        {
            //ToggleInteractablePanel();
            ToggleLog();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMapOpen)
            {
                //Cursor.lockState = CursorLockMode.Locked;
                ToggleLevelMap();
                //ToggleInteractablePanel();
            }
            else if (isLogOpen)
            {
 
                ToggleLog();
                //ToggleInteractablePanel();
            }
            else if(isControlsPanelUp)
            {
                ToggleControlsPanel();
            }
            else
            {
                TogglePauseMenu();
                //ToggleInteractablePanel();
            }
        }
    }

    private void ToggleLevelMap()
    {
        isMapOpen = !isMapOpen;
        mapPanel.SetActive(isMapOpen);
        mapCamera.SetActive(isMapOpen);
    }

    public void TogglePauseMenu()
    {
        isPauseMenuOpen = !isPauseMenuOpen;
        //if (isPauseMenuOpen)
        //{
        //    Debug.Log("Opening pause Menu");
        //    ToggleInteractablePanel();

        //}
        //else if(!isPauseMenuOpen)
        //{
        //    Debug.Log("Closing pause Menu");
        //    ToggleInteractablePanel();
        //    //Cursor.lockState = CursorLockMode.None;
        //}

        pausePanel.SetActive(isPauseMenuOpen);

        if (isPauseMenuOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    private void ToggleLog()
    {
        isLogOpen = !isLogOpen;
        logPanel.SetActive(isLogOpen);
        if (isLogOpen)
        {
            //Debug.Log("Locking cursor");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else //if (!isInteractiblePanelUp)
        {
            //Debug.Log("Unlocking Cursor");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void ToggleInteractablePanel()
    {
        isInteractiblePanelUp = !isInteractiblePanelUp;
        interactablePanel.SetActive(isInteractiblePanelUp);
        //if (isInteractiblePanelUp)
        //{
        //    //Debug.Log("Locking cursor");
        //    //Cursor.lockState = CursorLockMode.None;
        //    //Cursor.visible = true;
        //}
        //else //if (!isInteractiblePanelUp)
        //{
        //    //Debug.Log("Unlocking Cursor");
        //    //Cursor.lockState = CursorLockMode.Locked;
        //    //Cursor.visible = false;
        //}
    }

    public void ToggleControlsPanel()
    {
        isControlsPanelUp = !isControlsPanelUp;
        controlsPanel.SetActive(isControlsPanelUp);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
