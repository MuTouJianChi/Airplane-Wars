using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float shoot = 0.5f;

    public GameObject gun;
    public GameObject bullet2;

    public void fire()
    {
        GameObject.Instantiate(gun,transform.position,Quaternion.identity);//Quaternion.identity没有旋转的变量
    }

    public void Openfire()
    {
        InvokeRepeating("fire",1,shoot);
    }

    // Start is called before the first frame update
    void Start()
    {
        bullet2.GetComponent<Bullet2Die>().enabled=true;
        gun.SetActive(true);
        //bullet2.SetActive(false);
        Openfire();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void close()
    {
        bullet2.GetComponent<Bullet2Die>().enabled=true;//开启bullet2上的脚本，来让蓝枪消失后能解决子弹继续存在的问题
    }

    public void open()
    {
        bullet2.GetComponent<Bullet2Die>().enabled=false;//关闭bullet2的脚本，以防在蓝枪期间子弹能够存在
        bullet2.SetActive(true);
    }
}
