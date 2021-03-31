using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // Obect moves down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);            

    }

    private void OnTriggerEnter(Collider other)
    {
        // if the collectable collides with the player, the player gets points
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().CatchedCollectable();
            Destroy(this.gameObject);
        }

        else if(other.CompareTag("Ground"))
        {
            other.GetComponent<Ground>().MissedCollectable();
            Destroy(this.gameObject);
        }
    
    }
}
