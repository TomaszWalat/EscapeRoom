using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour, IActionScript
{
    public bool puzzleComplete;

    public List<PuzzleElementScript> puzzleElements { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        puzzleComplete = false;
        puzzleElements = new List<PuzzleElementScript>(GetComponents<PuzzleElementScript>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckElements()
    {
        puzzleComplete = true;

        for (int i = 0; i < puzzleElements.Count; i++)
        {
            if (!puzzleElements[i].elementComplete)
            {
                puzzleComplete = false;
            }
        }
    }

    public void PerformAction()
    {

    }
}
