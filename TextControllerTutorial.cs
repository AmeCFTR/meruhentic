using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TextControllerTutorial : MonoBehaviour  //説明シーン
{
    public string[] scenarios;
    [SerializeField] Text uiText;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;	// 1文字の表示にかかる時間   
    public static int currentLine = 0;
    private string currentText = string.Empty;  // 現在の文字列 
    private float timeUntilDisplay = 0;     // 表示にかかる時間 
    private float timeElapsed = 1;          // 文字列の表示を開始した時間 
    private int lastUpdateCharacter = -1;       // 表示中の文字数 

    public GameObject NovelText;
    GameObject ContCatch;

    public static bool EndLineTutorial = false;

    void Start()
    {
        currentLine = 0;
        SetNextLine();
        ContCatch.GetComponent<GameController>();
    }


    void Update()
    {
        //if(currentLine<scenarios.Length && Input.GetMouseButtonDown(0)) 
        //if (currentLine < scenarios.Length && Input.GetButtonDown("Fire3"))
        if (currentLine < scenarios.Length && Input.GetKeyDown(KeyCode.B))
        {
            SetNextLine();
        }

        //else if (currentLine<scenarios.Length+1 && Input.GetMouseButtonDown(0)) 
        //else if (currentLine < scenarios.Length + 1 && Input.GetButtonDown("Fire3")) 
        else if (currentLine < scenarios.Length + 1 && Input.GetKeyDown(KeyCode.Space))
        {
            //CloseText();//次の行がなかったらテキストウィンドウを消す
            EndLineTutorial = true;
        }

        // クリックから経過した時間が想定表示時間の何%か確認し、表示文字数を出す 
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);

        // 表示文字数が前回の表示文字数と異なるならテキストを更新する 
        if (displayCharacterCount != lastUpdateCharacter)
        {
            uiText.text = currentText.Substring(0, displayCharacterCount);  //Substringは１文字ずつ表示
            lastUpdateCharacter = displayCharacterCount;
        }
    }

    void SetNextLine()
    {
        currentText = scenarios[currentLine];
        currentLine++;

        // 想定表示時間と現在の時刻をキャッシュ 
        timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;

        // 文字カウントを初期化 
        lastUpdateCharacter = -1;
    }

    void CloseText()
    {
        NovelText.SetActive(false);
        Debug.Log("Close Text");
    }
}
