using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// シングルトン
/// </summary>
/// <typeparam name="T">テンプレートのＴ</typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    private static T instance;

    /// <summary>
    /// インスタンスのプロパティ
    /// </summary>
    public static T Instance
    {
        // 取得
        get
        {
            // インスタンスがNULLだったら
            if (instance == null)
            {
                // オブジェクトを探す
                instance = (T)FindObjectOfType(typeof(T));

                // インスタンスがNULLだったら
                if (instance == null)
                {
                    // エラーログを表示
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }
            // インスタンス
            return instance;
        }
    }
}
