using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MusicList : ScriptableObject
{
    // インスペクタ上で編集可能
    [System.SerializableAttribute]
    // 再生する曲のデータ
    public class MusicData
    {
        // 曲のデータ
        public AudioClip musicClip;
        // 曲名
        public string musicName;
        // 作曲者名
        public string composerName;
    }
    // 曲リスト
    public MusicData[] attractMusics = new MusicData[20];
    public MusicData[] awayMusics = new MusicData[20];
}
