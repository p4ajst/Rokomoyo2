using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StereoPlug : Gimmick {

	// Use this for initialization
	void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
        base.Update();

        //ギミックの上にいるなら
        if (base.OnFloor() == true)
        {
            //音符の種類を変える処理

        }
        //トラップから抜けたら
        else if (base.OnFloor() == false)
        {
            //Debug.Log("当たっていません");
        }
    }
}
