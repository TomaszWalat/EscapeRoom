using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LogEventsScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField]
    private Text textStorage_Beginning;

    [SerializeField]
    private Text textStorage_PuzzleOneEnd;

    [SerializeField]
    private Text textStorage_PuzzleTwoEnd;

    [SerializeField]
    private Text textStorage_Ending;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEvent_Beginning()
    {
        Debug.Log("Beginning");
        textMeshProUGUI.text += textStorage_Beginning.text;
    }

    public void TriggerEvent_PuzzleOneFinished()
    {
        Debug.Log("Puzzle One End");
        textMeshProUGUI.text += textStorage_PuzzleOneEnd.text;
    }

    public void TriggerEvent_PuzzleTwoFinished()
    {
        Debug.Log("Puzzle Two End");
        textMeshProUGUI.text += textStorage_PuzzleTwoEnd.text;
    }

    public void TriggerEvent_Ending()
    {
        Debug.Log("Ending");
        textMeshProUGUI.text += textStorage_Ending.text;
    }
}
