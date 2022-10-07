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
        Destroy(gameObject);//一开始就摧毁，防止一开始就有蓝枪
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        
    }
}
