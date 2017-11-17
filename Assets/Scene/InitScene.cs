using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// フェード用オブジェクト生成するため
/// </summary>
public class InitScene : MonoBehaviour
{
    
	// Use this for initialization
	void Start ()
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
        // コルーチンを作動
        sceneChanger.ExecuteCoroutine("Title");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
