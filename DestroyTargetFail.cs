using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTargetFail : MonoBehaviour
{ 
    public GameObject Target;
    public GameObject InfiniteFailTarget; //Missターゲットが撃たれると無限に生成
    public Text MissShootLabel;
    public static int ResultMiss;
    float FailRandomX;
    float FailRandomY;
    float RotateLock = 0.0f;
   // public Text TargetDeleteText;

    public static int MissCount = 0;

    public static int Mc()
    {
        return MissCount;
    }

    void Start()
    {
        //TargetDeleteText.gameObject.SetActive(false);
        MissCount = 0;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Bullet")
        {
            MissCount++;
            ResultMiss++;
            //  Destroy(this.gameObject);
            // TargetDeleteText.gameObject.SetActive(true);

            FailRandomX = Random.Range(-3.3f, 4.5f);
            FailRandomY = Random.Range(-2.35f, 2.2f);
            this.transform.position = new Vector3(FailRandomX, FailRandomY, 0.0f);
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, RotateLock);
            MissShootLabel.gameObject.SetActive(true);
        }
      //  Instantiate(InfiniteFailTarget, new Vector3(FailRandomX, FailRandomY, 0.0f), InfiniteFailTarget.transform.rotation);

        Invoke("DestroyText", 1.0f);
    }

    void DestroyText() //オブジェクト自体が消えてしまうので呼び出されない
    {
        Debug.Log("Call");
        MissShootLabel.gameObject.SetActive(false);
        // TargetDeleteText.gameObject.SetActive(false);
        //Destroy(TargetDeleteText);
    }

}
