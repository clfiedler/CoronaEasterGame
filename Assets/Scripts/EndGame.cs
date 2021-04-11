using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void GameOver()
    {
        //TODO Delay this
        StaticVar.scoreSave = FindObjectOfType<Score>().GetScore();
        //load the highscore
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
