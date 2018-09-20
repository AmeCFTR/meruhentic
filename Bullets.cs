using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullets : MonoBehaviour {

    public GameObject bullet1; //使用するゲームオブジェクトの定義
    public Transform muzzle;
    public static bool AllowShoot=true;
    public static float BulletCount=0;
    public static float BarragePrevent=0.6f; //弾丸を撃てる感覚

    GameController gamecontroller;

    // public static int score;
    // public Text scoreLabel;
   
    public float speed = 1000; //弾速

    private float timer;

	void Start () {
        timer = 0;
        gamecontroller = GetComponent<GameController>();
    }

    void FixedUpdate() {
        timer += Time.deltaTime; //マイフレームごとに時間取得

        //if (Input.GetButtonDown("Fire1")&&timer>=0.5f) { //GP Fire3 Bボタン
        if (Input.GetKeyDown(KeyCode.B) && timer >= 1f && GameController.PermitBullet==true && AllowShoot==true) {
        //if (Input.GetButtonDown("Fire1") && timer >= 1f && GameController.PermitBullet == true && AllowShoot == true){ //PS4 □ボタン
            
            BulletCount++; //命中率の時に使う
            AllowShoot = false;

            GameObject bullets = GameObject.Instantiate(bullet1) as GameObject; //弾の複製のため,bulletsを定義

            Vector3 force;
            force = this.gameObject.transform.up * speed; //前に進むようにする

            bullets.GetComponent<Rigidbody2D>().AddForce(force); //弾丸に前に進むための力を加える

            bullets.transform.position = muzzle.position; //弾丸生成位置をmuzzleの位置にする

            /* BarragePrevent += Time.deltaTime;
             if (BarragePrevent >= 0.8f)
             {
                 Allow();
                 BarragePrevent = 0;
             }*/
            Invoke("Allow", BarragePrevent); //一度撃つと0.6秒間撃てない
        
        }
        
        if (transform.position.y > 4.6f)
        {
            Destroy(this.gameObject);
           
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Target")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == ("TargetSuccess"))
        {
            Destroy(this.gameObject);
        }
     
    }

    void Allow()
    {
        AllowShoot = true;
    }

}





