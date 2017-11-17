using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patolian : MonoBehaviour {


    //移動速度
    float MoveSpeed;
    //回転速度
    float RoteSpeed;
    //移動する長さ
    float MoveLengs;
    //移動する時間
    float DeltaTime;
    //待機時間の設定
    public int waitTime=7;
    //charaを知る
    //[SerializeField]
    //chara roomba;
    //移動先のポジション設定4
    public Vector3 roboStartPos;
    //移動先のポジション設定1
    public Vector3 move_point1;
    //移動先のポジション設定2
    public Vector3 move_point2;
    //移動先のポジション設定3
    public Vector3 move_point3;
    //移動先のポジション設定4
    public Vector3 move_point4;
    //移動の仕方(ture:往復 false:4点)
    public bool move_type;
    //往復用の行動変化
    int runs;
    //回転するためのフラグ
    bool Roteflage;
    //新しい回転角
    Vector3 newRoteVec;
    // Use this for initialization
    void Start () {
        //roomba = GetComponent<chara>();
        MoveSpeed = 1.0f;
        RoteSpeed = 0.2f;
        newRoteVec = new Vector3();
        Roteflage = true;

        runs = 1;
	}
	
	// Update is called once per frame
	void Update () {
        patrianMove();
	}

    private void one_to_one_Move(Vector3 Moveing_pos)
    {
        Vector3 tage_pos = new Vector3(Moveing_pos.x, this.gameObject.transform.position.y, Moveing_pos.z);

        //移動時間の計算
        float MoveTime = Time.deltaTime / MoveSpeed;
        //離れる移動の処理
        MoveLengs = Vector3.Distance(this.gameObject.transform.position, tage_pos);
        float time = MoveTime / MoveLengs;
        this.transform.position = Vector3.Lerp(this.gameObject.transform.position, tage_pos, time);
        
    }
    private void patrianRote(Vector3 Moveing_pos)
    {
       if(Roteflage==true)
        {
            //目標が前
            if (Moveing_pos.x == this.transform.position.x && Moveing_pos.z > this.transform.position.z)
            {
                newRoteVec = new Vector3(0,0,1);
            }//目標が奥
            else if (Moveing_pos.x == this.transform.position.x && Moveing_pos.z < this.transform.position.z)
            {
                newRoteVec = new Vector3(0, 0, -1);
            }//目標が右
            else if (Moveing_pos.x > this.transform.position.x && Moveing_pos.z == this.transform.position.z)
            {
                newRoteVec = new Vector3(1, 0, 0);
            }//目標が左
            else if (Moveing_pos.x < this.transform.position.x && Moveing_pos.z == this.transform.position.z)
            {
                newRoteVec = new Vector3(-1, 0, 0);
            }
            Roteflage = false;
        }
        Vector3 view_vec = newRoteVec;
        Quaternion newRote = Quaternion.LookRotation(view_vec);
        this.gameObject.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRote, 0.2f);

    }

    void patrianMove()
    {
        switch(move_type)
        {
            case true:
                DeltaTime = DeltaTime + Time.deltaTime;
                if (DeltaTime >= waitTime)
                {
                   if(runs==1)
                    {
                        runs++ ;
                        Roteflage = true;
                    }
                   else if(runs==2)
                    {
                        runs ++;
                        Roteflage = true;
                    }
                    DeltaTime = 0;
                }
                if (runs==1)
                {
                    one_to_one_Move(move_point1);
                    patrianRote(move_point1);

                }
                else if (runs == 2)
                {
                    one_to_one_Move(move_point2);
                    patrianRote(move_point2);
                }

                if(runs>=3)
                {
                    runs = 1;
                }

                break;
            case false:
                DeltaTime = DeltaTime + Time.deltaTime;
                if (DeltaTime >= waitTime)
                {
                    if (runs == 1)
                    {
                        runs++;
                        Roteflage = true;
                    }
                    else if (runs == 2)
                    {
                        runs++;
                        Roteflage = true;
                    }
                    else if (runs == 3)
                    {
                        runs++;
                        Roteflage = true;
                    }
                    else if (runs == 4)
                    {
                        runs++;
                        Roteflage = true;
                    }
                    DeltaTime = 0;
                }

                if (runs == 1)
                {
                    one_to_one_Move(move_point1);
                    patrianRote(move_point1);
                }
                else if (runs == 2)
                {
                    one_to_one_Move(move_point2);
                    patrianRote(move_point2);
                }
                else if (runs == 3)
                {
                    one_to_one_Move(move_point3);
                    patrianRote(move_point3);
                }
                else if (runs == 4)
                {
                    one_to_one_Move(move_point4);
                    patrianRote(move_point4);
                }

                if (runs >= 5)
                {
                    runs = 1;
                }
                break;
        }
       
    }

    void roombaHit()
    {

    }


    void charaGet()
    {
        //roomba.transform.position = roboStartPos;
    }

}
