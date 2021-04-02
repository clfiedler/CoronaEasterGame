using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents a fast collectable that gives 50 points when collected
/// </summary>

public class Speedy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Object moves down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if speedy collides with the player, the player gets 50 points
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().CatchedSpeedy();
            Destroy(this.gameObject);
        }

        else if (other.CompareTag("Ground"))
        {
            other.GetComponent<Ground>().MissedCollectable();
            Destroy(this.gameObject);
        }

    }
}
