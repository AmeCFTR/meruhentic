using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMain : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        Invoke("GoMainScene", 1.0f);
        //Invoke("GoGame", 1.0f);
	}

    void GoMainScene()
    {
        //CountDown.ResultCountUp = 0; //合計タイム初期化
        SceneManager.LoadScene("ResetTime");
    }

    /*void GoGame()
    {
        SceneManager.LoadScene("main");
    }*/
}
