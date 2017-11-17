using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour {

    //プレイヤーの座標を保存する（ｘ、ｙのみ）
    protected float pos_x;
    protected float pos_z;

    //プレイヤーオブジェクトを取得するためのGameObject型の変数
    protected GameObject player;

    // Use this for initialization
    virtual protected void Start()
    {

    }

    //プレイヤーが同じ座標にいるかチェックする
    public bool OnFloor()
    {
        //プレイヤーオブジェクトを取得する
        player = GameObject.Find("Player");

        //プレイヤーの座標を取得する
        pos_x = player.transform.position.x;
        pos_z = player.transform.position.z;

        //当たり判定を取る
        if (gameObject.transform.position.x - 0.25 < pos_x + 0.25 &&
            gameObject.transform.position.x + 0.25 > pos_x - 0.25 &&
            gameObject.transform.position.z - 0.25 < pos_z + 0.25 &&
            gameObject.transform.position.z + 0.25 > pos_z - 0.25 &&
            player.GetComponent<chara>().a == 1)
        {
            //当たっていたらtrueを返す
            return true;
        }
        //当たっていなかったらfalseを返す
        return false;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        //座標チェックを毎フレーム行う
        OnFloor();
    }
}
