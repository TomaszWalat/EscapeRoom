using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarLogicScript : MonoBehaviour
{
    [SerializeField]
    private FOWPieceScript[] fOW_pieces;

    // Start is called before the first frame update
    void Start()
    {
        fOW_pieces = GetComponentsInChildren<FOWPieceScript>();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void TurnOnPieces()
    {
        foreach(FOWPieceScript piece in fOW_pieces)
        {
            piece.gameObject.SetActive(true);
        }
    }

    public void TurnOffPieces()
    {
        foreach (FOWPieceScript piece in fOW_pieces)
        {
            piece.gameObject.SetActive(false);
        }
    }
}
