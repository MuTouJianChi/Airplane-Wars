using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ESC : MonoBehaviour
{

    public static bool GameMenu = false;

    public GameObject menu;

    AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameMenu)
            {
                menuClose();
            }else
            {
                menuOpen();
            }
        }

        
    }

    public void Click()
    {
        if (GameMenu)
        {
            menuClose();
        }else
        {
            menuOpen();
        }
    }

    public void menuOpen()
    {
        AS.Play();
        menu.SetActive(true);
        GameMenu = true;
        Time.timeScale = 0;
        GameObject.Find("player").GetComponent<PolygonCollider2D>().enabled=false;//停止玩家的移动行为

    }

    public void menuClose()
    {
        AS.Play();
        menu.SetActive(false);
        GameMenu = false;
        Time.timeScale = 1;
        GameObject.Find("player").GetComponent<PolygonCollider2D>().enabled=true;//重新启动玩家的移动行为
    }

    public void Again()
    {
        AS.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene ("Game");
    }

    public void Exit()
    {
        AS.Play();
        SceneManager.LoadScene("Start");
        Time.timeScale = 1;
    }

    public void Continue()
    {
        AS.Play();
        menu.SetActive(false);
        GameMenu = false;
        Time.timeScale = 1;
        GameObject.Find("player").GetComponent<PolygonCollider2D>().enabled=true;//重新启动玩家的移动行为
    }
}
