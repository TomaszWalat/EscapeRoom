using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerScript : MonoBehaviour
{
    [SerializeField]
    private PuzzleScript m_puzzleOne;
    [SerializeField]
    private PuzzleScript m_puzzleTwo;

    [SerializeField]
    private bool m_puzzleOneComplete;
    [SerializeField]
    private bool m_puzzleTwoComplete;

    // Start is called before the first frame update
    void Start()
    {
        m_puzzleOneComplete = false;
        m_puzzleTwoComplete = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void puzzleOneCompleted()
    {
        m_puzzleOneComplete = true;
    }

    public void puzzleTwoCompleted()
    {
        m_puzzleTwoComplete = true;
    }
}
