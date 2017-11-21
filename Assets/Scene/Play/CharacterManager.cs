using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    // 音マネージャーのインスタンス
    public SoundManager sound = null;

    // 音符のインスタンス
    //public int noteNum = 0;
    private Notes note = null;

    //public List<Notes> notes = new List<Notes>();

    // ロボのインスタンス
    //public chara roomba = new chara();
    public chara roomba = null;
    GameObject player = null;

    public void SetNotes(Notes notes)
    {
        note = notes;
    }

    // キャラクターの移動
    public void MoveCharacter()
    {
        Debug.Log("movecharacter動いてます");
        // キャラクターを探す
        //player = GameObject.Find("Player");

        player = GameObject.Find("Player");


        //// typeで指定した型の全てのオブジェクトを配列で取得し,その要素数分繰り返す.
        //foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        //{
        //    // シーン上に存在するオブジェクトならば処理.
        //    if (obj.activeInHierarchy)
        //    {
        //        // GameObjectの名前を表示.
        //        Debug.Log(obj.name);
        //    }
        //}

        //if (sound == null)
        //{
        //    Debug.Log("マネージャーいないですぅ。");
        //    return;
        //}

        // シーンからサウンドマネージャーを探す
        GameObject obj = GameObject.Find("SoundManager");
        sound = obj.GetComponent<SoundManager>();

        //if (note == null)
        //{
        //    Debug.Log("音符ないです。");
        //    return;
        //}

        
        //for(int i = 0;i< noteNum;i++)
        //{
        //    //note = note.GetComponent<Notes>();
        //}
        roomba = player.GetComponent<chara>();
        //if (roomba == null)
        //{
        //    Debug.Log("ロボいないです。");
        //    //return;
        //}

        // 音が鳴っているか
        if (!sound.music.isPlaying)
        {
            roomba.MoveEnd();
            Debug.Log("回ってる");
            return;
        }
       
       // 鳴っている音の場所がキャラクターの同一直線上にあるか
       if (roomba.transform.position.x == note.transform.position.x || roomba.transform.position.z == note.transform.position.z)
       {
           // 音の判別
           if (note.type == Notes.MusicType.ATTRACT)
           {
               roomba.AttactMove(note.transform.position);
           }
           if (note.type == Notes.MusicType.AWAY)
           {
               roomba.AwayMove(note.transform.position);
           }
       }
       else
       {
           roomba.MoveEnd();
           Debug.Log("回ってる");
       }
    }



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
        MoveCharacter();
    }
}
