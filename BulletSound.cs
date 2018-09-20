using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSound : MonoBehaviour {
    public AudioClip audioClip;
    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>(); //AudioSource内のドラッグ＆ドロップしたSEやBGMを参照
        audioSource.clip = audioClip;
    }
	
	// Update is called once per frame
	void Update () {
       // if (Input.GetKeyDown(KeyCode.A))
       if(Input.GetButtonDown("Fire1")) //GP
        {
            audioSource.Play();
        }
	}
}
