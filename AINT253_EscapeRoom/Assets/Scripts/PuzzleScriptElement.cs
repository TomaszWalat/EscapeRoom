using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScriptElement : MonoBehaviour
{
    [SerializeField]
    private PuzzleElementScript puzzleElementScript;

    public PuzzleElementScript GetElement()
    {
        return puzzleElementScript;
    }
}
