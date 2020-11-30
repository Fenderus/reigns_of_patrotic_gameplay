using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public int health = 10;
    public bool IsAndroid = true;
    public int coins;
    public int maxhealth = 20;

    
    public Rigidbody2D rb;
    public Joystick joystick;
    public Animator animator;
    public TextMeshProUGUI healthMeasure;
    public TextMeshProUGUI coinMeasure;
    public HealthBar healthBar;
    

    private float x;
    private float y;

    Vector2 movement;

    private void Start()
    {
        //Load @ Start
        PlayerData data = SaveSystem.Load();

        moveSpeed = data.speed;

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;


        rb = GetComponent<Rigidbody2D>();

        if(PlayerPrefs.HasKey("Speed")){
            moveSpeed = PlayerPrefs.GetFloat("Speed");
        }
        else{
            PlayerPrefs.SetFloat("Speed", moveSpeed);
        }

        if (PlayerPrefs.HasKey("CurrentCoins"))
        {
            coins = PlayerPrefs.GetInt("CurrentCoins");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentCoins", coins);
        }

        if(PlayerPrefs.HasKey("Health")){
            health = PlayerPrefs.GetInt("Health");
        }
        else{
            PlayerPrefs.SetInt("Health", health);
        }

        healthMeasure.text = "" + health;
        coinMeasure.text = "" + coins;

        healthBar.SetMaxHealth(maxhealth);
    }


    // Update is called once per frame
    void Update()
    {   
        IfAndroid(IsAndroid);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        healthMeasure.text = "" + health;
        coinMeasure.text = "" + coins;
        healthBar.SetHealth(health);

        

        if(health == 0){
            TakeDamage(0);
            Time.timeScale = 0;
        }

        if(coins == 0){
            AddMoney(0);
        }
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)new Vector2(movement.x * moveSpeed * Time.deltaTime,movement.y * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage){
        health -= damage;
        healthMeasure.text = "" + health;
        healthBar.SetHealth(health);
    }

    
    public void SavePlayer(){
        //Save by File
        SaveSystem.Save(this);

        //Save by built-in PlayerPrefs
        
        PlayerPrefs.SetInt("CurrentCoins", coins);
        PlayerPrefs.SetFloat("Speed", moveSpeed);
        PlayerPrefs.SetInt("Health", health);

        PlayerPrefs.Save();
    }

    public void LoadPlayer(){
        //Load by File
        PlayerData data = SaveSystem.Load();

        moveSpeed = data.speed;

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;

        //Load by built-in PlayerPrefs
        PlayerPrefs.GetFloat("Speed");
        PlayerPrefs.GetInt("CurrentCoins");
        PlayerPrefs.GetInt("Health");
    }

    public void IfAndroid(bool Isandroid){

        IsAndroid = Isandroid;

        if(Isandroid == true){
            movement.x = joystick.Horizontal;
            movement.y = joystick.Vertical;
        }
        if(Isandroid == false){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    public void AddMoney(int coinsToAdd)
    {
        coins += coinsToAdd;
        PlayerPrefs.SetInt("CurrentCoins", coins);
        coinMeasure.text = "" + coins;
    }

    public void AddHealth(int healthToAdd){
        health += healthToAdd;
        healthMeasure.text = "" + health;
        healthBar.SetHealth(health);
    }
}
