using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 汎用的なクラス
/// </summary>
public static class Utility
{
    /// <summary>
    /// ステージ名の取得
    /// </summary>
    /// <param name="stageNum">ステージシーン番号</param>
    /// <returns>ステージ名を文字列で返す</returns>
    public static string GetStageName(int stageNum)
    {
        return "Stage" + stageNum.ToString();
    }
}
