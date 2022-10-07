using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;//���ö������

    public float timer = 0;//��ʱ��;

    public GameObject GunRight;
    public GameObject GunLeft;
    public GameObject DieMenu;
    public GameObject leftPlane;
    public GameObject rightPlane;

    public int score = 0;

    AudioSource AS;
    AudioSource StopBG;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        StopBG = GameObject.Find("bg").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();//��ȡ�������
        //Invoke("CloseBlueGun",10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseTime_Award1()
    {
        //GetComponent<CloseBlueGun>().enabled=true;
        GunLeft.SendMessage("close");//������ǹ
        GunRight.SendMessage("close");
    }

    public void StopFire_Award0()
    {
        leftPlane.SendMessage("StopFire");
        rightPlane.SendMessage("StopFire");
    }

    public void Open_Award0()
    {
        leftPlane.SendMessage("OpenFire");
        rightPlane.SendMessage("OpenFire");
    }

    public void OnTriggerEnter2D(Collider2D collider){

        if (collider.tag=="Enemy")
        {
            AS.Play();
            animator.SetBool("DieTime",true);//������������
            Invoke("Die",0.7f);
            
        }

        if (collider.tag=="Award1")
        {
            GunLeft.SendMessage("open");//����ǹ
            GunRight.SendMessage("open");
            //GunRight.SetActive(true);
            //GunLeft.SetActive(true);
            Invoke("CloseTime_Award1",10);//��ǹ����ʱ������
            //Destroy(collider.gameObject);
            collider.gameObject.SendMessage("SoundPlay");
            //print("here");
        }

        if (collider.tag=="Award0")
        {
            leftPlane.SetActive(true);
            rightPlane.SetActive(true);
            Invoke("Open_Award0",0);
            Invoke("StopFire_Award0",12);
            //Destroy(collider.gameObject);
            collider.gameObject.SendMessage("SoundPlay");
        }

        
        
    }

    public void Die()
    {
        StopBG.Stop();
        Time.timeScale = 0;
        DieMenu.SetActive(true);
        GameObject.Find("Canvas").GetComponent<ESC>().enabled=false;
        Destroy(gameObject);
    }
}
