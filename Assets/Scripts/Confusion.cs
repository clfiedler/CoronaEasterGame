using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confusion : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    
    public AudioClip ConfusionSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // play Confusion sound
            SoundManager.Instance.Play(ConfusionSound);
            other.GetComponent<Player>().MakeConfused();
            Destroy(this.gameObject);
        }
    }
}
