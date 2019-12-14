using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualPuzzleTemplate : AbstractPuzzleTemplate
{
    //public GameObject piece1b;
    //public GameObject piece2b;
    //public GameObject piece3;

    // Start is called before the first frame update
    private void Awake()
    {
        puzzleTemplateList = new List<IPuzzlePieceScript>();

        FindPuzzlePieces();
    }
    void Start()
    {
        //puzzleTemplateList = new List<IPuzzlePieceScript>();

        //FindPuzzlePieces();

        //Debug.Log("ritual template count: " + puzzleTemplateList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
