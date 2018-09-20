using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{

    enum State
    {
        StartGameExplain,
        StartCountDown,
        Play,
        BreakTime,
    }

    State state;
    public Text CountDownText;
    public GameObject Player;
    public GameObject ExplainText;
    public GameObject NovelGameClear;
    public GameObject NovelFrame;
    public GameObject Akazukin;
    public GameObject[] Target;

    public float StartCount = 4; //ゲーム開始前のカウントダウン
    int CountSuccessObject1;
    int CountSuccessObject2;
    int CountSuccessObject3;
    //int CountSuccessObject4;

    public static bool PermitBullet=false; //trueの時は弾丸を撃てる
    public static bool PermitMove=false; //trueの時にプレイヤーが動けるようになる

    move Move;
    // Use this for initialization
    void Start()
    {
        StartGameExplain();
        Move.GetComponent<move>().enabled = false;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (state)
        {
            case State.StartGameExplain:
                if (TextController2.EndLine && Input.GetKeyDown(KeyCode.Space))
                {
                    StartCountDown();
                }
                break;

            case State.StartCountDown:
                StartCount -= Time.deltaTime;
                CountDownText.text = "" + StartCount;
                if (StartCount <= 1)
                {
                    GameStart();
                    GetComponent<move>().enabled = true;
                }
                break;

            case State.Play:
                CountSuccessObject1 = GameObject.FindGameObjectsWithTag("Tar1").Length;
                CountSuccessObject2 = GameObject.FindGameObjectsWithTag("Tar2").Length;
                CountSuccessObject3 = GameObject.FindGameObjectsWithTag("Tar3").Length;
                if (CountSuccessObject1 == 0||Input.GetKeyDown(KeyCode.J))
                {
                    DeleteTime();
                }
                break;

            case State.BreakTime:

                if (TextControllerTutorial.EndLineTutorial && Input.GetKeyDown(KeyCode.Space))
                {
                    Next();
                }
                break;


        }
    }

    void StartGameExplain()
    {
        state = State.StartGameExplain;
        CountDownText.gameObject.SetActive(false);
        ExplainText.SetActive(true);
        Player.SetActive(false);
        NovelGameClear.SetActive(false);
        NovelFrame.SetActive(true);
        Akazukin.SetActive(true);
        Target[0].SetActive(true);
        Target[1].SetActive(true);
        Target[2].SetActive(true);

    }

    void StartCountDown()
    {
        state = State.StartCountDown;
        CountDownText.gameObject.SetActive(true);
        Player.SetActive(true);
        ExplainText.SetActive(false);
        Akazukin.SetActive(false);
        Target[0].SetActive(true);
        Target[1].SetActive(true);
        Target[2].SetActive(true);

        PermitMove = true;
    }

    void GameStart()
    {
        state = State.Play;
      
        CountDownText.gameObject.SetActive(false);
        ExplainText.SetActive(false);

        PermitBullet = true;
    }

    void DeleteTime()
    {
        Invoke("BreakTime", 1.0f);
        PermitBullet = false;
        PermitMove = false;
    }

    void BreakTime()
    {
        state = State.BreakTime;
        NovelFrame.SetActive(false);
        NovelGameClear.SetActive(true);
        Akazukin.SetActive(true);
    }

    void Next()
    {
        TextControllerTutorial.EndLineTutorial = false;
        SceneManager.LoadScene("main");
    }


}
