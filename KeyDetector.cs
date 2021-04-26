using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro playerTextOutput;
    private DatabaseAccess databaseAccess;
    
    // Start is called before the first frame update
    void Start()
    {
        databaseAccess = GameObject.FindGameObjectWithTag("DatabaseAccess").GetComponent<DatabaseAccess>();
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponentInChildren<TextMeshPro>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var key = other.GetComponentInChildren<TextMeshPro>();
        if(key != null)
        {
            var keyFeedBack = other.gameObject.GetComponent<KeyFeedback>();
           
        if (keyFeedBack.keyCanBeHitAgain)
        {
                if (key.text == "SPACE")
                {
                    playerTextOutput.text += " ";
                }
                else if (key.text == "<-")
                {
                    playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
                }
                else if (key.text == "SAVE")
                {
                    var randomScore = UnityEngine.Random.Range(0, 100);
                    databaseAccess.SaveScoreToDataBase(playerTextOutput.text, randomScore);
                    playerTextOutput.text = "";
                }
                else
                {
                    playerTextOutput.text += key.text;
                }
                keyFeedBack.keyHit = true;
            }
        }
    }
}
