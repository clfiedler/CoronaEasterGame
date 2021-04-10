using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the spawning of different objects in the CoronaEasterGame
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]

    [SerializeField]
    private GameObject _collectablePrefab;

    [SerializeField]
    private GameObject _bombPrefab;

    [SerializeField] 
    private GameObject _minibombPrefab;
    
    [SerializeField]
    private GameObject _speedyPrefab;

    [SerializeField] 
    private GameObject _simpleLifePowerUpPrefab;

    [SerializeField] 
    private GameObject _fillUpLivesPowerUpPrefab;

    [SerializeField] 
    private GameObject _timePowerUpPrefab;

    [SerializeField]
    private GameObject _confusionPrefab;

    [Header("Delays")]

    [SerializeField]
    private float _collectableDelay = 1f;

    [SerializeField]
    private float _minibombDelay = 4f;
    
    [SerializeField]
    private float _bombDelay = 5f;
    
    [SerializeField]
    private float _speedyDelay = 3f;

    [SerializeField] 
    private float _simpleLifePowerUpDelay = 8f;

    [SerializeField] 
    private float _fillUpLivesPowerUpDelay = 10f;

    [SerializeField] 
    private float _timePowerUpDelay = 8f;

    [SerializeField]
    private float _confusionDelay = 4f;

    private bool _spawningON = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(routine: CollectableSpawnSystem());
        StartCoroutine(routine: BombSpawnSystem());
        StartCoroutine(routine: SpeedySpawnSytem());
        StartCoroutine(MiniBombSpawnSystem());
        StartCoroutine(SimpleLifePowerUpSpawnSystem());
        StartCoroutine(FillLivesUpPowerUpSpawnSystem());
        StartCoroutine(TimePowerUpSpawnSystem());
        StartCoroutine(routine: ConfusionSpawnSystem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CollectableSpawnSystem()
    {
        // spawn new collectables 
        while (_spawningON)
        {
            Instantiate(_collectablePrefab, position: new Vector3(x: Random.Range(-9.5f, 9.5f), y: 10f, z: 0f), Quaternion.identity, this.transform);
            // wait for delay
            yield return new WaitForSeconds(_collectableDelay);
        }
    }

    IEnumerator BombSpawnSystem()
    {
        // spawn new collectibles 
        while (_spawningON)
        {
            Instantiate(_bombPrefab, position: new Vector3(x: Random.Range(-9.5f, 9.5f), y: 10f, z: 0f), Quaternion.identity, this.transform);
            // wait for delay
            yield return new WaitForSeconds(_bombDelay);
        }
    }

    IEnumerator MiniBombSpawnSystem()
    {
        // spawn new minibombs
        while (_spawningON)
        {
            Instantiate(_minibombPrefab, new Vector3(Random.Range(-9.5f, 9.5f), 10f, 0f), Quaternion.identity,
                this.transform);
            // wait for delay
            yield return new WaitForSeconds(_minibombDelay);
        }
    }

    IEnumerator SpeedySpawnSytem()
    {
        // spawn new speedy
        while(_spawningON)
        {
            Instantiate(_speedyPrefab, position: new Vector3(x: Random.Range(-9.5f, 9.5f), y: 10f, z: 0f), Quaternion.identity, this.transform);
            // wait for delay
            yield return new WaitForSeconds(_speedyDelay);
        }
    }

    IEnumerator SimpleLifePowerUpSpawnSystem()
    {
        while (_spawningON)
        {
            // wait for delay
            yield return new WaitForSeconds(_simpleLifePowerUpDelay);
        
            // spawn new SimpleLifePowerUps
            Instantiate(_simpleLifePowerUpPrefab, new Vector3(x: Random.Range(-9.5f, 9.5f), y: 10f, z: 0f),
                Quaternion.identity, this.transform); 
        }
    }

    IEnumerator FillLivesUpPowerUpSpawnSystem()
    {
        while (_spawningON)
        {
            // wait for delay
            yield return new WaitForSeconds(_fillUpLivesPowerUpDelay);
            
            // spawn new FillUpLivesPowerUps
            Instantiate(_fillUpLivesPowerUpPrefab, new Vector3(x: Random.Range(-9.5f, 9.5f), y: 10f, z: 0f),
                Quaternion.identity, this.transform);
        }
    }

    IEnumerator TimePowerUpSpawnSystem()
    {
        while (_spawningON)
        {
            // wait for delay
            yield return new WaitForSeconds(_timePowerUpDelay);
        
            //spawn new TimePowerUps
            Instantiate(_timePowerUpPrefab, new Vector3(x: Random.Range(-9.5f, 9.5f), y: 10f, z: 0f),
                Quaternion.identity, this.transform);
        }
    }

    IEnumerator ConfusionSpawnSystem()
    {
        // spawn new confusion 
        while (_spawningON)
        {
            Instantiate(_confusionPrefab, position: new Vector3(x: Random.Range(-9.5f, 9.5f), y: 10f, z: 0f), Quaternion.identity, this.transform);
            // wait for delay
            yield return new WaitForSeconds(_confusionDelay);
        }
    }

    // public class to be accessed from player that sets spawning on or off
    public void onPlayerDeath()
    {
        _spawningON = false;
    }

}
