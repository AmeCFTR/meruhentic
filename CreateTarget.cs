using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTarget : MonoBehaviour {

    public GameObject[] Target2;
    public int TargetNovelCount = 0; //赤ずきんの話を順番に表示する用
    GameObject CheckInst;
    int TargetNumber=0;
    float RandomX;
    float RandomY;
	
	void Start () {
        CheckInst.GetComponent<DestroyTarget>();
        TargetNovelCount = 0;
	}

	void Update () {

        if (DestroyTarget.InstCall==true)
        {
            CreateTargetNext();
        }
	}

    void CreateTargetNext()
    {
        TargetNumber++;
        TargetNovelCount++;
        DestroyTarget.InstCall = false;
        RandomX = Random.Range(-3.3f, 4.5f);
        RandomY = Random.Range(-2.35f, 2.2f);
        Instantiate(Target2[TargetNumber], new Vector3(RandomX,RandomY, 0.0f), Target2[TargetNumber].transform.rotation); 
    }
    
}
