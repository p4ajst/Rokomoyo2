using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicEditor : ScriptableObject
{
    // メニューバーに項目を増やす
    [MenuItem("CustomEditor/Create Music Instance")]

    // インスタンスのアセットを生成
    static void CreateMusicInstance()
    {
        // インスタンス化
        MusicList music = CreateInstance<MusicList>();
        // アセットとして保存
        AssetDatabase.CreateAsset(music, "Assets/Editor/music.asset");
        AssetDatabase.Refresh();
    }

    // 保存したアセットを読み込む
    static void LoadAttractAsset()
    {
        // AssetのScriptableObjectを読み込む
        MusicList MusicAsset = AssetDatabase.LoadAssetAtPath<MusicList>("Assets/Editor/music.asset");
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
