using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    private Inventory inventory;

    public GameObject item;
    private Transform player;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDroppedItem(){
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 1);
        Instantiate(item, playerPos, Quaternion.identity);
    }

    public void SaveThis(){
        Instantiate(this, inventory.slots[i].transform, false);
    }

}
