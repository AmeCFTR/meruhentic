using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelMaster : MonoBehaviour
{
    public Text[] NovelText;
    public Text StartLabel;
    public int Size = 4;
    public static int size = 0;
	// Use this for initialization
	void Start () {
        size = -1;
        int i=0;
        for (i = 0; i < Size; i++)
        {
            NovelText[i].gameObject.SetActive(false);

        }
    }
	
	// Update is called once per frame
	void Update () { //DestroyMasterでsizeがインクリメントされると次の文が表示される
        NovelText[size].gameObject.SetActive(true);
        Debug.Log(size);
        NovelText[size-1].gameObject.SetActive(false); //前のテキストを消す

                                                     /*iのループでSetActiveをfalseにしても結局sizeには0が入っているため、
　　　　　　　　　　　　　                            NovelText[0]は最初から表示されてしまっている。
　　　　　　　　　　　　　　　　　　　　　　　　　　　そのためsizeに-1を入れたら解決したが配列がマイナスになることは非推奨*/
        if (size >= 1)
        {
            StartLabel.gameObject.SetActive(false);
        }
    }
}
