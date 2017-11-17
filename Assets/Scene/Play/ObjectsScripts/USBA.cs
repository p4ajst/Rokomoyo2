using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBA : Gimmick {

    //踏んでいるかのフラグ
    bool usedFlagA = false;

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();

        //オブジェクトの上に行ったら
        if (base.OnFloor() == true && usedFlagA == false)
        {
            //フラグを立てる
            usedFlagA = true;
        }
        //その場にいなかったら
        else if (base.OnFloor() == false)
            //フラグを消す
            usedFlagA = false;
	}

    //フラグ確認用の関数
    public bool GetFlagA()
    {
        return usedFlagA;
    }
}
