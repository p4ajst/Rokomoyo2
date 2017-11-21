using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 曲リストのクラス
/// </summary>
public class MusicList : ScriptableObject
{
    // インスペクタ上で編集可能
    [System.SerializableAttribute]

    /// <summary>
    /// 再生する曲のデータ
    /// </summary>
    public class MusicData
    {
        // 曲のデータ
        public AudioClip musicClip;
        // 曲名
        public string musicName;
        // 作曲者名
        public string composerName;
    }

    /// <summary>
    /// 曲リスト
    /// </summary>
    public MusicData[] attractMusics = new MusicData[20];
    public MusicData[] awayMusics = new MusicData[20];
}
