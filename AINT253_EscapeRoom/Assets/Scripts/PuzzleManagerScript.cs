using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerScript : MonoBehaviour
{
    [SerializeField]
    private PuzzleScript m_puzzleOne;
    [SerializeField]
    private PuzzleScript m_puzzleTwo;

    [field: SerializeField]
    public bool m_puzzleOneComplete { get; private set; }
    [field: SerializeField]
    public bool m_puzzleTwoComplete { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        m_puzzleOneComplete = false;
        m_puzzleTwoComplete = false;

    }

    public void puzzleOneCompleted()
    {
        m_puzzleOneComplete = true;
    }

    public void puzzleTwoCompleted()
    {
        m_puzzleTwoComplete = true;
    }

    public void checkPuzzles()
    {
        m_puzzleOneComplete = m_puzzleOne.puzzleComplete;
        m_puzzleTwoComplete = m_puzzleTwo.puzzleComplete;
    }
}
