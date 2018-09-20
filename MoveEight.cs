using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEight : MonoBehaviour {

    public float m_MoveSpeed = 6.0f; //移動速度
    public float m_radius = 20.0f;//円の半径
    public float randomTimeCatch=1.0f;
    float randomTime;
    float random;
    float TimeCheck = 0.01f;
    float TimeCheckCatch;
    
	// Use this for initialization
	void Awake () {
        random += 0.1f;
        randomTimeCatch = 0.1f;
           }

	// Update is called once per frame
	void Update () {
        TimeCheckCatch += Time.deltaTime;
        if (TimeCheck <= TimeCheckCatch)
        {
            randomTimeCatch = 30.0f; //位置変更までのカウント
        }
        //円運動
        // MoveToCircle(); 

        //8の字移動
        MoveToFigureOfEight();

        randomTime += Time.deltaTime;
        if (randomTimeCatch <= randomTime)
        {
            randomTime = 0;
            random = Random.Range(2.0f, 4.0f);

            m_MoveSpeed= random;
        }

	}

   /* void MoveToCircle()
    {

        float time = Time.time; //経過時間の取得、後の引数となる

        float x = Mathf.Sin(time); //↓円運動の座標演算、上のtime変数を引数(処理の材料)に
        float y = transform.position.y;
        float z = Mathf.Cos(time);

        transform.position = new Vector3(x,y,z);
    }*/

    void MoveToFigureOfEight()
    {

        float time = Time.time;
        float x = Mathf.Cos(time * m_MoveSpeed) * m_radius;
        float y = transform.position.y;
        float z = Mathf.Sin(time * m_MoveSpeed * 2) * m_radius / 3;


        transform.localPosition = new Vector3(x, y, z);
    }
}
