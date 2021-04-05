using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This class in CoronaEasterGame represents a bomb that destroys the player if it gets collected
/// </summary>

public class Bomb : MonoBehaviour
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
        // If bomb touches player, it destroys player
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
