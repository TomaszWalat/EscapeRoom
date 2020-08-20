using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AltarInteractionLogic : MonoBehaviour, IInteractionLogicScript
{
    [SerializeField]
    private bool clickedOnce_one;

    [SerializeField]
    private bool clickedOnce_two;

    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField]
    private Text textStorage_prePuzzleOne;

    [SerializeField]
    private Text textStorage_postPuzzleOne;

    [SerializeField]
    private InGameEventControllerScript m_eventController;

    // Start is called before the first frame update
    void Start()
    {
        clickedOnce_one = false;
        clickedOnce_two = false;
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if (interactionRequester != null)
        {
            if (interactionRequester.tag == "Player")
            {
                if (m_eventController.GetPuzzleOneStatus() && m_eventController.GetAllLoreExplored())
                {
                    if (!clickedOnce_two)
                    {
                        Debug.Log("Adding altar text post puzzle one");
                        clickedOnce_two = true;
                        textMeshProUGUI.text += textStorage_postPuzzleOne.text;
                    }
                }
                else
                {
                    if (!clickedOnce_one)
                    {
                        Debug.Log("Adding altar text pre puzzle one");
                        clickedOnce_one = true;
                        textMeshProUGUI.text += textStorage_prePuzzleOne.text;
                    }
                }
            }
        }
    }
}
