using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTimeAll : MonoBehaviour {
    public Text TimeAllLabel;
    float TimeAll=0;
	// Use this for initialization
	void Start () {
        TimeAll = 0;
	}
	
	// Update is called once per frame
	void Update () { 
        TimeAll = CountDown.ResultCountUp;
        Debug.Log(TimeAll);
        TimeAllLabel.text = "合計クリアタイム : " + TimeAll.ToString("0.#0") + "秒 ";
    }
}
