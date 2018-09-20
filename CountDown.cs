using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public static float CountUpTime =0.0f;
    public static float ResultCountUp; //Result画面で合計時間表示用
    
    public Text Count;
	// Use this for initialization
	void Start () {
        CountUpTime = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
        CountUpTime += Time.deltaTime;
        ResultCountUp += Time.deltaTime;
        Count.text = "経過時間 : " + CountUpTime.ToString("0.#0") +" 秒";

	}
}
