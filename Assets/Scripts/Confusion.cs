using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confusion : MonoBehaviour
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
        // if Confusion collides with player, the horizontal movements get swapped for some seconds
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().ChangeConfused();
            Destroy(this.gameObject);
        }
    }
}
