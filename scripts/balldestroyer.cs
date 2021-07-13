using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balldestroyer : MonoBehaviour
{
    public static int isball = 1;
    public GameObject player;
    // Start is called before the first frame update
 
  
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "player")
        {
            isball = 0;
            player.SetActive(false);
        }
    }
}
//col.gameObject.name != "spaceimage2" && col.gameObject.name != "spaceimage"
