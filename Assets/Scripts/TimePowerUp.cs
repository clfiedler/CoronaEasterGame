using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerUp : MonoBehaviour
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
        // PowerUp moves down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if TimePowerUp collides with the player,
        // 10 seconds are added to the countdown
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().CatchedTimePowerUp();
            Destroy(this.gameObject);
        }

        else if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
