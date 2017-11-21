using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class name : MonoBehaviour
{
    SoundManager sm;


    void DisplayName(MusicList.MusicData data)
    {

        Text music;
        Text composer;


        music = this.GetComponent<Text>();
        composer = this.GetComponent<Text>();

        // nullチェック
        if (data == null)
        {
            return;
        }
        //// 空白
        //string str = "　　";

       // 曲名表示
       //GUI.Label(new Rect(100, 625, 500, 100), data.musicName);
        music.text = data.musicName;
       // 作曲者表示
       //GUI.Label(new Rect(500, 625, 500, 100), data.composerName);
        composer.text = data.composerName;

    }

    // Use this for initialization
    void Start ()
    {
        GameObject obj = GameObject.Find("SoundManager");
        sm = obj.GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
