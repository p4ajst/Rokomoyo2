using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー（仮）を強制的に動かせるデバッグ用スクリプト
//プレイヤーの電力追加
//プレイヤーの状態（移動、待機）追加

public class test : MonoBehaviour {

    public float battery = 100;
    public int status;

    public enum State
    {
        WALK,
        WAIT,
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //矢印キーで動かす
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position += new Vector3(0, 0, 0.1f);
            status = (int)State.WALK;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position += new Vector3(0, 0, -0.1f);
            status = (int)State.WALK;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
            status = (int)State.WALK;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);
            status = (int)State.WALK;
        }
        else
            status = (int)State.WAIT;

        //バッテリーを１秒に１減らす
        battery -= 1.0f / 60.0f;
    }
}
