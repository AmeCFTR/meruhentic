using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderText2 : MonoBehaviour
{
    public GameObject T2;
    GameObject Target2;
    public Text Tar2Text;
    public Text Novel2Text; //上のウインドウに表示
    public string[] Tar2Word;
    public static bool Tar2Check = false;
    public static bool AllDeleteCheck2=false;

    private int j= 0;
    // Use this for initialization
    void Start()
    {
        j = 0;
        Tar2Check = false;
        Target2=GameObject.FindGameObjectWithTag("Tar2");
        Tar2Text.text = Tar2Word[j];
 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) //これだとTarget1以外のものに当たった時もTarget1が消えてまいクリアになってしまう
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (Tar2Check && OrderText.Tar1Cheak == false)
            {
                
                Novel2Text.text = Tar2Word[j];
                //j++;
                Tar2Text.text = Tar2Word[j];
                OrderText3.Tar3Cheak = true;
                Tar2Check = false;
                AllDeleteCheck2 = true;
                Target2.SetActive(false);
            }
            Debug.Log(AllDeleteCheck2);
        }
    }
}
