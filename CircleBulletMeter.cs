using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleBulletMeter : MonoBehaviour {

    public Image BulletMeter;
    GameObject BulletGage;
    float time;
   // public float CanShoot=5f; //0.6秒でfillAmountが1から0になる

	void Start () {
        GameObject Bullet =GameObject.FindGameObjectWithTag("Bullet");
       // this.BulletGage = GameObject.Find("BulletStan");
        BulletMeter.fillAmount = 1.0f;
	}
	
	void FixedUpdate () {
        if (Bullets.AllowShoot==false)
        {
            time += Time.deltaTime;
            //BulletMeter.fillAmount -= 1.0f / CanShoot * Time.deltaTime;
            BulletMeter.fillAmount -= 1.0f / Bullets.BarragePrevent * Time.deltaTime;
            if (BulletMeter.fillAmount <= 0.0f)
            {
                BulletMeter.fillAmount = 1.0f;
               
            }

            else if (BulletMeter.fillAmount != 0 && time >= Bullets.BarragePrevent)
            {
                time = 0.0f;
                BulletMeter.fillAmount = 1.0f;
            }
        }
	}
}
