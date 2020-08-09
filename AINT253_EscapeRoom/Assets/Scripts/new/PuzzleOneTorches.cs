using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PuzzleOneTorches : MonoBehaviour
{
    [SerializeField]
    private bool puzzleComplete;

    [SerializeField]
    private GameObject torchHolderOne;
    [SerializeField]
    private GameObject torchHolderTwo;
    [SerializeField]
    private GameObject torchHolderThree;
    [SerializeField]
    private GameObject torchHolderFour;
    [SerializeField]
    private GameObject torchHolderFive;
    [SerializeField]
    private GameObject torchHolderSix;
    [SerializeField]
    private GameObject torchHolderSeven;
    [SerializeField]
    private GameObject torchHolderEight;
    [SerializeField]
    private GameObject torchHolderNine;
    [SerializeField]
    private GameObject torchHolderTen;
    [SerializeField]
    private GameObject torchHolderEleven;
    [SerializeField]
    private GameObject torchHolderTwelve;

    private List<GameObject> torchHoldersTemplate;

    private List<GameObject> torchHoldersActual;

    private bool allTorchesLit;

    private bool torchesInOrder;

    // Start is called before the first frame update
    void Start()
    {
        torchHoldersTemplate = new List<GameObject>();

        torchHoldersTemplate.Add(torchHolderOne);
        torchHoldersTemplate.Add(torchHolderTwo);
        torchHoldersTemplate.Add(torchHolderThree);
        torchHoldersTemplate.Add(torchHolderFour);
        torchHoldersTemplate.Add(torchHolderFive);
        torchHoldersTemplate.Add(torchHolderSix);
        torchHoldersTemplate.Add(torchHolderSeven);
        torchHoldersTemplate.Add(torchHolderEight);
        torchHoldersTemplate.Add(torchHolderNine);
        torchHoldersTemplate.Add(torchHolderTen);
        torchHoldersTemplate.Add(torchHolderEleven);
        torchHoldersTemplate.Add(torchHolderTwelve);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void CheckTorchOrder()
    {
        for(int i = 0; i < torchHoldersTemplate.Count; i++)
        {
            Console.WriteLine("i = " + i + " : flag + comparison = " + (torchesInOrder && (torchHoldersTemplate[i] == torchHoldersActual[i])));
            torchesInOrder = torchesInOrder && (torchHoldersTemplate[i] == torchHoldersActual[i]);
        }
    }
}
