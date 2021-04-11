using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    public InputField input;
    private string name;
    private string _nameInput = "";
    private string _scoreInput = "0";
    // Start is called before the first frame update
    void Start()
    {
        


        //if new score is higher than lowest saved
        if (Highscore.CheckScore(StaticVar.scoreSave))
        {
            //TODO pop up inputfield 
            //add the new name and score to board
            Highscore.Record(EnterName(), StaticVar.scoreSave);
        }

        Highscore.LoadScores();
    }


    //get the name entered from the player in the text field
    public string EnterName()
    {
        //TODO save input
        return "Franz";
    }
    
    private void OnGUI() {
        //Creating the are that we can use (the screen)
        GUILayout.BeginArea(new Rect(Screen.width/4, Screen.height/8, Screen.width, Screen.height));
     
        // Display highscores!
        for (int i = 0; i < Highscore.EntryCount; ++i) {
            var entry = Highscore.GetEntry(i);
            GUIStyle headStyle = new GUIStyle();
            headStyle.fontSize = 30;
            //create labels with entries
            GUILayout.Label(  entry.name + ", Score: " + entry.score, headStyle);
        }
     
        // Interface for reporting test scores.
        GUILayout.Space(10);
     
        //_nameInput = GUILayout.TextField(_nameInput);
        //_scoreInput = GUILayout.TextField(_scoreInput);
     
        /*if (GUILayout.Button("Record")) {
            //int score;
            int.TryParse(_scoreInput, out score);
     
            Highscore.Record(_nameInput, score);
     
            // Reset for next input.
            _nameInput = ""; 
            _scoreInput = "0";
        }*/
     
        GUILayout.EndArea();
    }

    

}
