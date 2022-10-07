using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject reward0;
    public GameObject reward1;

    public float enemy1speed = 1f;
    public float enemy2speed = 3f;
    public float enemy3speed = 6f;

    public float reward0speed = 10f;
    public float reward1speed = 20f;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createenemy1",1,enemy1speed);
        InvokeRepeating("createenemy2",10,enemy2speed);
        InvokeRepeating("createenemy3",20,enemy3speed);
        //InvokeRepeating("createreward0",10,reward0speed);
        Invoke("createreward1",10);
        Invoke("DifficultTime",60);
        Invoke("MoreDifficultTime",120);
        Invoke("MostDifficultTime",180);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void createenemy1()
    {
        float x =Random.Range(-1.5f,1.5f);//����Random�������࣬��-1.5��1.5֮���������
        GameObject.Instantiate(enemy1,new Vector3(x,transform.position.y,0),Quaternion.identity);//Quaternion.identityû����ת�ı���
    }

    public void createenemy2()
    {
        float x =Random.Range(-1.4f,1.4f);//����Random�������࣬��-1.5��1.5֮���������
        GameObject.Instantiate(enemy2,new Vector3(x,transform.position.y,0),Quaternion.identity);//Quaternion.identityû����ת�ı���
    }

    public void createenemy3()
    {
        float x =Random.Range(-0.9f,0.9f);//����Random�������࣬��-1.5��1.5֮���������
        GameObject.Instantiate(enemy3,new Vector3(x,transform.position.y,0),Quaternion.identity);//Quaternion.identityû����ת�ı���
    }

    public void createreward0()
    {
        Invoke("createreward1",20);
        float x =Random.Range(-1.4f,1.4f);//����Random�������࣬��-1.5��1.5֮���������
        GameObject.Instantiate(reward0,new Vector3(x,transform.position.y,0),Quaternion.identity);//Quaternion.identityû����ת�ı���
    }

    public void createreward1()
    {
        Invoke("createreward0",20);
        float x =Random.Range(-1.4f,1.4f);//����Random�������࣬��-1.5��1.5֮���������
        GameObject.Instantiate(reward1,new Vector3(x,transform.position.y,0),Quaternion.identity);//Quaternion.identityû����ת�ı���
    }

    public void DifficultTime()
    {
        CancelInvoke("createenemy2");
        CancelInvoke("createenemy3");
        InvokeRepeating("createenemy2",0,5);
        InvokeRepeating("createenemy3",0,10);
    }

    public void MoreDifficultTime()
    {
        CancelInvoke("createenemy2");
        CancelInvoke("createenemy3");
        InvokeRepeating("createenemy2",0,2);
        InvokeRepeating("createenemy3",0,5);
    }

    public void MostDifficultTime()
    {
        CancelInvoke("createenemy2");
        CancelInvoke("createenemy3");
        InvokeRepeating("createenemy2",0,1);
        InvokeRepeating("createenemy3",0,3);
    }
}
