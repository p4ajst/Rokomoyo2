using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
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
        sceneChanger.ExecuteCoroutine("Title");
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // クリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            // クリック処理
            onClick();
        }
    }
}
