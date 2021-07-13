using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform plyer;

    public Transform bg1;
    public Transform bg2;

    public Transform boxobj;
    public Transform ball_det;
    public GameObject rktsq;
    public GameObject rktsq1;
    public GameObject rktsq2;

    public float tmp = 0.00f;
    private float size;
    public static Vector3 targetPos;
    private Vector3 camera_targetpos = new Vector3();
    private Vector3 bg1_targetpos = new Vector3();
    private Vector3 bg2_targetpos = new Vector3();

    Camera cam;

    int checkcond = 0;

    int forspawnpos=0;

    private Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        size = bg1.GetComponent<BoxCollider2D>().size.y;
        cam = GetComponent<Camera>();
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.movup&& balldestroyer.isball == 1)
        {
            float y = Screen.height / 2;
            if(cam.WorldToScreenPoint(plyer.position).y>=y)
            {
                targetPos = SetPos(camera_targetpos, 0, plyer.position.y, -10.0f);
                transform.position = Vector3.Lerp(transform.position, targetPos, tmp);
            }
        }

        //cam
        //score
        // 
        //
        //bg;
        if (transform.position.y > bg2.position.y && forspawnpos == 0)
        {
            spawnobj(bg1.position.x - 3.5f, bg1.position.y + 2*size, bg2.position.x + 3.5f, bg2.position.y + 3 * size);
            forspawnpos = 1;
            Vector3 spawnPositionrkt = new Vector3(Random.Range(bg1.position.x - 4f, bg2.position.x + 4f), Random.Range(bg1.position.y +  size, bg2.position.y + 2 * size), -1);
            if (checkcond == 0)
            {
                rktsq.transform.position = spawnPositionrkt;
                checkcond = 1;
            }
            else if(checkcond==1)
            {
                rktsq1.transform.position = spawnPositionrkt;
                checkcond = 0;
            }
        }
        if (transform.position.y>= bg2.position.y)
        {
            bg1.position = SetPos(bg1_targetpos,bg1.position.x, bg2.position.y + size,bg1.position.z);
            Switchbg();
            forspawnpos = 0;
        }
        if (transform.position.y < bg1.position.y)
        {
            bg2.position = SetPos(bg2_targetpos,bg2.position.x, bg1.position.y - size, bg2.position.z);
            Switchbg();
        }
        //bg;
    }
    private void Switchbg()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }

    private Vector3 SetPos(Vector3 pos,float x,float y,float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        return pos;
    }
  
    private void spawnobj(float x1,float y1,float x2,float y2)
    {
        int i;

        // float y;
       
        for (i=1;i<=3;i++)
        {
          float x = Random.Range(x1, x2);
         //  y = Random.Range(y1, y1+p);

            Vector3 spawnPositiondet=new Vector3(Random.Range(x1, x2), Random.Range(y1,y2 ), -1);
    
            if(Random.Range(0,2)==0)
                Instantiate(ball_det, spawnPositiondet, Quaternion.identity);

        
           Vector3 spawnPosition = new Vector3( x, y1+size/3*i);
            Instantiate(boxobj, spawnPosition, Quaternion.identity);
          
       
        }
    }
}
