using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdet : MonoBehaviour
{
    public static float thrust = 2.2f;
    public Rigidbody2D plyer;

    void start()
    {
        //anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "spaceimage" && col.gameObject.name != "spaceimage2" && !player.movup)
        {
            soundmanager.PlaySound("shot");
            if(col.gameObject.name=="rktsq"|| col.gameObject.name == "rktsq2"|| col.gameObject.name == "rktsq3"|| col.gameObject.name == "rktsq4")
                plyer.AddForce(transform.up * thrust*2.2f, ForceMode2D.Impulse);
            else
                plyer.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            player.movup = true;
        }

    }
}
