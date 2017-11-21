using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージに関するクラス
/// </summary>
public class Stage : MonoBehaviour
{
    /// <summary>
    /// ステージシーン番号
    /// </summary>
    static int stageNum = 1;

    /// <summary>
    /// ステージの遷移
    /// </summary>
    public static void ChangeStage()
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
        // ステージの数値を加算
        stageNum += 1;

        if(stageNum < 21)
        {
            // コルーチンを作動
            sceneChanger.ExecuteCoroutine(Utility.GetStageName(stageNum));
        }
        else
        {
            // コルーチンを作動
            sceneChanger.ExecuteCoroutine("Title");
            stageNum = 1;
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
