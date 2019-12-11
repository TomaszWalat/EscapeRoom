using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingTorchesTemplateScript : AbstractPuzzleTemplate
{
    //public GameObject piece1r;
    //public GameObject piece2r;

    public bool remainingTorchesAreUnlit { get; private set; }

    public PuzzleElementScript puzzleElementScript;
    private void Awake()
    {
        puzzleTemplateList = new List<IPuzzlePieceScript>();

        FindPuzzlePieces();
    }

    // Start is called before the first frame update
    void Start()
    {
        //puzzleTemplateList = new List<IPuzzlePieceScript>();

        //FindPuzzlePieces();
        remainingTorchesAreUnlit = true;
        Invoke("PrimeElement", 1f);
        CheckUnlitTorches();
    }

    public void PrimeElement()
    {
            Debug.Log("primeing element");
        for(int i = 0; i < puzzleTemplateList.Count; i++)
        {
            TorchHolderLogicScript temp = puzzleTemplateList[i] as TorchHolderLogicScript;
            //Debug.Log("puzzle piece being added: " + temp.gameObject.ToString());
            puzzleElementScript.AddPuzzlePiece(temp.gameObject);
            //Debug.Log("puzzle piece being added: " + temp.gameObject.ToString());
        }
        //puzzleElementScript.PrintPieceList();
    }

    public void CheckUnlitTorches()
    {
        for(int i = 0; i < puzzleTemplateList.Count; i++)
        {
            if(puzzleTemplateList[i].puzzlePieceComplete)
            {
                remainingTorchesAreUnlit = false;
            }
        }
    }
}
