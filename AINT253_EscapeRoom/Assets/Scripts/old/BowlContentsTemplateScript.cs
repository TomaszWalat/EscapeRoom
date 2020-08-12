using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlContentsTemplateScript : AbstractPuzzleTemplate
{
    // Start is called before the first frame update
    void Start()
    {
        puzzleTemplateList = new List<IPuzzlePieceScript>();

        FindPuzzlePieces();
    }
}
