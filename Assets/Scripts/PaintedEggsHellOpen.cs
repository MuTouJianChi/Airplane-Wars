using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintedEggsHellOpen : MonoBehaviour
{
    public GameObject paintedEggsHell;

    int A;

    // Start is called before the first frame update
    void Start()
    {
        A = PlayerPrefs.GetInt("CaiDan",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if (A>0)
        {
        }else
        {
            paintedEggsHell.SetActive(true);
            A+=1;
            PlayerPrefs.SetInt("CaiDan",A);
            PlayerPrefs.Save();
        }
    }

    public void Quit()
    {
        paintedEggsHell.SetActive(false);
    }
}
