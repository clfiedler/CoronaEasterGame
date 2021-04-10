using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

// Player in CoronaEasterGame
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 13f;

    [SerializeField]
    private int _points = 0;

    [SerializeField] 
    private int _playerLives = 5;
    
    // reference to spawnmanager
    [SerializeField] 
    private SpawnManager _spawnManager;

    // variables for timer and confusion
    [SerializeField]
    private float waitTime = 5.0f;

    private float timer = 0.0f;

    private bool _confused = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        PlayerBoundaries();

        // timer for confusion
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            _confused = false;
            timer = timer - waitTime;
        }
    }


    void PlayerMovement()
    {
        // move the player horizontal
        float horizontalInput = Input.GetAxis("Horizontal");

        // apply player movement

        // normal
        if (_confused == false)
        {
            Vector3 playerTranslate = new Vector3(
            x: 1f * horizontalInput * _speed * Time.deltaTime,
            y: 0f, z: 0f);
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        }

        else if (_confused == true)
        {
            Vector3 playerTranslate = new Vector3(
            x: 1f * horizontalInput * _speed * Time.deltaTime,
            y: 0f, z: 0f);
            transform.Translate(Vector3.left * Time.deltaTime * _speed * horizontalInput);
        }
        
    }

    void PlayerBoundaries()
    {
        // if player escapes to the left or right, it will appear on the other side

        // right side
        if (transform.position.x > 10.2f)
        {
            //move player to the left side
            transform.position = new Vector3(x: -10.2f, transform.position.y, transform.position.z);
        }

        // left side
        if (transform.position.x < -10.2f)
        {
            //move player to the right side
            transform.position = new Vector3(x: 10.2f, transform.position.y, transform.position.z);
        }

        // player should not move downwards
        //if (transform.position.y < 2.5f)
        //{
        //    transform.position = new Vector3(transform.position.x, y: 2.5f, z: 0f);
        //}

    }

   
    public void CatchedCollectable()
    {
        _points += 10;
    }

    public void CatchedSpeedy()
    {
        _points += 50;
    }

    public void CatchedSimpleLifePowerUp()
    {
        _playerLives += 1;
    }

    public void CatchedFillUpLivesPowerUp()
    {
        if (_playerLives < 5)
        {
            _playerLives = 5;
        }
    }

    // CatchedTimePowerUp function adds 10 seconds to the remaining time
    public void CatchedTimePowerUp()
    {
        FindObjectOfType<Timer>().AddTime(10);
    }

    // Catched confusion changes movements for a time
    public void ChangeConfused()
    {
        _confused = true;
    }
    
    // damage function
    // is activated when a minibomb collides with the player
    // one life is lost per activation of the function
    // if no life is left, the player dies
    public void Damage()
    {
        // subtract one life
        if (_playerLives > 0)
        {
            _playerLives -= 1; 
        }

        // if no lives are left, destroy the player and stop spawning
        if (_playerLives == 0)
        {
            if (_spawnManager != null)
            {
                _spawnManager.onPlayerDeath(); 
            }
            
            // destroy the player
            Destroy(this.gameObject);
            
            // destroy the spawnmanager to destroy all instances of collectables and (mini)bombs
            Destroy(_spawnManager.gameObject);
            //call the function "GameOver()" in the object "GameManager"
            GameObject.Find("GameManager").GetComponent<EndGame>().GameOver();
            
        }
        
        
        
    }

    // When the player gets hit by a bomb, it is instantly destroyed and the spwanmanager too
    public void FatalDamage()
    {
        _playerLives = 0;
        if (_spawnManager != null)
        {
            _spawnManager.onPlayerDeath();
        }

        // destroy the player
        Destroy(this.gameObject);

        // destroy the spawnmanager to destroy all instances of collectables and (mini)bombs
        Destroy(_spawnManager.gameObject);
        //call the function "GameOver()" in the object "GameManager"
        GameObject.Find("GameManager").GetComponent<EndGame>().GameOver();
        
    }
}