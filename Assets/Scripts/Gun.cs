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
        GameObject.Instantiate(gun,transform.position,Quaternion.identity);//Quaternion.identityû����ת�ı���
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
        bullet2.GetComponent<Bullet2Die>().enabled=true;//����bullet2�ϵĽű���������ǹ��ʧ���ܽ���ӵ��������ڵ�����
    }

    public void open()
    {
        bullet2.GetComponent<Bullet2Die>().enabled=false;//�ر�bullet2�Ľű����Է�����ǹ�ڼ��ӵ��ܹ�����
        bullet2.SetActive(true);
    }
}
