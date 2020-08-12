using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleElementScript : MonoBehaviour
{
    [field: SerializeField]
    public bool elementComplete { get; private set; }

    [field: SerializeField]
    public List<IPuzzlePieceScript> puzzlePieces { get; private set; }

    public List<IPuzzlePieceScript> puzzleElementTemplate { get; private set; }

    [SerializeField]
    private AbstractPuzzleTemplate puzzleTemplate;

    [SerializeField]
    private PuzzleScript m_puzzleScript;

    // Start is called before the first frame update
    void Start()
    {
        puzzlePieces = new List<IPuzzlePieceScript>();
        elementComplete = false;
        puzzleElementTemplate = puzzleTemplate.puzzleTemplateList;
        //Debug.Log("template: " + puzzleElementTemplate.ToString());

        CheckPieces();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //CheckPieces();
    }

    public void CheckPieces()
    {
        //Debug.Log("pieces count: " + puzzlePieces.Count);
        ////Debug.Log("template: " + puzzleElementTemplate.ToString());
        //Debug.Log("template count: " + puzzleElementTemplate.Count);
        //Debug.Log("I am: " + gameObject.ToString());
        if (puzzlePieces.Count == puzzleElementTemplate.Count)
        {
            //Debug.Log("1");
            elementComplete = true;
            for (int i = 0; i < puzzlePieces.Count; i++)
            {
                if (puzzlePieces[i] != puzzleElementTemplate[i] || !puzzlePieces[i].puzzlePieceComplete)
                {
                    //Debug.Log("puzzle piece: " + puzzlePieces[i].ToString());
                    //Debug.Log("template piece: " + puzzleElementTemplate[i].ToString());
                    //Debug.Log("puzzle piece is complete: " + puzzlePieces[i].puzzlePieceComplete);
                    //Debug.Log("2");
                    elementComplete = false;
                }
            }
        }
        else
        {
            //Debug.Log("3");
            elementComplete = false;
        }

        if (elementComplete)
        {
            m_puzzleScript.CheckElements();
        }
        
    }

    public void AddPuzzlePiece(GameObject puzzleObject)
    {
        //CheckPieces();
        if(puzzleObject.TryGetComponent(out IPuzzlePieceScript puzzlePieceScript))
        {
            //Debug.Log(" piece being added: " + puzzlePieceScript.ToString());
            //PrintPieceList();
            puzzlePieces.Add(puzzlePieceScript);
        }
        CheckPieces();

    }

    public void RemovePuzzlePiece(GameObject piece)
    {
        //CheckPieces();
        if (piece.TryGetComponent(out IPuzzlePieceScript puzzlePieceScript))
        {
            if (puzzlePieces.Contains(puzzlePieceScript))
            {
                PrintPieceList();
                puzzlePieces.Remove(puzzlePieceScript);
                PrintPieceList();
            }
                //Debug.Log(" piece being added: " + puzzlePieceScript.ToString());
                //PrintPieceList();
                //puzzlePieces.Add(puzzlePieceScript);
        }
        CheckPieces();

    }

    public void PrintPieceList()
    {
        for(int i = 0; i < puzzlePieces.Count; i++)
        {
            Debug.Log("piece " + i + ": " + puzzlePieces[i].ToString());
        }
    }
}
