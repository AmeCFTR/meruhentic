using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CountDown.ResultCountUp=0;
    }
	
	// Update is called once per frame
	void Update () {
        Invoke("GoMainGame", 0.5f);
	}

    void GoMainGame()
    {
        SceneManager.LoadScene("main");
    }
}
