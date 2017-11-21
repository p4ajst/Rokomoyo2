using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンをクリックされた時の処理
/// </summary>
public class ButtonClick : MonoBehaviour
{
    /// <summary>
    /// タイトルシーン
    /// </summary>
    TitleScene title = null;

    /// <summary>
    /// クリックされた時の処理
    /// </summary>
    /// <param name="objectName">クリックされたオブジェクトの名前</param>
    public void onClick(string objectName)
    {
        // 押されたボタンによって処理を分岐
        // ゲームスタートが押されたら
        if("GameStartButton".Equals(objectName))
        {
            // プレイシーンに移行する
            title.onClick();
        }
        else
        {
            throw new System.Exception("Not implemented!!");
        }
    }



    // Use this for initialization
    void Start ()
    {
        title = new TitleScene();
        if(title == null)
        {
            return;
        }
        title = title.GetComponent<TitleScene>();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
