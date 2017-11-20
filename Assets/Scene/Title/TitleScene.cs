using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TitleScene : MonoBehaviour
{
    /// <summary>
    /// クリック処理
    /// </summary>
    public void onClick()
    {
        // オブジェクトを探す
        GameObject scene = GameObject.Find("FadePanel");
        // nullチェック
        if (scene == null)
        {
            // 関数を抜ける
            return;
        }
        // コンポーネントを取得
        SceneChanger sceneChanger = scene.GetComponent<SceneChanger>();
        // nullチェック
        if (sceneChanger == null)
        {
            // 関数を抜ける
            return;
        }
        // フェード中ならば
        if (sceneChanger.IsFading == true)
        {
            // 関数を抜ける
            return;
        }
        // コルーチンを作動
        sceneChanger.ExecuteCoroutine("stage1");
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
