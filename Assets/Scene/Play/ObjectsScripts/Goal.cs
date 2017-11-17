using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//即死トラップのスクリプト

public class Goal : Trap {

    GameObject key;
    bool goalflag = false;
    static int x = 2;
    GameObject sound;

	// Use this for initialization
	override protected void Start () {
        //基底クラスのStart関数
        base.Start();
        key = GameObject.Find("Key");
    }

    // Update is called once per frame
    override protected void Update()
    {
        //基底クラスのUpdate関数
        base.Update();

        //トラップの上にいるなら
        if (base.OnFloor() == true)
        {
            //シーン遷移する
            if (key.active == false)
            {
                //ゴールした瞬間にリープモーションでゴールへ動く
                float MoveTime = Time.deltaTime / 0.5f*2;
                float Length = Vector3.Distance(player.transform.position,new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z));
                float time = MoveTime / Length;
                player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z),time);

                //プレイヤーとゴールの位置が噛み合ったらシーン遷移
                if (player.transform.position == new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z))
                    Stage.ChangeStage();
            }
        }
        //いないなら
        else { }
    }
}
