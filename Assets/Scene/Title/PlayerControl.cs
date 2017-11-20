using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


    public  GameObject player;
    public GameObject note1;
    public GameObject note2;

    //0待機1右2左
    int flag =0;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (flag == 1)
        {
            if (player.transform.position.x >= note1.transform.position.x-20)
            {
                flag = 0;
            }
            // xの正方向にscrollスピードで移動
            player.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
        }
        if (flag == 2)
        {
            if (player.transform.position.x <= note2.transform.position.x + 20)
            {
                flag = 0;
            }
            // xの正方向にscrollスピードで移動
            player.transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
        }
    }

    public void onClick1()
    {
        flag = 1;
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public void onClick2()
    {
      
        flag = 2;
        player.transform.rotation = new Quaternion(0, 180, 0, 0);

    }
}
