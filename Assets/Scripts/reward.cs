using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reward : MonoBehaviour
{
    public int type = 0;

    public float speed = 1.25f;

    AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if (transform.position.y<-7)
        {
            Destroy(gameObject);
        }
    }

    public void SoundPlay()
    {
        AS.Play();
        Invoke("Die",0.3f);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
