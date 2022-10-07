using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*bulletSpeed*Time.deltaTime);
        if (transform.position.y>=3.6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)//碰撞检查
    {
        if (other.tag=="Enemy")
        {
            if(!other.GetComponent<Enemy>().isDeath)
            {
                other.gameObject.SendMessage("BeHit");//让enemy调用BeHit的方法
                Destroy(gameObject);
            }
        }
    }
}
