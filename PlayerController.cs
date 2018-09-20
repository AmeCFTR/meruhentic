using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public float Player_Speed = 3f;
    float x;
    float y;
    Vector2 direction;

    void Start() {
        
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        direction = new Vector2(x, y).normalized;

        if (GameController.PermitMove || TutorialController.PermitMove) //GameControllerのPermitMoveがtrueならキャラを動かせる
        {
            GetComponent<Rigidbody2D>().velocity = direction * Player_Speed;
        }

        if (transform.position.x < -6.05f)
        {
            transform.position = new Vector3(-6.0f, transform.position.y, 0f);
        }

        else if (transform.position.x > 6.05f)
        {
            transform.position = new Vector3(6.0f, transform.position.y, 0f);
        }

        else if (transform.position.y < -4.35f)
        {
            transform.position = new Vector3(transform.position.x, -4.3f, 0f);
        }

        else if (transform.position.y > -3.00f)
        {
            transform.position = new Vector3(transform.position.x, -3.01f, 0f);
        }

    }
}