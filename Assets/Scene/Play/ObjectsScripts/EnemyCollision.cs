using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : Trap {

    GameObject start;
    GameObject microUSB;
    int objCount = 0;

	// Use this for initialization
	override protected void Start () {
        base.Start();
        //スタートオブジェクトを取得する
        start = GameObject.Find("Start");
        //microUSBオブジェクトを取得する
        microUSB = GameObject.Find("microUSB/microUSB");
        //即死トラップを数える
        objCount = GameObject.Find("DeathTraps").transform.childCount;
    }
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();

        //トラップの上にいるなら
        if (base.OnFloor() == true)
        {
            //microUSBのフラグをfalseにする
            if (microUSB != null)
                microUSB.GetComponent<microUSB>().SetFlag(false);
            //プレイヤーの座標をスタートの座標にする
            player.transform.position = start.transform.position;

            //鍵をアクティブにする
            GameObject.Find("Key").transform.Find("Key").gameObject.SetActive(true);

            if(objCount!=0)
            {
                Debug.Log("即死トラップの数は" + objCount);
                for (int i = 0; i < objCount; i++)
                {
                    if (i == 0)
                        GameObject.Find("DeathTraps").transform.Find("DeathTrap").gameObject.SetActive(true);
                    else
                        GameObject.Find("DeathTraps").transform.Find("DeathTrap (" + i + ")").gameObject.SetActive(true);
                }
            }
        }
    }
}
