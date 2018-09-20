using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderText3 : MonoBehaviour
{
    public GameObject T3;
    GameObject Target3;
    public Text Tar3Text;
    public Text Novel3Text; //上のウインドウに表示
    public string[] Tar3Word;
    public static bool Tar3Cheak = false;
    public static bool AllDeleteCheck3 = false;

    private int k = 0;
    // Use this for initialization
    void Start()
    {
        k = 0;
        Tar3Cheak = false;
        Target3= GameObject.FindGameObjectWithTag("Tar3");
        Tar3Text.text = Tar3Word[k];
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) //これだとTarget1以外のものに当たった時もTarget1が消えてまいクリアになってしまう
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (Tar3Cheak && OrderText.Tar1Cheak == false && OrderText2.Tar2Check == false)
            {
                
                Novel3Text.text = Tar3Word[k];
                //k++;
                Tar3Text.text = Tar3Word[k];
                OrderText.Tar1Cheak = true;
                Tar3Cheak = false;
                AllDeleteCheck3 = true;
                Target3.SetActive(false);
            }
            
            Debug.Log(AllDeleteCheck3);
        }
    }
}
