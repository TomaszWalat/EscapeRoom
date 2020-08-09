using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class AbstractPuzzleTemplate : MonoBehaviour
{
    public List<TemplatePuzzlePiece> templateList { get; set; }
    public List<IPuzzlePieceScript> puzzleTemplateList { get; set; }

    protected void FindPuzzlePieces()
    {
        //FieldInfo[] myFields = gameObject.GetComponent<AbstractPuzzleTemplate>().GetType().GetFields();// BindingFlags.Instance);

        templateList = new List<TemplatePuzzlePiece>(GetComponentsInChildren<TemplatePuzzlePiece>());
        //puzzleTemplateList = new List<IPuzzlePieceScript>(this.GetType().GetFields());


        for (int i = 0; i < templateList.Count; i++)
        {
            //Debug.Log("xxxxxxxxx");
            if(templateList[i].puzzlePiece.TryGetComponent(out IPuzzlePieceScript puzzlePieceScript))
            {
                //Debug.Log("yyyyyyyyyy");
                puzzleTemplateList.Add(puzzlePieceScript);
            }
        }
        //PrintPieceList();

        //for (int i = 0; i < myFields.Length; i++)
        //{
        //    Debug.Log("field " + i + ": " + myFields[i].ToString());
        //    if (myFields[i].FieldType == typeof(GameObject))
        //    {
        //        Debug.Log(myFields[i].GetValue(this).ToString() + " is a game object");
        //        //string temp = myFields[i].GetValue(this) as IPuzzlePieceScript;
        //        ////puzzleTemplateList.Add(myFields[i].GetValue());
        //        ////if (temp.TryGetComponent(out IPuzzlePieceScript puzzlePieceScript))
        //        ////{
        //        //    Debug.Log("script: " + temp.ToString());
        //        ////Debug.Log("     it's object: " + )
        //        ////puzzleTemplateList.Add(puzzlePieceScript);
        //        ////}

        //        //puzzleTemplateList.Add(GetType().GetField(myFields[i].Name));
        //    }
        //}

        //PrintPieceList();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrintPieceList()
    {
        for (int i = 0; i < puzzleTemplateList.Count; i++)
        {
            Debug.Log("piece " + i + ": " + puzzleTemplateList[i].ToString());
        }
    }
}
