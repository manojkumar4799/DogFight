using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Playerlife : MonoBehaviour
{
    [SerializeField] GameObject[] playerHearts;
    


    public void PlayerHealth(int life)
    {
       

        Destroy(playerHearts[life].gameObject);
        if(life>1)
        {
            Destroy(gameObject);
        }
    
    }
}
    
