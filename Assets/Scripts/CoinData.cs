using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinData : MonoBehaviour
{
    public int value = 1;

    public PlayerMovement player;
    public AudioClip ding;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 3){
            player.AddMoney(value);
            AudioSource.PlayClipAtPoint(ding, transform.position);
            Destroy(gameObject);
        }
    }
}
