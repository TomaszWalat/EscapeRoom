using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerScript : MonoBehaviour
{
    [SerializeField]
    private PuzzleOneTorches m_puzzleOne;
    [SerializeField]
    private PuzzleTwoAltars m_puzzleTwo;
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
    private GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        m_puzzleOneComplete = false;
        m_puzzleTwoComplete = false;

        m_caveSystemPartTwo.SetActive(true);
        m_caveSystemPartThree.SetActive(false);
        m_caveSystemPartTwoBlockade.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
