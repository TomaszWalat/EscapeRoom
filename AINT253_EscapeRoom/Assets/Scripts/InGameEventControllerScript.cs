using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using MilkShake;

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
    private DoorwayProximityScript doorwayProximityScript;
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

    [SerializeField]
    private bool m_playerIsByExit;


    [SerializeField]
    private GameObject playerCamera;
    [SerializeField]
    private GameObject playerHands;

    [SerializeField]
    private LogEventsScript logEventsScript;

    [SerializeField]
    private WallCarvingLogicScript wallLoreOne;
    [SerializeField]
    private WallCarvingLogicScript wallLoreTwo;
    [SerializeField]
    private WallCarvingLogicScript wallLoreThree;
    [SerializeField]
    private WallCarvingLogicScript wallLoreFour;

    [SerializeField]
    private bool allLoreExplored;

    [SerializeField]
    private bool allInformationDiscovered;

    //[SerializeField]
    //private GameObject shakeSource;

    //[SerializeField]
    //private ShakePreset shakePreset;

    // Start is called before the first frame update
    void Start()
    {
        allInformationDiscovered = false;
        allLoreExplored = false;
        m_gameStarted = false;
        m_puzzleOneComplete = false;
        m_puzzleTwoComplete = false;
        m_playerIsByExit = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!m_gameStarted)
        {
            StartCoroutine(playerCamera.GetComponent<CameraShakeScript>().Shake(2.5f, 0.5f));
            StartCoroutine(playerHands.GetComponent<CameraShakeScript>().Shake(2.5f, 0.01f));
            logEventsScript.TriggerEvent_Beginning();
            //StartCoroutine(player.GetComponent<CameraShakeScript>().Shake(2.5f, 0.5f));
            m_gameStarted = true;
            m_caveSystemPartTwo.SetActive(true);
            m_caveSystemPartThree.SetActive(false);
            m_caveSystemPartTwoBlockade.SetActive(false);
            playerHandLogicScript.InteractionRequest(lighter);
        }

        if (!m_puzzleOneComplete && m_puzzleManagerScript.m_puzzleOneComplete)
        {
            puzzleOneCompleted();
        }
        if (!m_puzzleTwoComplete && m_puzzleManagerScript.m_puzzleTwoComplete)
        {
            puzzleTwoCompleted();
        }
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    //player.GetComponentInChildren<Shaker>().Shake(shakePreset);
        //    //shakeSource.GetComponent<CinemachineImpulseSource>().GenerateImpulse();
        //    StartCoroutine(playerCamera.GetComponent<CameraShakeScript>().Shake(5.0f, 0.1f));
        //    StartCoroutine(playerHands.GetComponent<CameraShakeScript>().Shake(5.0f, 0.01f));
        //}

        if (!allInformationDiscovered && m_puzzleTwoComplete && doorwayProximityScript.GetStatus())
        {
            allInformationDiscovered = true;
            logEventsScript.TriggerEvent_Ending();
        }

        allLoreExplored = wallLoreOne.GetHasBeenTranslated() && wallLoreTwo.GetHasBeenTranslated() && wallLoreThree.GetHasBeenTranslated() && wallLoreFour.GetHasBeenTranslated() && m_doorwayLogicScript.GetHasBeenClicked();
    }

    public void puzzleOneCompleted()
    {
        m_puzzleOneComplete = true;

        playerCamera.GetComponent<CameraShakeScript>().SetShakeConstantly(true);
        playerHands.GetComponent<CameraShakeScript>().SetShakeConstantly(true);
        StartCoroutine(playerCamera.GetComponent<CameraShakeScript>().ShakeConstant(1.5f, 0.25f));
        StartCoroutine(playerHands.GetComponent<CameraShakeScript>().ShakeConstant(1.5f, 0.01f));
        logEventsScript.TriggerEvent_PuzzleOneFinished();
        //StartCoroutine(player.GetComponent<CameraShakeScript>().ShakeConstant(1.5f, 0.25f));
        //changeCaveSystem();
    }

    public void puzzleTwoCompleted()
    {
        m_puzzleTwoComplete = true;

        //StartCoroutine(player.GetComponent<CameraShakeScript>().Shake(1.5f, 0.5f));
        StartCoroutine(playerCamera.GetComponent<CameraShakeScript>().Shake(1.5f, 0.5f));
        StartCoroutine(playerHands.GetComponent<CameraShakeScript>().Shake(1.5f, 0.01f));
        logEventsScript.TriggerEvent_PuzzleTwoFinished();
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
                playerCamera.GetComponent<CameraShakeScript>().SetShakeConstantly(false);
                playerHands.GetComponent<CameraShakeScript>().SetShakeConstantly(false);
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

    public bool GetPuzzleOneStatus()
    {
        return m_puzzleOneComplete;
    }

    public bool GetPuzzleTwoStatus()
    {
        return m_puzzleTwoComplete;
    }

    public bool GetAllLoreExplored()
    {
        return allLoreExplored;
    }
}
