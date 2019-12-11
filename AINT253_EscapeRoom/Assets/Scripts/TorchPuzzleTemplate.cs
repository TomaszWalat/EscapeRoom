using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPuzzleTemplate : AbstractPuzzleTemplate
{
    //public GameObject piece1t;
    //public GameObject piece2t;
    //public GameObject piece3t;
    //public GameObject piece4;
    //public GameObject piece5;
    //public GameObject piece6;
    //public GameObject piece7;
    //public GameObject piece8;
    //public GameObject piece9;
    //public GameObject piece10;
    //public GameObject piece11;
    //public GameObject piece12;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
