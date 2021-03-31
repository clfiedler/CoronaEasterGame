using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collect Falling Objects
public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _collectablePrefab;

    [SerializeField]
    private float _collectableDelay = 1f;

    private bool _spawningON = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(routine: CollectableSpawnSystem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CollectableSpawnSystem()
    {
        // spawn new collectibles 
        while (_spawningON)
        {
            Instantiate(_collectablePrefab, position: new Vector3(x: Random.Range(-9.5f, 9.5f), y: 10f, z: 0f), Quaternion.identity, this.transform);
            // wait for delay
            yield return new WaitForSeconds(_collectableDelay);
        }
    }        

}
