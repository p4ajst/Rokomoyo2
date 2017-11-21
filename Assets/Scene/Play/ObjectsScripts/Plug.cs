using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : Gimmick {

    // Use this for initialization
    override protected void Start () {
        base.Start();
	}

    // Update is called once per frame
    override protected void Update () {
        base.Update();

        //ギミックの上にいるなら
        if (base.OnFloor() == true)
        {
            //Debug.Log("当たっています");

            //プレイヤーの充電を回復する
            //player.GetComponent<test>().battery += 1.0f / 30.0f;
            player.GetComponent<chara>().Charge += 0.01f / 30.0f;
        }
        //トラップから抜けたら
        else if (base.OnFloor() == false)
        {
            //Debug.Log("当たっていません");
        }
    }
}
