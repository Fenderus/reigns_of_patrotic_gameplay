using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInstantiate : MonoBehaviour
{

    private Shop shop;
    private PlayerMovement player;
    private Inventory inventory;
    

    public int value;

    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShopItem(){
        player.coins -= value;
        for(int i = 0; i < inventory.slots.Length; i++){
            if(inventory.isFull[i] == false){
                inventory.isFull[i] = true;
                Instantiate(item, inventory.slots[i].transform, false);
            }
        }
    }
}
