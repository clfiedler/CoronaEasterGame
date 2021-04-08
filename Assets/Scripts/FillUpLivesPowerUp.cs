using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillUpLivesPowerUp : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 6f;
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
        //if LivesFillUpPowerUp collides with the player,
        // and the number of lives is smaller than 5,
        // set the number of lives to 5 again
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().CatchedFillUpLivesPowerUp();
            Destroy(this.gameObject);
        }

        else if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
