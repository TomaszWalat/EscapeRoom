using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class PuzzleScript : MonoBehaviour, IActionScript
{
    [field: SerializeField]
    public bool puzzleComplete { get; private set; }

    [field: SerializeField]
    public List<PuzzleScriptElement> puzzleElements { get; private set; }

    [SerializeField]
    private PuzzleManagerScript m_puzzleManager;

    // Start is called before the first frame update
    void Start()
    {
        puzzleComplete = false;
        puzzleElements = new List<PuzzleScriptElement>(GetComponents<PuzzleScriptElement>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //CheckElements();
    }

    public void CheckElements()
    {
        Debug.Log("Checking elemenets");
        puzzleComplete = true;

        for (int i = 0; i < puzzleElements.Count; i++)
        {
            Debug.Log("Number of elements: " + puzzleElements.Count);
            Debug.Log("Puzzle Complete: " + puzzleComplete);
            if (!puzzleElements[i].GetElement().elementComplete)
            {
                puzzleComplete = false;//puzzleComplete && puzzleElements[i].GetElement().elementComplete;
            }
            Debug.Log("Puzzle Complete After: " + puzzleComplete);
        }

        if(puzzleComplete)// && puzzleElements.Count > 0)
        {
            m_puzzleManager.checkPuzzles();
        }
    }

    public void PrintElementList()
    {
        for (int i = 0; i < puzzleElements.Count; i++)
        {
            Debug.Log("element " + i + ": " + puzzleElements[i].GetElement().ToString());
        }
    }

    public void PerformAction()
    {

    }
}
