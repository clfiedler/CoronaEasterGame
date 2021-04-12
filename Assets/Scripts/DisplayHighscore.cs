using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    public InputField input;
    public GameObject canvas;
    private string name;
    private string _nameInput = "";
    private string _scoreInput = "0";

    private string nameInput="nfrofgrioegi";

    private bool entered = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(nameInput);
        entered = false;
        //if the player did not break the highscore, hide textfield
        //canvas.SetActive(false);
        
        //if new score is higher than lowest saved
        //if (Highscore.CheckScore(StaticVar.scoreSave))
        if(1==1)
        {
            //pop up textfield
            canvas.SetActive(true);
            //input.ActivateInputField();
            //add the new name and score to board

            

        }

        Highscore.LoadScores();
    }

    private void Update()
    {
        if (entered = true)
        {
            //Highscore.Record(nameInput, 500); //StaticVar.scoreSave);
            //Highscore.LoadScores();
        }
        
    }

    //get the name entered from the player in the text field
    public void EnterName(string enter)
    {
        Debug.Log("in function");
        nameInput = enter;
        Debug.Log(enter);
        Debug.Log(nameInput);
        //canvas.SetActive(false);
        entered = true;
    }
    
    private void OnGUI() {
        //Creating the are that we can use (the screen)
        GUILayout.BeginArea(new Rect(Screen.width/10, Screen.height/7, Screen.width, Screen.height));
     
        // Display highscores!
        for (int i = 0; i < Highscore.EntryCount; ++i) {
            var entry = Highscore.GetEntry(i);
            GUIStyle headStyle = new GUIStyle();
            headStyle.fontSize = 15;
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
