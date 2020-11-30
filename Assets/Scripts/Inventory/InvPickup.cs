using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InvPickup : MonoBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;
    public AudioClip ding;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

     private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    AudioSource.PlayClipAtPoint(ding, transform.position);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }   
    
}
