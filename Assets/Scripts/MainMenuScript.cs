using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    public GameObject MainMenu;
    [SerializeField]
    public GameObject CreditsMenu;

    [SerializeField] 
    public GameObject Instructions;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
        CreditsMenu.SetActive(false);
        Instructions.SetActive(false);
    }
    
    public void MainMenuButton()
    {
        //deactivate MainMenu
        MainMenu.SetActive(true);
        //activate credits
        CreditsMenu.SetActive(false);
    }

    public void PlayNowButton()
    {
        //if we want to add options, we probs need to hand them over here
        //loads the level
        SceneManager.LoadScene(1);
    }

    public void CreditsButton()
    {
        //deactivate the main menu
        MainMenu.SetActive(false);
        //activate the credits
        CreditsMenu.SetActive(true);
    }

    public void InstructionsButton()
    {
        MainMenu.SetActive(false);
        Instructions.SetActive(true);
    }

    public void BackButton()
    {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        Instructions.SetActive(false);
        
    }

    
    

    public void QuitButton()
    {
        //quitting the game only works in built
        Debug.Log("Quit");
        //Quit the game
        Application.Quit();
    }
}

