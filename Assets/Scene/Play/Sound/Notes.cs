using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 音符
/// </summary>
public class Notes : MonoBehaviour
{

    /// <summary>
    /// 曲のタイプ
    /// </summary>
    public enum MusicType
    {
        // 無音
        NONE,
        // 近づける音
        ATTRACT,
        // 遠ざける音
        AWAY,
    };

    /// <summary>
    /// 音の種類
    /// </summary>
    public MusicType type = MusicType.NONE;

    /// <summary>
    /// 管理者を記憶
    /// </summary>
    SoundManager soundManager = null;

    /// <summary>
    /// 曲情報
    /// </summary>
    //private MusicList.MusicData soundData;

    private MusicList.MusicData attract;
    private MusicList.MusicData away;

    /// <summary>
    /// 曲のデータのプロパティ
    /// </summary>
    //public MusicList.MusicData SoundData
    //{
    //    // 取得
    //    get
    //    {
    //        return soundData;
    //    }
    //}

    public MusicList.MusicData Attract
    {
        // 取得
        get
        {
            return attract;
        }
    }
    public MusicList.MusicData Away
    {
        // 取得
        get
        {
            return away;
        }
    }

    /// <summary>
    /// げーむの管理者
    /// </summary>
    GameManager gameManager = null;

    /// <summary>
    /// キャラクターの管理のクラスのインスタンス
    /// </summary>
    CharacterManager charaManager;

    /// <summary>
    /// 音符の初期化
    /// </summary>
    void InitNotes()
    {
        // 管理者のオブジェクトを探す
        GameObject obj = GameObject.Find("SoundManager");
        // PlayManagerのコンポーネントを取得
        soundManager = obj.GetComponent<SoundManager>();
        // 曲情報の取得
        attract = soundManager.GetMusic(MusicType.ATTRACT);
        away = soundManager.GetMusic(MusicType.AWAY);
    }

    /// <summary>
    /// 音符がクリックされた時の処理
    /// </summary>
    /// <param name="data">クリックイベント</param>
    public void ClickNotes(BaseEventData data)
    {
        // 音符を設定
        charaManager.SetNotes(this.gameObject.GetComponent<Notes>());
        switch(type)
        {
            case MusicType.ATTRACT:
                // 音を再生させる
                if (soundManager.ChangeMusic(type, attract))
                {
                    // 音楽の再生
                    soundManager.PlayMusic();
                }
                else
                {
                    // 音楽の停止
                    soundManager.StopMusic();
                }
                break;
            case MusicType.AWAY:
                // 音を再生させる
                if (soundManager.ChangeMusic(type, away))
                {
                    // 音楽の再生
                    soundManager.PlayMusic();
                }
                else
                {
                    // 音楽の停止
                    soundManager.StopMusic();
                }
                break;
        }
        //// 音を再生させる
        //if(soundManager.ChangeMusic(type, soundData))
        //{
        //    // 音楽の再生
        //    soundManager.PlayMusic();
        //}
        //else
        //{
        //    // 音楽の停止
        //    soundManager.StopMusic();
        //}
    }

    /// <summary>
    /// 音符の反転
    /// </summary>
    public void FlipNote()
    {
        if (type == MusicType.ATTRACT)
        {
            type = MusicType.AWAY;
            SetNote();
        }
        else if (type == MusicType.AWAY)
        {
            type = MusicType.ATTRACT;
            SetNote();
        }
    }

    public void SetNote()
    {
        if(type == MusicType.ATTRACT)
        {
            GetComponent<Renderer>().material = gameManager.materialPink;
        }
        if (type == MusicType.AWAY)
        {
            GetComponent<Renderer>().material = gameManager.materialBlue;
        }
    }

    /// <summary>
    /// シーン開始時に実行される関数
    /// </summary>
    private void Awake()
    {
        GameObject obj =  GameObject.Find("CharacterManager");
        charaManager = obj.gameObject.GetComponent<CharacterManager>();
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start ()
    {
        InitNotes();
        GameObject obj = GameObject.Find("GameManager");
        gameManager = obj.GetComponent<GameManager>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update ()
    {
    }
}
