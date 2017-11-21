using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//// .csをアタッチしたオブジェクトを実行すると自動的にオブジェクトにコンポーネントがアタッチされる
//[RequireComponent(typeof(AudioSource))]
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

    // 音の種類
    public MusicType type = MusicType.NONE;
    // 管理者を記憶
    SoundManager soundManager = null;

    // 曲情報
    private MusicList.MusicData soundData;

    public MusicList.MusicData SoundData
    {
        // 取得
        get
        {
            return soundData;
        }
    }

    CharacterManager charaManager;



    //// 曲情報のインデックス
    //public int attractIndex = 0;
    //public int awayIndex = 0;

    //public class NoteInfo
    //{
    //    // 曲データ
    //    private AudioClip attract = null;
    //    public AudioClip Attract
    //    {
    //        get
    //        {
    //            return attract;
    //        }
    //    }
    //    private AudioClip away = null;
    //    public AudioClip Away
    //    {
    //        get
    //        {
    //            return away;
    //        }
    //    }

    //    // 曲名
    //    private string attractName = null;
    //    public string AttractName
    //    {
    //        get
    //        {
    //            return attractName;
    //        }
    //    }

    //    private string awayName = null;
    //    public string AwayName
    //    {
    //        get
    //        {
    //            return awayName;
    //        }
    //    }

    //    // 作曲者名
    //    private string attractComposer = null;
    //    public string AttractComposer
    //    {
    //        get
    //        {
    //            return attractComposer;
    //        }
    //    }

    //    private string awayComposer = null;
    //    public string AwayComposer
    //    {
    //        get
    //        {
    //            return awayComposer;
    //        }
    //    }

    //    // どちらの曲を再生するか
    //    public MusicType nowPlay = MusicType.NONE;
    //}

    ///// <summary>
    ///// 曲のタイプ
    ///// </summary>
    //public enum MusicType
    //{
    //    // 無音
    //    NONE,
    //    // 近づける音
    //    ATTRACT,
    //    // 遠ざける音
    //    AWAY,
    //};

    // 曲再生
    //public AudioSource music = null;
    //public AudioSource attract;
    //public AudioSource away;

    //// 曲情報
    //public MusicList attractMusic = null;
    //public MusicList awayMusic = null;

    //// どちらの曲を再生するか
    //public MusicType nowPlay = MusicType.NONE;

    //// 曲情報のインデックス
    //public int attractIndex = 0;
    //public int awayIndex = 0;



    //// 曲データ
    //private AudioClip attract = null;
    //public AudioClip Attract
    //{
    //    get
    //    {
    //        return attract;
    //    }
    //}
    //private AudioClip away = null;
    //public AudioClip Away
    //{
    //    get
    //    {
    //        return away;
    //    }
    //}

    //// 曲名
    //private string attractName = null;
    //public string AttractName
    //{
    //    get
    //    {
    //        return attractName;
    //    }
    //}

    //private string awayName = null;
    //public string AwayName
    //{
    //    get
    //    {
    //        return awayName;
    //    }
    //}

    //// 作曲者名
    //private string attractComposer = null;
    //public string AttractComposer
    //{
    //    get
    //    {
    //        return attractComposer;
    //    }
    //}

    //private string awayComposer = null;
    //public string AwayComposer
    //{
    //    get
    //    {
    //        return awayComposer;
    //    }
    //}

    //// どちらの曲を再生するか
    //public MusicType nowPlay = MusicType.NONE;

    //// 乱数用の配列
    //public int[] noteRandom;
    //// 乱数用の変数
    //public int random;
    //// 交換用変数
    //int tmp;

    //// 重複しない乱数
    //static IEnumerable<int> GetSimpleRandomAlgorithm(int rengeBegin = 0, int rengeEnd = 20, int count = 20)
    //{
    //    // 戻り値用
    //    int result = 0;

    //    // 指定された範囲の整数で埋めたリストを用意する
    //    List<int> noteRandom = Enumerable.Range(rengeBegin, rengeEnd - rengeBegin + 1).ToList();

    //    // リストからランダムに取り出して、順に返す（count回繰り返す）
    //    Random rnd = new Random();
    //    for(int i = 0; i < count; i++)
    //    {
    //        // リストからランダムに一つ取り出す
    //        int tmp = Random.Range(0,noteRandom.Count);
    //        result = noteRandom[tmp];
    //        // 取り出した値はリストから取り除く
    //        noteRandom.RemoveAt(tmp);
    //    }
    //    yield return result;
    //}


    //// 重複しない乱数
    //static IEnumerable<int> GetSimpleRandomAlgorithm(int rengeBegin = 0, int rengeEnd = 20, int count = 20)
    //{
    //    // 戻り値用
    //    int result = 0;

    //    // 指定された範囲の整数で埋めたリストを用意する
    //    List<int> noteRandom = Enumerable.Range(rengeBegin, rengeEnd - rengeBegin + 1).ToList();

    //    // リストからランダムに取り出して、順に返す（count回繰り返す）
    //    Random rnd = new Random();
    //    for (int i = 0; i < count; i++)
    //    {
    //        // リストからランダムに一つ取り出す
    //        int tmp = Random.Range(0, noteRandom.Count);
    //        result = noteRandom[tmp];
    //        // 取り出した値はリストから取り除く
    //        noteRandom.RemoveAt(tmp);
    //    }
    //    yield return result;
    //}


    ///// <summary>
    ///// 重複しない乱数
    ///// </summary>
    ///// <param name="rengeBegin"></param>
    ///// <param name="rengeEnd"></param>
    ///// <returns></returns>
    //public int GetRandom(int rengeBegin = 0, int rengeEnd = 20)
    //{
    //    // 戻り値用
    //    int result = 0;

    //    // 乱数を格納するリストを生成
    //    List<int> noteRandom = new List<int>();

    //    // 指定された範囲の整数で埋めたリストを作る
    //    for (int i = rengeBegin; i < rengeEnd; i++)
    //    {
    //        noteRandom.Add(i);
    //    }

    //    // ランダム生成用変数
    //    int rnd = 0;
    //    // 配列の最大値
    //    int arrayMax = rengeEnd;
    //    // 指定した回数分ループする
    //    for (int i = rengeBegin; i < rengeEnd; i++)
    //    {
    //        // ランダムを生成
    //        rnd = Random.Range(rengeBegin, arrayMax);
    //        result = noteRandom[rnd];
    //        // 取り出した値はリストから取り出す
    //        noteRandom.RemoveAt(rnd);
    //        // 配列の最大値を減らす（リストから取り除くと、配列の要素数が減るため）
    //        arrayMax--;
    //    }
    //    return result;
    //}

    ///// <summary>
    ///// 初期化
    ///// </summary>
    //public void Initialize()
    //{
    //    // 乱数で値を生成
    //    attractIndex = GetRandom(0, 20);
    //    awayIndex = GetRandom(0, 20);

    //    //// 曲データの設定
    //    //attract = attractMusic.attractMusics[tmp].musicClip;
    //    //away = awayMusic.awayMusics[tmp].musicClip;

    //    //// 曲名の設定
    //    //attractName = attractMusic.attractMusics[tmp].musicName;
    //    //awayName = awayMusic.awayMusics[tmp].musicName;

    //    //// 作曲者名の設定
    //    //attractComposer = attractMusic.attractMusics[tmp].composerName;
    //    //awayComposer = awayMusic.awayMusics[tmp].composerName;

    //    // コンポーネントを取得
    //    //music = gameObject.AddComponent<AudioSource>();

    //    // 音量の変更
    //    //music.volume = 0.2f;
    //    // ループを許可する
    //    //music.loop = true;
    //}

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
        soundData = soundManager.GetMusic(type);
    }

    /// <summary>
    /// 音符がクリックされた時の処理
    /// </summary>
    /// <param name="data">クリックイベント</param>
    public void ClickNotes(BaseEventData data)
    {
        charaManager.SetNotes(this.gameObject.GetComponent<Notes>());
        Debug.Log("くりっくされたぉ～。V（・~・）V");
        // 音を再生させる
        if(soundManager.ChangeMusic(type, soundData))
        {
            soundManager.PlayMusic();
        }
        else
        {
            soundManager.StopMusic();
        }
    }


    ///// <summary>
    ///// 曲の変更
    ///// </summary>
    ///// <param name="type">曲のタイプ</param>
    ///// <returns></returns>

    ////public bool ChangeSound(MusicType type)
    ////{
    ////    // 再生中の曲だったら
    ////    if (type == nowPlay)
    ////    {
    ////        return false;
    ////    }
    ////    else
    ////    {
    ////        // タイプの変更
    ////        nowPlay = type;
    ////        switch (nowPlay)
    ////        {
    ////            case MusicType.ATTRACT:
    ////                // 使う曲の設定
    ////                music.clip = attract;
    ////                break;
    ////            case MusicType.AWAY:
    ////                // 使う曲の設定
    ////                music.clip = away;
    ////                break;
    ////        }
    ////        return true;
    ////    }
    ////}


    //// 音量の変更
    //// 曲の再生
    //// 曲のループを許可


    ////public void SetMusic()
    ////{
    ////    // 乱数で値を取得
    ////    var rmp = GetRandom(0, 20);
    ////    // 使う曲の設定
    ////    attract.clip = attractMusic.attractMusics[rmp].musicClip;
    ////    // 乱数で値を取得
    ////    rmp = GetRandom(0, 20);
    ////    // 使う曲の設定
    ////    away.clip = awayMusic.awayMusics[rmp].musicClip;
    ////}

    ////    // 使う曲の設定
    ////    away.clip = awayMusic.awayMusics[rmp].musicClip;
    ////}


    ////public void InitNotes()
    ////{
    ////    // 生成
    ////    attract = gameObject.AddComponent<AudioSource>();
    ////    away = gameObject.AddComponent<AudioSource>();
    ////}

    ////// 近づける音を再生
    ////public void AttractSound()
    ////{

    ////    if (music.isPlaying)
    ////    {
    ////        if(ChangeSound(MusicType.ATTRACT))
    ////        {
    ////            // 音楽の再生
    ////            music.Play();
    ////        }
    ////        else
    ////        {
    ////            return;
    ////        }
    ////    }
    ////    else
    ////    {
    ////        ChangeSound(MusicType.ATTRACT);
    ////        // 音楽の再生
    ////        music.Play();
    ////    }
    ////}


    ///// <summary>
    ///// 近づける音を再生
    ///// </summary>
    ////public void AttractSound()
    ////{
    ////    // 曲が再生中だったら
    ////    if (music.isPlaying)
    ////    {
    ////        // 曲の種類が近づける音だったら
    ////        if (ChangeSound(MusicType.ATTRACT))
    ////        {
    ////            // 音楽の再生
    ////            music.Play();
    ////        }
    ////        // そうでなかったら
    ////        else
    ////        {
    ////            // 音楽の停止
    ////            music.Stop();
    ////        }
    ////    }
    ////    // 曲が再生されてなかったら
    ////    else
    ////    {
    ////        // 曲の種類を近づける音にして
    ////        ChangeSound(MusicType.ATTRACT);
    ////        // 音楽の再生
    ////        music.Play();
    ////    }
    ////}


    ////// 遠ざける音を再生
    ////public void AwaySound()
    ////{
    ////    if (music.isPlaying)
    ////    {
    ////        if (ChangeSound(MusicType.AWAY))
    ////        {
    ////            // 音楽の再生
    ////            music.Play();
    ////        }
    ////        else
    ////        {
    ////            return;
    ////        }
    ////    }
    ////    else
    ////    {
    ////        ChangeSound(MusicType.AWAY);
    ////        // 音楽の再生
    ////        music.Play();
    ////    }
    ////}

    ///// <summary>
    ///// 遠ざける音を再生
    ///// </summary>
    ////public void AwaySound()
    ////{
    ////    // 曲が再生中だったら
    ////    if (music.isPlaying)
    ////    {
    ////        // 曲の種類が遠ざける音だったら
    ////        if (ChangeSound(MusicType.AWAY))
    ////        {
    ////            // 音楽の再生
    ////            music.Play();
    ////        }
    ////        // そうでなかったら
    ////        else
    ////        {
    ////            // 音楽の停止
    ////            music.Stop();
    ////        }
    ////    }
    ////    // 曲が再生されてなかったら
    ////    else
    ////    {
    ////        // 曲の種類を遠ざける音にして
    ////        ChangeSound(MusicType.AWAY);
    ////        // 音楽の再生
    ////        music.Play();
    ////    }
    ////}


    ////public void AttractSound()
    ////{
    ////    // 乱数で値を取得
    ////    var rmp = GetRandom(0, 20);
    ////    // 使う曲の設定
    ////    attract.clip = attractMusic.attractMusics[rmp].musicClip;
    ////    // 音量の変更
    ////    attract.volume = 0.2f;
    ////    // 音楽の再生
    ////    attract.Play();
    ////    // ループを許可する
    ////    attract.loop = true;
    ////}
    ////public void AwaySound()
    ////{
    ////    // 乱数で値を取得
    ////    var rmp = GetRandom(0, 20);
    ////    // 使う曲の設定
    ////    away.clip = awayMusic.awayMusics[rmp].musicClip;
    ////    // 音量の変更
    ////    away.volume = 0.2f;
    ////    // 音楽の再生
    ////    away.Play();
    ////    // ループを許可する
    ////    away.loop = true;
    ////}



    ///// <summary>
    ///// 乱数で数値を設定
    ///// </summary>
    //public void SetIndex()
    //{
    //    // 乱数で値を生成
    //    attractIndex = GetRandom(0, 20);
    //    awayIndex = GetRandom(0, 20);
    //}

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
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update ()
    {
        //if(Input.GetKeyDown(KeyCode.B))
        //{
        //    AttractSound();
        //}
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    AwaySound();
        //}
    }
}
