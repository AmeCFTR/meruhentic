using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    enum State
    {
        Ready,
        StartExplain,
        StartCountDown,
        Play,
        BreakTime,
        Play2,
        GameOver
    }

    State state;
    public Text ReadyLabel;
    public Text Stage1Label;
    public Text ExplainLabel;
    public Text BreakTimeLabel;
    public Text Stage2Label;
    public Text GameOverLabel;
    public Text SubTitle;
    public Text TotalTimeText;
    public Text CountDownText;
    public Text PreOKText;
    public Text TotalMissText;
    public Text MissLabel;

    public Text BlackDeleteText;
    public Text WhiteDeleteText;
    public Text GlayDeleteText;

    public GameObject Timer;


    //public GameObject Target_Black;
    //public GameObject Target_White;
    //public GameObject Target_Gray;

    public GameObject Player; //自機
    public GameObject[] Target; //的を格納しておく変数配列
    public GameObject Blind;
    public GameObject ExplainText; //説明のノベルテキストが出る
    public GameObject NovelGameClear; //クリアしたときにノベルテキストが出る
    public GameObject NovelGameOver; //使わない
    public GameObject NovelFrame;
    public GameObject Akazukin;
    //public GameObject BulletMeter;
    GameObject TimerCheck;
    GameObject TextCheck2;
    GameObject TextCheck3;

    public static bool PermitBullet; //trueの時は弾丸を撃てる
    public static bool PermitMove; //trueの時にプレイヤーが動けるようになる

    public float TotalTime=0.0f; //合計経過時間格納変数
    public static float ResultTime = 0.0f;
    int ShootCount; //今のところ使ってない
    int count; //使っていない
    int AllMiss=0; //合計ミス回数
    int countSuccessObject; //正解のオブジェクトを数えるための変数
    public float StartCount=4; //ゲーム開始前のカウントダウン

    void Start () {
        Ready();
        TimerCheck.GetComponent<CountDown>();
        TextCheck2.GetComponent<TextController2>();
        TextCheck3.GetComponent<TextController2A>();

        AllMiss = 0;
        AllMiss = DestroyTargetFail.Mc();
	}
	

	void LateUpdate () {

        switch (state)
        {
            case State.Ready:
                Invoke("Down", 3.0f);
                break;

            case State.StartExplain:
                // StartCount -= Time.deltaTime;
                // CountDownText.text = "" + StartCount;
                /* if (StartCount <= 1)
                 {
                     GameStart();
                 }*/

                //if (TextController2.currentLine < TextController2.scenarios.Length + 1 && Input.GetButtonDown("Fire3"))
               // if(TextController2.EndLine&&Input.GetButtonDown("Fire3"))
                if (TextController2.EndLine && Input.GetKeyDown(KeyCode.Space))
                {
                    //TextController2.EndLine = false;
                    ThreeCountDown();
                }
                break;

            case State.StartCountDown:
             StartCount -= Time.deltaTime;
             CountDownText.text = "" + StartCount;
             if (StartCount <= 1)
             {
                 GameStart();
             }

                break;

            case State.Play:
                count=GameObject.FindGameObjectsWithTag("Target").Length;
                countSuccessObject = GameObject.FindGameObjectsWithTag("TargetSuccess").Length;

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    ShootCount++;
                }

                //if (count==0) //敵がいなくなったらクリア画面へ
                if (countSuccessObject == 0) 
                {
                    DeleteTime();
                }
             
                break;

            case State.BreakTime:

                //if (Input.GetKeyDown(KeyCode.X))
                //if(Input.GetButtonDown("Fire3")&&TextController2A.EndLineB)
                if(Input.GetKeyDown(KeyCode.Space)&&TextController2A.EndLineB) 
                {
                    GameStart2();
                }


                if (Input.GetKeyDown(KeyCode.P))
                {
                    ReturnTitle();
                }
                break;


            case State.Play2:
                Invoke("GameOver", 4.0f);
                break;

            case State.GameOver:
                if (Input.GetKeyDown(KeyCode.V))
                {
                    ReturnTitle();
                }
                break;
        }
	}
    void Ready()
    {

        state = State.Ready;
        ReadyLabel.gameObject.SetActive(true);
        ExplainLabel.gameObject.SetActive(false);
        Stage1Label.gameObject.SetActive(false);
        BreakTimeLabel.gameObject.SetActive(false);
        Stage2Label.gameObject.SetActive(false);
        GameOverLabel.gameObject.SetActive(false);

       // Target_Black.SetActive(true);
       // Target_White.SetActive(true);
       // Target_Gray.SetActive(true);

        Target[0].SetActive(false);
        Target[1].SetActive(false);
        Target[2].SetActive(false);
        ExplainText.SetActive(false);
        NovelGameClear.SetActive(false);
        NovelGameOver.SetActive(false);
        NovelFrame.SetActive(false);
        Akazukin.SetActive(false);
        //BulletMeter.SetActive(false);
        BlackDeleteText.gameObject.SetActive(false);
        WhiteDeleteText.gameObject.SetActive(false);
        GlayDeleteText.gameObject.SetActive(false);
        Timer.gameObject.SetActive(false);
        TotalTimeText.gameObject.SetActive(false);
        CountDownText.gameObject.SetActive(false);
        PreOKText.gameObject.SetActive(false);
        TotalMissText.gameObject.SetActive(false);
        MissLabel.gameObject.SetActive(false);

        PermitBullet = false;
        PermitMove = false;
        
}

    void Down()//説明パート
    {
        state=State.StartExplain;
    
        ReadyLabel.gameObject.SetActive(false);
        Stage1Label.gameObject.SetActive(false);
        ExplainLabel.gameObject.SetActive(true);
        BreakTimeLabel.gameObject.SetActive(false);
        Stage2Label.gameObject.SetActive(false);
        GameOverLabel.gameObject.SetActive(false);
        CountDownText.gameObject.SetActive(false);
        PreOKText.gameObject.SetActive(false);
        BlackDeleteText.gameObject.SetActive(false);
        WhiteDeleteText.gameObject.SetActive(false);
        GlayDeleteText.gameObject.SetActive(false);
        SubTitle.gameObject.SetActive(false);
        Timer.gameObject.SetActive(false);
        TotalTimeText.gameObject.SetActive(false);

        Target[0].SetActive(false);
        Target[1].SetActive(false);
        Target[2].SetActive(false);
        ExplainText.SetActive(true);
        NovelGameClear.SetActive(false);
        NovelGameOver.SetActive(false);
        Akazukin.SetActive(true);

       // Debug.Log(StartCount);
    }

    public void ThreeCountDown()
    {
        state = State.StartCountDown;
        ReadyLabel.gameObject.SetActive(false);
        Stage1Label.gameObject.SetActive(false);
        ExplainLabel.gameObject.SetActive(false);
        BreakTimeLabel.gameObject.SetActive(false);
        Stage2Label.gameObject.SetActive(false);
        GameOverLabel.gameObject.SetActive(false);
        CountDownText.gameObject.SetActive(true);
        PreOKText.gameObject.SetActive(true);
        BlackDeleteText.gameObject.SetActive(false);
        WhiteDeleteText.gameObject.SetActive(false);
        GlayDeleteText.gameObject.SetActive(false);
        SubTitle.gameObject.SetActive(false);
        Timer.gameObject.SetActive(false);
        TotalTimeText.gameObject.SetActive(false);

        Target[0].SetActive(false);
        Target[1].SetActive(false);
        Target[2].SetActive(false);
        ExplainText.SetActive(false);
        NovelGameClear.SetActive(false);
        NovelGameOver.SetActive(false);
        Akazukin.SetActive(false);
        
        PermitMove = true;
        TextController2.EndLine = false;
        Debug.Log(TextController2.EndLine);
    }

    void GameStart()
    {

        state = State.Play;
        ReadyLabel.gameObject.SetActive(false);
        Stage1Label.gameObject.SetActive(true);
        CountDownText.gameObject.SetActive(false);
        PreOKText.gameObject.SetActive(false);
        Timer.gameObject.SetActive(true);
        Target[0].SetActive(true);
        Target[1].SetActive(true);
        Target[2].SetActive(true);
        NovelFrame.SetActive(true);
       // BulletMeter.SetActive(true);

        Blind.SetActive(false);
        ExplainText.SetActive(false);

        Destroy(SubTitle.gameObject);

        PermitBullet = true;

    }

    void DeleteTime()
    {
        Target[0].SetActive(false);
        Target[2].SetActive(false);
        Timer.SetActive(false);
        Invoke("StageClear", 2.0f);
    }
    void StageClear()
    {
        BreakTimeSystem();
        Timer.gameObject.SetActive(false);
    }
    void BreakTimeSystem()
    {
        state = State.BreakTime;
        TotalTime = CountDown.CountUpTime;//経過時間取得
        ResultTime += TotalTime;


        TotalTimeText.text = "クリアタイム : " + TotalTime.ToString("0.#0") + "秒";
        TotalMissText.text = "ミス回数 :  " + DestroyTargetFail.Mc() +"回";

        ReadyLabel.gameObject.SetActive(false);
        Stage1Label.gameObject.SetActive(false);
        BreakTimeLabel.gameObject.SetActive(true);
        Stage2Label.gameObject.SetActive(false);
        GameOverLabel.gameObject.SetActive(false);

        BlackDeleteText.gameObject.SetActive(false);
        WhiteDeleteText.gameObject.SetActive(false);
        GlayDeleteText.gameObject.SetActive(false);
        Timer.gameObject.SetActive(false);
        TotalTimeText.gameObject.SetActive(true);
        TotalMissText.gameObject.SetActive(true);

        NovelGameClear.SetActive(true);
        NovelFrame.SetActive(false);
        //BulletMeter.SetActive(false);
       // Blind.SetActive(true);
        Player.SetActive(false);

        PermitBullet = false;
        PermitMove = false; 
       // Debug.Log("BreakTime");
    }

    void GameStart2()
    {
        TextController2A.EndLineB = false;
        Debug.Log(TextController2A.EndLineB);
        SceneManager.LoadScene("main2");

        state = State.Play2;
        ReadyLabel.gameObject.SetActive(false);
        Stage1Label.gameObject.SetActive(false);
        BreakTimeLabel.gameObject.SetActive(false);
        Stage2Label.gameObject.SetActive(true);
        GameOverLabel.gameObject.SetActive(false);

        NovelGameClear.SetActive(false);
        NovelFrame.SetActive(true);
        BlackDeleteText.gameObject.SetActive(false);
        WhiteDeleteText.gameObject.SetActive(false);
        GlayDeleteText.gameObject.SetActive(false);

    }

    void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }

    void GameOver()
    {
        state = State.GameOver;
        ReadyLabel.gameObject.SetActive(false);
        Stage1Label.gameObject.SetActive(false);
        Stage2Label.gameObject.SetActive(false);
        GameOverLabel.gameObject.SetActive(true);

        BlackDeleteText.gameObject.SetActive(false);
        WhiteDeleteText.gameObject.SetActive(false);
        GlayDeleteText.gameObject.SetActive(false);

        NovelGameOver.SetActive(true);
        NovelFrame.SetActive(false);

        Timer.gameObject.SetActive(false);
        Blind.SetActive(true);
    }
}
