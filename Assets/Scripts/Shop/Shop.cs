using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    private PlayerMovement player;
    private Inventory inventory;

    public GameObject shopPanel;

    public int coinForPotion;
    public int coinForSpeed;

    public int addHealth;
    public int addSpeed;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.coins <= coinForPotion){
            coinForPotion = 0;

            addHealth = 0;
        }
    }

    public void ShopPotion(){
        player.DestroyMoney(coinForPotion);
        player.AddHealth(addHealth);
        if(player.coins <= coinForPotion){
            coinForPotion = 0;
            addHealth = 0;
        }
    }

    public void ShopSpeed(){
        player.DestroyMoney(coinForSpeed);
        player.AddSpeed(addSpeed);
    }

    public void ShopItem(int coinsDes){
        player.coins -= coinsDes;
    }
}
