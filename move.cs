using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public GameObject FailTarget;
    float Speed = 1;
    public float x=2.0f;
    public float y=2.0f;
    Rigidbody2D rd2d;
    float VelSpeed;
    
    void Start () {
      rd2d = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
      
        //Rigidbody2D rd2d = this.GetComponent<Rigidbody2D>();
        Vector3 force2d = new Vector3(x, y, 0.0f)*Speed*0.6f;
        rd2d.AddForce(force2d);
        this.transform.rotation = Quaternion.Euler(0, 0, 90);

        VelSpeed = rd2d.velocity.magnitude; //速度ベクトルを測定
        //Debug.Log(VelSpeed);

        if (VelSpeed >= 5.45f)
        {
            Speed = 0.13f;
        }
        else if (VelSpeed >= 6.0f)
        {
            Speed = 0.05f;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Speed = Random.Range(0.61f, 1.12f);
        x = Random.Range(-4.0f,4.0f);
        y = Random.Range(-2.0f,2.0f);
        this.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

   
}
