using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    /// <summary>
    /// 音符のマテリアル
    /// </summary>
    public Material materialPink = null;
    public Material materialBlue = null;

    // Use this for initialization
    void Start ()
    {
        // 自分のポインタはシングルトンでなかったら
        if (this != Instance)
        {
            // スクリプトの削除
            Destroy(this);
            // 関数を抜ける
            return;
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
