using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene : MonoBehaviour
{
    // コルーチンの終了判定
    bool isEnd = false;

    /// <summary>
    /// ゲーム開始前のカウントダウン
    /// </summary>
    /// <returns>コルーチン使用の為の型</returns>
    IEnumerator CountDown()
    {
        // 残り３秒のエフェクトを実行
        Debug.Log("3");
        // １秒間処理を止める
        yield return new WaitForSeconds(1.0f);
        // 残り２秒のエフェクトを実行
        Debug.Log("2");
        // １秒間処理を止める
        yield return new WaitForSeconds(1.0f);
        // 残り１秒のエフェクトを実行
        Debug.Log("1");
        // １秒間処理を止める
        yield return new WaitForSeconds(1.0f);
        // ゲーム開始のエフェクトを表示
        Debug.Log("GameStart!");
        // コルーチンの終了を通知
        isEnd = true;
    }

    /// <summary>
    /// カウントダウンを開始する
    /// </summary>
    void StartCountDown()
    {
        // コルーチンを開始する
        StartCoroutine(CountDown());
    }

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
        sceneChanger.ExecuteCoroutine("Stage1");
    }


    // Use this for initialization
    void Start ()
    {
        if(isEnd == false)
        {
            // ゲーム開始前のカウントダウン
            StartCountDown();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        // ゴールしたら
        // タイマーを止める
        // クリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            // クリック処理
            onClick();
        }
    }
}
