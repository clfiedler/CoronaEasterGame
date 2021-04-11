using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minibomb : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    
    public AudioClip MinibombSound;

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
        // If bomb touches player, it damages player
        if (other.CompareTag("Player"))
        {
            // play minibomb sound
            SoundManager.Instance.Play(MinibombSound);
            // damage player (make the player loose a life)
            other.GetComponent<Player>().Damage();
            // then destroy the minibomb
            Destroy(this.gameObject);
            
        }

        else if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
