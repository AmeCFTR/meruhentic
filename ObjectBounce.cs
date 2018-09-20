using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce : MonoBehaviour //反発させる処理
{
    private Vector2 lastVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        this.lastVelocity = this.rb.velocity; //velocityは速度ベクトル
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, coll.contacts[0].normal); //Vector2.Reflectは法線で定義された平面でベクトルを反射する。
        this.rb.velocity = refrectVec;
    }
}
