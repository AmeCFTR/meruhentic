using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

    public Text HighScoreTimeLabel;
    //int CatchTime;
    
	public void Start () {

       // CatchTime = PlayerPrefs.GetInt("HighScoreTime");
        //HighScoreTimeLabel.text = "ベストタイム : " + CatchTime + "秒";
        HighScoreTimeLabel.text = "ベストスコアポイント : " + PlayerPrefs.GetInt("HighScoreTime") + " PT";
       // Debug.Log(CatchTime);
    }
	
	
	void Update () {
		
	}
}
