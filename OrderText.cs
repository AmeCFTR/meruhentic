using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderText : MonoBehaviour {

    public GameObject T1;
    GameObject Target1;
    public Text Tar1Text;
    public Text Novel1Text; //上のウインドウに表示
    public string[] Tar1Word;
    public static bool Tar1Cheak = true;
    public static bool AllDeleteCheck1 = false;

    private int i= 0;
	// Use this for initialization
	void Start () {
        i = 0;
        Tar1Cheak = true;
        Target1=GameObject.FindGameObjectWithTag("Tar1");
        Tar1Text.text = Tar1Word[i];

}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col) //これだとTarget1以外のものに当たった時もTarget1が消えてまいクリアになってしまう
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (Tar1Cheak)
            {

                Novel1Text.text = Tar1Word[i];
                //i++;
                Tar1Text.text = Tar1Word[i];
                OrderText2.Tar2Check = true;
                Tar1Cheak = false;
                AllDeleteCheck1 = true;
                Target1.SetActive(false);

            }
           
            Debug.Log(AllDeleteCheck1);
        }
    }
}
