using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlaneGun : MonoBehaviour
{
    public float speed = 2;
    public float shoot = 0.5f;

    public GameObject bullet1;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire()
    {
        GameObject.Instantiate(bullet1,transform.position,Quaternion.identity);//Quaternion.identity没有旋转的变量
    }

    public void OpenFire()
    {
        InvokeRepeating("fire",1,shoot);
    }

    public void StopFire()
    {
        CancelInvoke("fire");
        animator.SetBool("AwardOver",true);
        Invoke("False",0.4f);
    }

    public void False()
    {
        gameObject.SetActive(false);
    }
}
