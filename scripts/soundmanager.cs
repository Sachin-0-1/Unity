using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public static AudioClip dropsound, gameoversound,click;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        dropsound = Resources.Load<AudioClip>("shot");
       gameoversound =Resources.Load<AudioClip>("gameovr");
        click= Resources.Load<AudioClip>("click");
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "shot":
                audiosrc.PlayOneShot(dropsound);
                break;
            case "gameover":
                audiosrc.PlayOneShot(gameoversound);
                break;
            case "click":
                audiosrc.PlayOneShot(click);
                break;
        }
    }
}
