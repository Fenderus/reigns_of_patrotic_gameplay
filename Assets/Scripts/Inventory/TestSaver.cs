using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaver : MonoBehaviour
{

    public bool inventoryfull1;

    private int int1;

    private int i;

    public GameObject slot1;

    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Inv1")){
            int1 = PlayerPrefs.GetInt("Inv1");
        }
        else{
            PlayerPrefs.SetInt("Inv1",int1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        //Int ifs
        if(int1 == 1){
            inventoryfull1 = true;
        }else if(int1 == 0){
            inventoryfull1 = false;
        }  

        //Bool ifs
        
    }


}
