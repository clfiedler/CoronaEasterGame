using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HighscoreMenu : MonoBehaviour
{
    [SerializeField]
    public TextField textfield;
    private string playerName;
    
    
    public void MainMenuButton()
    {
        //load main menu
        SceneManager.LoadScene(0);
    }

    public void ResetHighscore()
    {
        //delete the player prefs
        PlayerPrefs.DeleteAll();
        //load highscore
        Highscore.LoadScores();
    }

    public void QuitButton()
    {
        //quit the application
        Debug.Log("Quit");
        Application.Quit();
    }

    public void EnterButton()
    {
        playerName = textfield.text;
        Debug.Log(playerName);
    }
}
