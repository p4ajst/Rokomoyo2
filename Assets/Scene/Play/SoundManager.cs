using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音符の管理を制御する
/// </summary>
public class SoundManager : Singleton<SoundManager>
{
    /// <summary>
    /// 曲を再生するスピーカー
    /// </summary>
    public AudioSource music = null;

    /// <summary>
    /// どちらの曲を再生するか
    /// </summary>
    public Notes.MusicType nowPlay = Notes.MusicType.NONE;

    /// <summary>
    /// 曲の情報
    /// </summary>
    public MusicList attractMusic = null;
    public MusicList awayMusic = null;

    /// <summary>
    /// 設定済み曲を格納する配列
    /// </summary>
    List<AudioClip> usedAttractClips = new List<AudioClip>();
    List<AudioClip> usedAwayClips = new List<AudioClip>();

    /// <summary>
    /// 曲データの一時保存
    /// </summary>
    AudioClip temp = null;

    /// <summary>
    /// AudioSourceの初期化
    /// </summary>
    public void InitAudioSource()
    {
        // コンポーネントの取得
        music = GetComponent<AudioSource>();
        // 音量の変更
        music.volume = 1.0f;
        // ループを許可する
        music.loop = true;
    }

    /// <summary>
    /// 重複しない乱数
    /// </summary>
    /// <param name="rengeBegin"></param>
    /// <param name="rengeEnd"></param>
    /// <returns></returns>
    public int GetRandom(int rengeBegin = 0, int rengeEnd = 20)
    {
        // 戻り値用
        int result = 0;

        // 乱数を格納するリストを生成
        List<int> noteRandom = new List<int>();

        // 指定された範囲の整数で埋めたリストを作る
        for (int i = rengeBegin; i < rengeEnd; i++)
        {
            noteRandom.Add(i);
        }

        // ランダム生成用変数
        int rnd = 0;
        // 配列の最大値
        int arrayMax = rengeEnd;
        // 指定した回数分ループする
        for (int i = rengeBegin; i < rengeEnd; i++)
        {
            // ランダムを生成
            rnd = Random.Range(rengeBegin, arrayMax);
            result = noteRandom[rnd];
            // 取り出した値はリストから取り出す
            noteRandom.RemoveAt(rnd);
            // 配列の最大値を減らす（リストから取り除くと、配列の要素数が減るため）
            arrayMax--;
        }
        return result;
    }

    /// <summary>
    /// 曲情報の取得
    /// </summary>
    /// <param name="type">音符のタイプ</param>
    /// <returns>曲情報</returns>
    public MusicList.MusicData GetMusic(Notes.MusicType type)
    {
        // どの曲を使うかのインデックス
        int index = 0;

        // 音の種類が近づける音だったら
        if(type == Notes.MusicType.ATTRACT)
        {
            index = GetRandom(0, 20);
            temp = attractMusic.attractMusics[index].musicClip;
            while(true)
            {
                index = GetRandom(0, 20);
                temp = attractMusic.attractMusics[index].musicClip;
                if(usedAttractClips.IndexOf(temp) == -1)
                {
                    usedAttractClips.Add(temp);
                    return attractMusic.attractMusics[index];
                }
            }
        }
        // 音の種類が遠ざける音だったら
        if(type == Notes.MusicType.AWAY)
        {
            index = GetRandom(0, 20);
            temp = awayMusic.awayMusics[index].musicClip;
            while (true)
            {
                index = GetRandom(0, 20);
                temp = awayMusic.awayMusics[index].musicClip;
                if (usedAwayClips.IndexOf(temp) == -1)
                {
                    usedAwayClips.Add(temp);
                    return awayMusic.awayMusics[index];
                }
            }
        }
        // nullを返す
        return null;
    }

    /// <summary>
    /// 音符のタイプに基づいて曲の変更
    /// </summary>
    /// <param name="type">音符のタイプ</param>
    /// <param name="data">曲情報</param>
    /// <returns></returns>
    public bool ChangeMusic(Notes.MusicType type,MusicList.MusicData data)
    {
        // データがnullだったら
        if(data == null)
        {
            return false;
        }
        // 音のタイプと曲データが同じものだったら
        if((nowPlay == type)&&(music.clip == data.musicClip))
        {
            // 変更する必要がないので、falseを返す
            return false;
        }
        // そうでなかったら
        else
        {
            // 変更する必要があるので変数を代入する
            nowPlay = type;
            music.clip = data.musicClip;
            // trueを返す
            return true;
        }
    }

    /// <summary>
    /// 音楽の再生
    /// </summary>
    public void PlayMusic()
    {
        music.Play();
    }

    /// <summary>
    /// 音楽の停止
    /// </summary>
    public void StopMusic()
    {
        music.Stop();
        // 音のタイプをNONEにする
        nowPlay = Notes.MusicType.NONE;
    }
    

    ///// <summary>
    ///// 音符の反転
    ///// </summary>
    //public void FlipNote()
    //{
    //    if(nowPlay == Notes.MusicType.NONE)
    //    {
    //        return;
    //    }
    //    if(nowPlay == Notes.MusicType.ATTRACT)
    //    {
    //        nowPlay = Notes.MusicType.AWAY;
    //    }
    //    if(nowPlay == Notes.MusicType.AWAY)
    //    {
    //        nowPlay = Notes.MusicType.ATTRACT;
    //    }
    //}

    /// <summary>
    /// シーン開始時に最初に実行される関数
    /// </summary>
    private void Awake()
    {
        // 自分のポインタはシングルトンでなかったら
        if (this != Instance)
        {
            // スクリプトの削除
            Destroy(this);
            // 関数を抜ける
            return;
        }
        // 設定済み曲データを格納する配列の初期化
        usedAttractClips.Clear();
        usedAwayClips.Clear();
    }


    // Use this for initialization
    void Start ()
    {

        // AudioSourceの初期化
        InitAudioSource();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
