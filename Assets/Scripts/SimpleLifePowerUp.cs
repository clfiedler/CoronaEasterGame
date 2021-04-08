using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLifePowerUp : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // PowerUp moves down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if SimpleLifePowerUp collides with the player,
        // one life is added to the player's lives
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().CatchedSimpleLifePowerUp();
            Destroy(this.gameObject);
        }

        else if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
