using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
    public float speed = 3.0f;
    float alfa;
    float red, green, blue;

	// Use this for initialization
	void Start () {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed;

     
	}
}
