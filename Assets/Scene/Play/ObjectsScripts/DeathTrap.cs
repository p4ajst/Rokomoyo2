using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//即死トラップのスクリプト

public class DeathTrap : Trap {

    //（空の）スタートオブジェクトを取得するためのGameObject型の変数
    GameObject start;
    GameObject microUSB;

    // Use this for initialization
    override protected void Start () {
        //基底クラスのStart関数
        base.Start();

        //スタートオブジェクトを取得する
        start = GameObject.Find("Start");
        microUSB = GameObject.Find("microUSB");
    }

    // Update is called once per frame
    override protected void Update()
    {
        //基底クラスのUpdate関数
        base.Update();

        //トラップの上にいるなら
        if (base.OnFloor() == true)
        {
            //プレイヤーの座標をスタートの座標にする
            player.transform.position = start.transform.position;

            //鍵をアクティブにする
            GameObject.Find("Key").transform.Find("Key").gameObject.SetActive(true);
        }

        //マイクロUSBを確認しフラグが立っているのなら
        if (microUSB.GetComponent<microUSB>() != null)
        {
            if (microUSB.GetComponent<microUSB>().GetFlag())
            {
                //オブジェクトを消す
                gameObject.SetActive(false);
            }
        }
    }
}
