using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultMIssCatch : MonoBehaviour {
    public Text AllMissCountLabel;
    public Text ResultRank;
    public Text AllPointLabel;
    int AllMissCount=0;
    float AllClearTime=0.0f;
    public int ResultPoint;
    public int PointScore = 1000;

	// Use this for initialization
	void Start () {
        AllMissCount = 0;
        AllClearTime = 0;
        AllMissCount = DestroyTargetFail.ResultMiss;
        AllClearTime += CountDown.ResultCountUp;
        AllMissCountLabel.text = "まちがえた数合計 : " + AllMissCount + " 回";

        DestroyTargetFail.ResultMiss = 0;
}
	
	// Update is called once per frame
	void Update () {
        ResultPoint = PointScore - (int)AllClearTime * 10 - AllMissCount * 10; 
        Debug.Log(ResultPoint);
        AllPointLabel.text = "けっかポイント : " + ResultPoint + "PT";

        Debug.Log(AllMissCount);
        Debug.Log(AllClearTime);

        if (ResultPoint >=800 )
        {
            ResultRank.text = "S";
        }
        else if (ResultPoint >=650  && AllMissCount <= 799)
        {
            ResultRank.text = "A";
        }
        else if (AllMissCount >= 550 && AllMissCount <= 649)
        {
            ResultRank.text = "B";
        }
        else if (AllMissCount <=549 )
        {
            ResultRank.text = "C";
        }

        if (PlayerPrefs.GetInt("HighScoreTime") < ResultPoint) //ハイスコアを初期化したいときは不等号を逆(<)にしてResultCountUpに適当な数を入れる
       {
           PlayerPrefs.SetInt("HighScoreTime", ResultPoint);
       }
    }
}
