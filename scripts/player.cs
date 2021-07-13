using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float ms =0;
    public Rigidbody2D plyer;
 
    public float slideforce = 0.0f;

    private Vector2 targetPos;
    public Collider2D goingthrough;
    public static bool movup = false;

    //public GameObject abovetail;
    //public GameObject belowtail;

    float dirx;
    void start()
    {
        ///abovetail.SetActive(true);
        //belowtail.SetActive(false);
        goingthrough = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void Update()
    {
        dirx = Input.acceleration.x * 10.0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        /// if (Input.GetKey(KeyCode.UpArrow))
        ///  transform.Translate(Vector3.up * ms * Time.deltaTime);
        ///if (Input.GetKey(KeyCode.DownArrow))
        ///  transform.Translate(Vector3.down * ms * Time.deltaTime);
        ///boundary
        ///

        targetPos =new Vector2(Mathf.Clamp(transform.position.x + slideforce * Time.deltaTime,-4f, 4f), transform.position.y);
        transform.position = targetPos;

        plyer.velocity = new Vector2(dirx, plyer.velocity.y);

        if (plyer.velocity.y < 0.01f)
            movup = false;
        //move side

        //if (Input.GetKey(KeyCode.LeftArrow))
        //   transform.position = new Vector2(transform.position.x - ms, transform.position.y);
        // if (Input.GetKey(KeyCode.RightArrow))
        //  transform.position = new Vector2(transform.position.x + ms, transform.position.y);


        if (movup)
        {
            //abovetail.SetActive(false);
            //belowtail.SetActive(true);
            goingthrough.enabled = false;
        }
        else
        {
            //abovetail.SetActive(true);
            //belowtail.SetActive(false);
            goingthrough.enabled = true;
        }
    }
}
