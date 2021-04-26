using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHighScore : MonoBehaviour
{
    private DatabaseAccess databaseAccess;

    private TextMeshPro highScoreOutPut;

    void Start()
    {
        databaseAccess = GameObject.FindGameObjectWithTag("DatabaseAccess").GetComponent<DatabaseAccess>();
        highScoreOutPut = GetComponentInChildren<TextMeshPro>();
        InvokeRepeating("DisplayHighScoreInTextMesh", 2f, 10f);
    }


    private async void DisplayHighScoreInTextMesh()
    {
       var task = databaseAccess.GetScoresFromDataBase();
        var result = await task;
        var output = "";
        foreach (var score in result)
        {
            output += score.UserName + ": " + score.Score + "\n";
        }
        highScoreOutPut.text = output;
    }
}
