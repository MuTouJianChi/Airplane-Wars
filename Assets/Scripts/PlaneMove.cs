using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{

    private Vector3 depth;

    private Vector3 offset;//位移差

    private void OnMouseDown()
    {
        depth = Camera.main.WorldToScreenPoint(transform.position);
        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition = new Vector3(mousePosition.x,mousePosition.y,depth.z);
        offset = transform.position -Camera.main.ScreenToWorldPoint(Input.mousePosition);//计算位移差
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x,mousePosition.y,depth.z);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition)+offset;//进行移动，记得添加Collider组件
    }

    void Update()
    {
        checkPosition();
    }

    public void checkPosition()//位置检查，防止出边界
    {
        //check y -3.6 3
        //check x -1.8 1.8
        Vector3 checkpos = transform.position;
        float x = checkpos.x;
        float y = checkpos.y;

        if (x<-1.8f)
        {
            x=-1.8f;
        }

        if (x>1.8f)
        {
            x=1.8f;
        }

        if (y<-3.6f)
        {
            y=-3.6f;
        }

        if (y>3f)
        {
            y=3f;
        }

        transform.position = new Vector3(x,y,0);
    }
}
