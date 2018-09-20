using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public GameObject FailTarget;
    public bool ReturnTarget = true;
	void Start () {
        // GetComponent<Rigidbody2D>().velocity = transform.forward;
        ReturnTarget = true;
	}
	
	void Update () {

        //GetComponent<Rigidbody2D>().AddForce((Vector2.up + Vector2.right) * 0.8f, ForceMode2D.Force);
         if (ReturnTarget)
         {
             this.transform.position += new Vector3(0.06f, 0.05f, 0);
         }

         if (ReturnTarget == false)
         {
             this.transform.position += new Vector3(0, -0.01f, 0);
         }

         /*transform.Rotate(new Vector3(Random.Range(0, 180),
                                      Random.Range(0, 180),
                                      Random.Range(0, 180)
                                      ) * Time.deltaTime);*/
    }

    void OnCollisionEnter2D(Collision2D Fail)
    {
            ReturnTarget = false;
        
        if (ReturnTarget == false)
        {
            ReturnTarget = true;
        }
       

    }
}
