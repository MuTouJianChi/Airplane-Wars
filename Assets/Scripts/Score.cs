using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scoreadd =0;

    public int oldMaxScore;

    public int newMaxScore;

    public Text scoreText;
    public Text nowScore;
    public Text maxScoreText;

    public Text Die_NowScore;
    public Text Die_MaxScore;

    public GameObject Dragon;

    // Start is called before the first frame update
    void Start()
    {
        oldMaxScore = PlayerPrefs.GetInt("MaxScore",0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "分数："+scoreadd.ToString();
        nowScore.text = "当前分数:"+"\n"+scoreadd.ToString();
        maxScoreText.text = "最高分数:"+oldMaxScore.ToString();
        Die_NowScore.text = "当前分数："+"\n"+scoreadd.ToString();
        Die_MaxScore.text = "最高分数:"+oldMaxScore.ToString();

       //GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().Score += scoreadd;

       if (scoreadd>oldMaxScore)
       {
           newMaxScore = scoreadd;
           PlayerPrefs.SetInt("MaxScore",newMaxScore);
       }

       if (scoreadd>5201314)
       {
           Dragon.SetActive(true);
           Invoke("Dragon_over",5);
       }
    }

    public void Dragon_over()
    {
        Destroy(Dragon);
    }
}
