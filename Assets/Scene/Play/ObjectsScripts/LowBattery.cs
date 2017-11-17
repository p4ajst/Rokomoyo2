using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//充電減のスクリプト

public class LowBattery : Trap {

    //一度だけ使わせるようにフラグ管理
    bool used;

    // Use this for initialization
    override protected void Start () {
        //基底クラスのStart関数
        base.Start();
	}

    // Update is called once per frame
    override protected void Update () {
        //基底クラスのUpdate関数
        base.Update();

        //トラップの上にいるなら
        if (base.OnFloor() == true && used == false)
        {
            //Debug.Log("当たっています");

            //プレイヤーの充電を一度だけ減らす
            player.GetComponent<chara>().Charge -= 0.1f;

            //減らしたらトラップを使ったというフラグを立てる
            used = true;
        }
        //トラップから抜けたら
        else if (base.OnFloor() == false)
        {
            //Debug.Log("当たっていません");

            //当たっていない状態にする
            used = false;
        }
    }
}
