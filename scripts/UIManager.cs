using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{

    ///public static UIManager instance;
    public GameObject mainMenu;
    public GameObject gamePanel;
    public GameObject initialspawn;
    public GameObject backbut;
    public GameObject cam;
    public GameObject player;
    public GameObject gameoverpanel;

    public Text scoretext;
    public Text gameoverscoretext;

    private Vector3 pos = new Vector3(0, 0, 0);
    // Start is called before the first frame update

    //public GameObject soundon;
  //  public GameObject soundoff;


    public Sprite onsound;
    public Sprite offsound;
    public Button but;
    //private int score=0;
    int x;
    public void onstart()
    {
        soundmanager.PlaySound("click");
        mainMenu.SetActive(false);
        player.SetActive(true);

        // if(balldestroyer.isball == 0)
        //Instantiate(player,pos, Quaternion.identity);

        initialspawn.SetActive(true);
        gamePanel.SetActive(true);
        backbut.SetActive(false);
        gameoverpanel.SetActive(false);

        player.transform.position = new Vector3(0, 0, -1);
        cam.transform.position = new Vector3(0, 0, -1);

        balldestroyer.isball = 1;
        // score = 0;
        Time.timeScale = 1;

        //  dodelay();
    }
    public void onexit()
    {
        soundmanager.PlaySound("click");
        Application.Quit();
    }
    public void onpause()
    {
        soundmanager.PlaySound("click");
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            backbut.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            backbut.SetActive(false);
        }
    }
    public void onback()
    {
        soundmanager.PlaySound("click");
        mainMenu.SetActive(true);
        gamePanel.SetActive(false);
        initialspawn.SetActive(false);
        gameoverpanel.SetActive(false);

    }
    public void gameover()
    {
        soundmanager.PlaySound("gameover");
        gameoverpanel.SetActive(true);
        gamePanel.SetActive(false);
        initialspawn.SetActive(false);
        gameoverscoretext.text = "Score: "  + x;
    }
    void Update()
    {
        x = (int)cam.transform.position.y;
        scoretext.text = "Score: " + x;
        if (balldestroyer.isball == 0)
        {
            gameover();
            balldestroyer.isball = 1;
        }
    }
  //  public void dodelay()
  //  {
  //      StartCoroutine(delayact(5));
  //  }
   // IEnumerator delayact(float delaytime)
    //{
    //    yield return new WaitForSeconds(delaytime);
    //    Debug.Log("delayed");
   // }
    public void makesoundonoff()
    {
        soundmanager.PlaySound("click");
        if (but.image.sprite == onsound)
        {
            but.image.sprite = offsound;
            AudioListener.volume = 0;
        }
        else
        {
            but.image.sprite = onsound;
            AudioListener.volume = 1;
        }
        
    }
   
}
