﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private DoorwayBehaviour m_doorwayBehaviour;

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!m_gameStarted)
        {
            m_gameStarted = true;
            m_caveSystemPartTwo.SetActive(true);
            m_caveSystemPartThree.SetActive(false);
            m_caveSystemPartTwoBlockade.SetActive(false);
            playerHandLogicScript.InteractionRequest(lighter);
        }
    }

    public void puzzleOneCompleted()
    {
        m_puzzleOneComplete = true;
        changeCaveSystem();
    }

    public void puzzleTwoCompleted()
    {
        m_puzzleTwoComplete = true;
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerIsByEntrance = false;
        }
    }
}
