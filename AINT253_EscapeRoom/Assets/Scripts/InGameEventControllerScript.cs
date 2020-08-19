using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameEventControllerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject lighter;
    [SerializeField]
    private HandLogicScript playerHandLogicScript;

    [SerializeField]
    private PuzzleManagerScript m_puzzleManagerScript;
    [SerializeField]
    private DoorwayLogicScript m_doorwayLogicScript;

    [SerializeField]
    private GameObject m_caveSystemPartTwo;
    [SerializeField]
    private GameObject m_caveSystemPartThree;
    [SerializeField]
    private GameObject m_caveSystemPartTwoBlockade;

    [SerializeField]
    private bool m_puzzleOneComplete;
    [SerializeField]
    private bool m_puzzleTwoComplete;

    [SerializeField]
    private bool m_gameStarted;
    [SerializeField]
    private bool m_playerIsByEntrance;

    // Start is called before the first frame update
    void Start()
    {
        m_gameStarted = false;
        m_puzzleOneComplete = false;
        m_puzzleTwoComplete = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!m_gameStarted)
        {

            StartCoroutine(player.GetComponent<CameraShakeScript>().Shake(2.5f, 0.5f));
            m_gameStarted = true;
            m_caveSystemPartTwo.SetActive(true);
            m_caveSystemPartThree.SetActive(false);
            m_caveSystemPartTwoBlockade.SetActive(false);
            playerHandLogicScript.InteractionRequest(lighter);
        }

        if(m_puzzleManagerScript.m_puzzleOneComplete && !m_puzzleOneComplete)
        {
            puzzleOneCompleted();
        }
        if (m_puzzleManagerScript.m_puzzleTwoComplete && !m_puzzleTwoComplete)
        {
            puzzleTwoCompleted();
        }
        //if(Input.GetKeyDown(KeyCode.L))
        //{
        //    StartCoroutine(player.GetComponent<CameraShakeScript>().Shake(5.0f, 0.1f));
        //}
    }

    public void puzzleOneCompleted()
    {
        m_puzzleOneComplete = true;

        player.GetComponent<CameraShakeScript>().SetShakeConstantly(true);
        StartCoroutine(player.GetComponent<CameraShakeScript>().ShakeConstant(1.5f, 0.25f));
        //changeCaveSystem();
    }

    public void puzzleTwoCompleted()
    {
        m_puzzleTwoComplete = true;

        StartCoroutine(player.GetComponent<CameraShakeScript>().Shake(1.5f, 0.5f));
        m_doorwayLogicScript.OpenDoorway();
        //Exit();
    }

    private void changeCaveSystem()
    {
        m_caveSystemPartTwo.SetActive(false);
        m_caveSystemPartThree.SetActive(true);
        m_caveSystemPartTwoBlockade.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerIsByEntrance = true;
            if(m_puzzleOneComplete)
            {
                player.GetComponent<CameraShakeScript>().SetShakeConstantly(false);
                changeCaveSystem();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerIsByEntrance = false;
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
