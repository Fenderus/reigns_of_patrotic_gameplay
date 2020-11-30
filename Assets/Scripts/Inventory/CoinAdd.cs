using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
    private PlayerMovement player; 
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void AddCoins(){
        player.AddMoney(value);
        Destroy(gameObject);
    }
}
