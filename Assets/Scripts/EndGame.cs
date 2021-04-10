using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void GameOver()
    {
        //TODO Delay this
        
        //load the end menu
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
