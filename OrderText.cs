using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderText : MonoBehaviour {

    public GameObject Target1;
    public GameObject Target2;
    public GameObject Target3;

    public Text Tar1Text;
    public Text Tar2Text;
    public Text Tar3Text;

    public string[] Tar1Word;
    public string[] Tar2Word;
    public string[] Tar3Word;

    public bool Tar1Cheak = true;
    public bool Tar2Check = false;
    public bool Tar3Cheak = false;

    int i, j, k = 0;
	// Use this for initialization
	void Start () {
         Tar1Cheak = true;
         Tar2Check = false;
         Tar3Cheak = false;

        Tar1Text.text = Tar1Word[i];
        Tar2Text.text = Tar2Word[j];
        Tar3Text.text = Tar3Word[k];
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
                Target1.SetActive(false);
                Tar1Cheak = false;
                Tar2Check = true;
            }

            else if (Tar2Check)
            {
                Target2.SetActive(false);
                Tar2Check = false;
                Tar3Cheak = true;

            }

            else if (Tar3Cheak)
            {
                Target3.SetActive(false);
                Tar1Cheak = true;
                Tar3Cheak = false;
            }
        }
    }
}
