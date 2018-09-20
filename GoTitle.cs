using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Invoke("GoTitleScene", 2.5f);
	}

    void GoTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

   
}
