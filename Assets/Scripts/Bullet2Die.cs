using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Die : MonoBehaviour
{
    public GameObject bullet2;
    // Start is called before the first frame update
    void Start()
    {
        //bullet2.SetActive(true);
        //bullet2.SetActive(false);
        Destroy(gameObject);//һ��ʼ�ʹݻ٣���ֹһ��ʼ������ǹ
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        
    }
}
