using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType{//Type类型组
    enemy1,
    enemy2,
    enemy3
}

public class Enemy : MonoBehaviour
{
    public int HP = 1;

    public float speed = 1;

    public int Score = 10;

    public EnemyType type;//在Unity中实现Type组的使用

    public bool isDeath = false;

    public Sprite[] DieSprite;
    
    public Sprite[] HitSprites;

    private float timer = 0;

    public int DieAnimationFrame=10;//每秒几帧/或者说死亡动画的速度

    private SpriteRenderer render;

    public float HitTime = 0.2f;//击中时间

    private float resetHitTime ;//重置击中时间 

    AudioSource AS;

   // public bool Hitone = true;//击中变形后动画只执行一次的方式

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();//GetComponent访问游戏对象的组件的方法
        resetHitTime=HitTime;
        HitTime = 0;
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if (transform.position.y<=-7)
        {
            Destroy(gameObject);
        }

        if (isDeath)
        {
                
                timer += Time.deltaTime;
                int nowframe = (int)(timer/(1f/DieAnimationFrame));////(1/T)计算每帧几秒  timer/(1/T)计算当前第几帧
                if (nowframe>=DieSprite.Length)//大于数组的值就销毁，因为爆炸动画只执行一次
                {
                    Destroy(gameObject);
                }
                render.sprite = DieSprite[nowframe];
        }else//击中动画
        {
            if (HitTime>=0)
            {
                HitTime -= Time.deltaTime;

                int nowhitframe = (int)((resetHitTime-HitTime)/(1f/DieAnimationFrame));//resetHitTime-HitTime求走的时间

                nowhitframe%=2;//判断播放哪一帧

                render.sprite = HitSprites[nowhitframe];
            }
        }
    }

    public void BeHit()
    {
        HP -= 1;//因为都会受到伤害，放这统一扣血，下面也一样
        if (HP<=0)
        {
            toDie();
        }else
        {
            HitTime = resetHitTime;
        }
/*
        if (type==EnemyType.enemy2)//enemy2刚被子弹攻击后的样子改变
        {
            if (HP<=2)//HP等于2的时候执行
            {
                HitAnimation();
            }
        }

        if (type==EnemyType.enemy3)//enemy3刚被子弹攻击后的样子改变
        {
            if (HP<=4)
            {
                HitAnimation();
            }
        }*/
    }

    public void toDie()
    {
        isDeath = true;
        AS.Play();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Score>().scoreadd += Score;
    }
/*
    public void HitAnimation()//击中变形动画
    {
                if (Hitone)
                {
                timer += Time.deltaTime;
                int nowframe = (int)(timer/(1f/DieAnimationFrame));////(1/T)计算每帧几秒  timer/(1/T)计算当前第几帧
                if (nowframe>=HitSprite.Length)//大于数组的值就销毁，因为爆炸动画只执行一次
                {
                    Hitone = false;
                }
                render.sprite = HitSprite[nowframe];
                }
    }
*/
}
