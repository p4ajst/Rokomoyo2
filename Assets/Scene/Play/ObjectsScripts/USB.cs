using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USB : Gimmick {

    ////USBの関数を取る
    GameObject usbA;
    GameObject usbB;
    //USBの位置を取る
    GameObject usbA_pos;
    GameObject usbB_pos;

    //多重に移動しないようにするフラグ
    bool flag = false;

    // Use this for initialization
    void Start () {
        base.Start();
        usbA = GameObject.Find("USB/USB");
        usbB = GameObject.Find("USB/USB (1)");

        usbA_pos = GameObject.Find("USB/USB");
        usbB_pos = GameObject.Find("USB/USB (1)");
    }
	
	// Update is called once per frame
	void Update () {

        base.Update();

        //USBAに行った場合
        if (usbA.GetComponent<USBA>().GetFlagA() && !flag)
        {
            //移動したことを示す
            flag = true;

            //プレイヤーを移動させる
            player.GetComponent<chara>().transform.position = new Vector3(usbB_pos.GetComponent<USBB>().transform.position.x, 0.6f, usbB_pos.GetComponent<USBB>().transform.position.z);
        }
        //USBBに行った場合
        if (usbB.GetComponent<USBB>().GetFlagB() && !flag)
        {
            //移動したことを示す
            flag = true;
            //プレイヤーを移動させる
            player.GetComponent<chara>().transform.position = new Vector3(usbA_pos.GetComponent<USBA>().transform.position.x, 0.6f, usbA_pos.GetComponent<USBA>().transform.position.z);
        }

        //どちらも踏んでない状態になったら
        if (!usbA.GetComponent<USBA>().GetFlagA() && !usbB.GetComponent<USBB>().GetFlagB())
            //多重移動のフラグを消す
            flag = false;
    }
}
