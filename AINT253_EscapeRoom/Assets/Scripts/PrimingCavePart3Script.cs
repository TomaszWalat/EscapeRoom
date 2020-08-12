using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimingCavePart3Script : MonoBehaviour
{
    [SerializeField]
    private GameObject torch1;
    [SerializeField]
    private GameObject torch2;
    [SerializeField]
    private GameObject torch3;
    [SerializeField]
    private GameObject torch4;
    [SerializeField]
    private GameObject torch5;
    [SerializeField]
    private GameObject torch6;
    [SerializeField]
    private GameObject torch7;
    [SerializeField]
    private GameObject torch8;

    [SerializeField]
    private GameObject torchHolder1;
    [SerializeField]
    private GameObject torchHolder2;
    [SerializeField]
    private GameObject torchHolder3;
    [SerializeField]
    private GameObject torchHolder4;
    [SerializeField]
    private GameObject torchHolder5;
    [SerializeField]
    private GameObject torchHolder6;
    [SerializeField]
    private GameObject torchHolder7;
    [SerializeField]
    private GameObject torchHolder8;



    // Start is called before the first frame update
    void Start()
    {
        PrimeTorches();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PrimeTorches()
    {
        torchHolder1.GetComponent<TorchHolderLogicScript>().InteractionRequest(torch1);
        torchHolder2.GetComponent<TorchHolderLogicScript>().InteractionRequest(torch2);
        torchHolder3.GetComponent<TorchHolderLogicScript>().InteractionRequest(torch3);
        torchHolder4.GetComponent<TorchHolderLogicScript>().InteractionRequest(torch4);
        torchHolder5.GetComponent<TorchHolderLogicScript>().InteractionRequest(torch5);
        torchHolder6.GetComponent<TorchHolderLogicScript>().InteractionRequest(torch6);
        torchHolder7.GetComponent<TorchHolderLogicScript>().InteractionRequest(torch7);
        torchHolder8.GetComponent<TorchHolderLogicScript>().InteractionRequest(torch8);
    }
}
