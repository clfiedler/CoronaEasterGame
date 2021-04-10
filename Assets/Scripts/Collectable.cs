using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents a basic collectable that gives 10 points when collected by the player
/// </summary>

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
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
        // play collectable sound
        GetComponent<AudioSource>().Play();
        
        // if the collectable collides with the player, the player gets points
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().CatchedCollectable();
            Destroy(this.gameObject);
            FindObjectOfType<Score>().AddScore(10);
        }

        else if(other.CompareTag("Ground"))
        {
            other.GetComponent<Ground>().MissedCollectable();
            Destroy(this.gameObject);
        }
    
    }
}
