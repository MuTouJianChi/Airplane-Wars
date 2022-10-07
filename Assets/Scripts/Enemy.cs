using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType{//Type������
    enemy1,
    enemy2,
    enemy3
}

public class Enemy : MonoBehaviour
{
    public int HP = 1;

    public float speed = 1;

    public int Score = 10;

    public EnemyType type;//��Unity��ʵ��Type���ʹ��

    public bool isDeath = false;

    public Sprite[] DieSprite;
    
    public Sprite[] HitSprites;

    private float timer = 0;

    public int DieAnimationFrame=10;//ÿ�뼸֡/����˵�����������ٶ�

    private SpriteRenderer render;

    public float HitTime = 0.2f;//����ʱ��

    private float resetHitTime ;//���û���ʱ�� 

    AudioSource AS;

   // public bool Hitone = true;//���б��κ󶯻�ִֻ��һ�εķ�ʽ

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();//GetComponent������Ϸ���������ķ���
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
                int nowframe = (int)(timer/(1f/DieAnimationFrame));////(1/T)����ÿ֡����  timer/(1/T)���㵱ǰ�ڼ�֡
                if (nowframe>=DieSprite.Length)//���������ֵ�����٣���Ϊ��ը����ִֻ��һ��
                {
                    Destroy(gameObject);
                }
                render.sprite = DieSprite[nowframe];
        }else//���ж���
        {
            if (HitTime>=0)
            {
                HitTime -= Time.deltaTime;

                int nowhitframe = (int)((resetHitTime-HitTime)/(1f/DieAnimationFrame));//resetHitTime-HitTime���ߵ�ʱ��

                nowhitframe%=2;//�жϲ�����һ֡

                render.sprite = HitSprites[nowhitframe];
            }
        }
    }

    public void BeHit()
    {
        HP -= 1;//��Ϊ�����ܵ��˺�������ͳһ��Ѫ������Ҳһ��
        if (HP<=0)
        {
            toDie();
        }else
        {
            HitTime = resetHitTime;
        }
/*
        if (type==EnemyType.enemy2)//enemy2�ձ��ӵ�����������Ӹı�
        {
            if (HP<=2)//HP����2��ʱ��ִ��
            {
                HitAnimation();
            }
        }

        if (type==EnemyType.enemy3)//enemy3�ձ��ӵ�����������Ӹı�
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
    public void HitAnimation()//���б��ζ���
    {
                if (Hitone)
                {
                timer += Time.deltaTime;
                int nowframe = (int)(timer/(1f/DieAnimationFrame));////(1/T)����ÿ֡����  timer/(1/T)���㵱ǰ�ڼ�֡
                if (nowframe>=HitSprite.Length)//���������ֵ�����٣���Ϊ��ը����ִֻ��һ��
                {
                    Hitone = false;
                }
                render.sprite = HitSprite[nowframe];
                }
    }
*/
}
