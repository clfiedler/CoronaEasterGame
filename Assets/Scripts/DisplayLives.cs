using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLives : MonoBehaviour
{
    public int livesLeft;

    // Start is called before the first frame update
    void Start()
    {
        livesLeft = GetComponent<Player>()._playerLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int lost)
    {
        this.livesLeft -= lost;
    }

    public void SetLives(int lives)
    {
        this.livesLeft = lives;
    }
}
