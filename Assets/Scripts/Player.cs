using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collect Falling Objects
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;

    [SerializeField]
    private int _points = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        PlayerBoundaries();
    }


    void PlayerMovement()
    {
        // move the player horizontal
        float horizontalInput = Input.GetAxis("Horizontal");

        // apply player movement
        Vector3 playerTranslate = new Vector3(
            x: 1f * horizontalInput * _speed * Time.deltaTime,
            y: 0f, z: 0f);
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
    }

    void PlayerBoundaries()
    {
        // if player escapes to the left or right, it will appear on the other side

        // right side
        if (transform.position.x > 10.2f)
        {
            //move player to the left side
            transform.position = new Vector3(x: -10.2f, transform.position.y, transform.position.z);
        }

        // left side
        if (transform.position.x < -10.2f)
        {
            //move player to the right side
            transform.position = new Vector3(x: 10.2f, transform.position.y, transform.position.z);
        }

        // player should not move downwards
        //if (transform.position.y < 2.5f)
        //{
        //    transform.position = new Vector3(transform.position.x, y: 2.5f, z: 0f);
        //}

    }

   
    public void CatchedCollectable()
    {
        _points += 10;
    }

    public void CatchedSpeedy()
    {
        _points += 50;
    }
}