using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject controlsPanel;
    private bool isControlsPanelUp;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isControlsPanelUp = false;
        Cursor.lockState = CursorLockMode.None;
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void Play()
    {
        SceneManager.LoadScene("InGame", LoadSceneMode.Single);
    }

    public void ToggleControlsPanel()
    {
        isControlsPanelUp = !isControlsPanelUp;
        controlsPanel.SetActive(isControlsPanelUp);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
