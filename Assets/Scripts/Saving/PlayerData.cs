using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    

    
    public float speed;

    public float[] position;

    public PlayerData(PlayerMovement player){
        
        speed = player.moveSpeed;

        position = new float[2];
        position[0] = player.transform.position.x;
        position[1]= player.transform.position.y;
    }

}
