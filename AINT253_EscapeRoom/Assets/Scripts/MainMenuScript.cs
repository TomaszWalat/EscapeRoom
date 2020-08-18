using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("InGame", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
