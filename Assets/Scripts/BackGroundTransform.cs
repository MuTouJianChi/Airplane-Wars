using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTransform : MonoBehaviour
{
    public float moveSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        Vector3 position = transform.position;
        if (position.y<=-7)
        {
            transform.position += new Vector3(0,14,0);
        }
    }
}
