using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTarget : MonoBehaviour {

    public GameObject Target;
    public Text[] TargetDeleteText;
    public int Size=3;
    public static int size=0;
    public static bool InstCall; //CreateTargetで使う
   /* public static int SZ()
    {
        return size;
    }*/

	void Start () {
        size = 0;
        InstCall = false;
	}

	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Bullet")
        {
            InstCall = true;
            NovelMaster.size++;
            // TargetDeleteText[size].gameObject.SetActive(true);
            Destroy(this.gameObject);
        }

        Invoke("DestroyText", 3.0f); 
    }
     
    void DestroyText() //オブジェクト自体が消えてしまうので呼び出されない
    {
        Debug.Log("Call");
        // TargetDeleteText.gameObject.SetActive(false);
        Destroy(TargetDeleteText[size]);
    }

}
