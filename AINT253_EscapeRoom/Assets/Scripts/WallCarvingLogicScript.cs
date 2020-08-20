using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WallCarvingLogicScript : MonoBehaviour, IInteractionLogicScript
{
    [SerializeField]
    private bool hasBeenTranslated;

    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField]
    private Text textStorage;

    // Start is called before the first frame update
    void Start()
    {
        hasBeenTranslated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionRequest(GameObject interactionRequester)
    {
        if (interactionRequester != null)
        {
            if(interactionRequester.tag == "Player")
            {
                if(!hasBeenTranslated)
                {
                    Debug.Log("Translating");
                    hasBeenTranslated = true;
                    textMeshProUGUI.text += textStorage.text;
                }
            }
        }
    }

    public bool GetHasBeenTranslated()
    {
        return hasBeenTranslated;
    }
}
