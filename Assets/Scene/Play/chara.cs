using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chara : MonoBehaviour {

   //電池残量
    public　float Charge;
    //移動速度
    float MoveSpeed;
    //回転速度
    float RoteSpeed;
    //移動する長さ
    float MoveLengs;
    //移動する時間
    float DeltaTime;
    //charaの状態（０動いている　１待機中）
    public int a ;
    int times;
    bool round;
   // Vector3 PlayerPos;
    //GameObject Eplan;
    enum status:int
    {
        
        moveing,
        waiting
    }
    status stauts;

    // Use this for initialization
    void Start () {
        Charge = 100.0f;

        MoveSpeed = 0.5f;
        RoteSpeed = 3.0f;
        
        //PlayerPos = this.gameObject.transform.position;
        a = 1;
        times = 1;
        round = true;
        DeltaTime = 0;
        
    }
	
	// Update is called once per frame
	void Update () {
       //状態の変化
      switch(a)
        {
            //動いているときの行動　常に動いている処理がないので処理がない
            case (int)status.moveing:
                break;
            //動いてないときの行動　移動修正のAmendedMove()待機モーションを実行するwaitrotate();
            case (int)status.waiting:
                //移動修正
                AmendedMove();
                //待機モーションの切り替え４秒ごとに90°角度回転する
                DeltaTime =DeltaTime+Time.deltaTime;
                if (DeltaTime >= 4)
                {
                    if(round==true)
                    {
                        round = false;
                    }else if(round==false)
                    {
                        round = true;
                        times++;
                        if(times>=4)
                        {
                            times = 0;
                        }
                    }

                    DeltaTime = 0;
                }
                //roundがtrueなら待機モーションの実行
                if (round == true)
                {
                    waitrotate();
                   
                }
                else if(round==false)
                {
                    
                }
                
                break;
                

        }


    }
    //近づく音が聞こえているとき
   public void AttactMove(Vector3 MusicCordinate)
    {
        //移動状態への移行
        a = 0;

        Vector3 tage_pos = new Vector3(MusicCordinate.x, this.gameObject.transform.position.y, MusicCordinate.z);

        //移動時間の計算
        float MoveTime = Time.deltaTime / MoveSpeed;
        //離れる移動の処理
        MoveLengs = Vector3.Distance(this.gameObject.transform.position, tage_pos);
        float time = MoveTime / MoveLengs;
        this.transform.position = Vector3.Lerp(this.gameObject.transform.position, tage_pos, time);
        //進む方向へ向く処理
        Vector3 view_vec = new Vector3(MusicCordinate.x,this.gameObject.transform.position.y,MusicCordinate.z) - this.gameObject.transform.position;
        Quaternion newRote = Quaternion.LookRotation(view_vec);
        this.gameObject.transform.rotation = Quaternion.Slerp(this.transform.rotation,newRote,0.2f);
       
        }
   //離れる音が聞こえているときの処理
   public void AwayMove(Vector3 MusicCordinate)
    {
        //移動状態へ移行
        a = 0;
        float MoveTime = Time.deltaTime/ MoveSpeed;
        //右へ離れる時の目標座標
        Vector3 rAway = new Vector3(3, this.transform.position.y, this.transform.position.z);
        //左へ離れる時の目標座標
        Vector3 lAway = new Vector3(-3, this.transform.position.y, this.transform.position.z);
        //前へ離れる時の目標座標
        Vector3 fAway = new Vector3( this.transform.position.x, this.transform.position.y,3);
        //後へ離れる時の目標座標
        Vector3 bAway = new Vector3(this.transform.position.x, this.transform.position.y, -3);
        //座標が離れる音と被っているかどうか
        //被っている場合
        if (MusicCordinate.x==this.transform.position.x&& MusicCordinate.z == this.transform.position.z)
        {
            Quaternion angle = this.transform.rotation;
            float rote = angle.eulerAngles.y;
            if(rote <= 2 && rote >= -2)
            {
                //離れる移動の処理
                MoveLengs = Vector3.Distance(this.transform.position, fAway);
                float time = MoveTime / MoveLengs;
                this.transform.position = Vector3.Lerp(this.transform.position, fAway, time);
                
            }
            else if(rote <= 92 && rote >= 88)
            {
                //離れる移動の処理
                MoveLengs = Vector3.Distance(this.transform.position, rAway);
                float time = MoveTime / MoveLengs;
                this.transform.position = Vector3.Lerp(this.transform.position, rAway, time);
                
            }
            else if (rote <= 182&&rote >= 178)
            {
                //離れる移動の処理
                MoveLengs = Vector3.Distance(this.transform.position, bAway);
                float time = MoveTime / MoveLengs;
                this.transform.position = Vector3.Lerp(this.transform.position, bAway, time);
                
            }
            else if(rote <= 272 && rote >= 268)
            {
                //離れる移動の処理
                MoveLengs = Vector3.Distance(this.transform.position, lAway);
                float time = MoveTime / MoveLengs;
                this.transform.position = Vector3.Lerp(this.transform.position, lAway, time);
                
            }

           

        }
        else
        {
            //被っていないとき
            //離れる音が前にある場合
            if(MusicCordinate.x==this.transform.position.x&&MusicCordinate.z>this.transform.position.z)
            {

                //離れる移動の処理
                MoveLengs = Vector3.Distance(this.transform.position,bAway );
                float time = MoveTime / MoveLengs;
                this.transform.position = Vector3.Lerp(this.transform.position, bAway, time);
                //進む方向へ向く処理
                Vector3 view_vec = bAway - this.gameObject.transform.position;
                Quaternion newRote = Quaternion.LookRotation(view_vec);
                this.gameObject.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRote, 0.2f);
                

            }//離れる音が奥にある場合
            else if (MusicCordinate.x == this.transform.position.x && MusicCordinate.z < this.transform.position.z)
            {
                //離れる移動の処理
                MoveLengs = Vector3.Distance(this.transform.position, fAway);
                float time = MoveTime / MoveLengs;
                this.transform.position = Vector3.Lerp(this.transform.position, fAway, time);
                //進む方向へ向く処理
                Vector3 view_vec = fAway - this.gameObject.transform.position;
                Quaternion newRote = Quaternion.LookRotation(view_vec);
                this.gameObject.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRote, 0.2f);
               

            }//離れる音が右にある場合
            else if (MusicCordinate.x > this.transform.position.x && MusicCordinate.z == this.transform.position.z)
            {

                //離れる移動の処理
                MoveLengs = Vector3.Distance(this.transform.position, lAway);
                float time = MoveTime / MoveLengs;
                this.transform.position = Vector3.Lerp(this.transform.position, lAway, time);
                //進む方向へ向く処理
                Vector3 view_vec = lAway - this.gameObject.transform.position;
                Quaternion newRote = Quaternion.LookRotation(view_vec);
                this.gameObject.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRote, 0.2f);
                

            }//離れる音が左にある場合
            else if (MusicCordinate.x < this.transform.position.x && MusicCordinate.z == this.transform.position.z)
            {

                //離れる移動の処理
                MoveLengs = Vector3.Distance(this.transform.position, rAway);
                float time = MoveTime / MoveLengs;
                this.transform.position = Vector3.Lerp(this.transform.position, rAway, time);
                //進む方向へ向く処理
                Vector3 view_vec = rAway - this.gameObject.transform.position;
                Quaternion newRote = Quaternion.LookRotation(view_vec);
                this.gameObject.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRote, 0.2f);
                

            }
        }
       
    }

   
    //移動の修正
    void AmendedMove()
    {
        float p_posx;
        //float p_posy;
        float p_posz;
        //x.y.zの各座標の四捨五入
        p_posx = Mathf.RoundToInt(this.gameObject.transform.position.x);
        //p_posy = Mathf.RoundToInt(this.gameObject.transform.position.y);
        p_posz = Mathf.RoundToInt(this.gameObject.transform.position.z);
        //修正のための座標
        Vector3 domove = new Vector3(p_posx, this.gameObject.transform.position.y, p_posz);
        //修正座標への移動
        float MoveTime = Time.deltaTime / MoveSpeed;
        MoveLengs = Vector3.Distance(this.transform.position, domove);
        float time = MoveTime / MoveLengs;
        this.transform.position = Vector3.Lerp(this.transform.position, domove, time);

    }
    //charaの状況の変化
    public void MoveEnd()
    {
        a = 1;
    }
    //待機モーション
    void waitrotate()
    {
       
       
            //呼ばれた回数（timesの数0～3）＊９０°回転する
            Quaternion newangle = Quaternion.Euler(0, times*90, 0);
            this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, newangle, Time.deltaTime*RoteSpeed);
       
       
    }
    //電気の消費処理
    public void ElectricityConsumption()
    {
        Charge = -0.0001f;
    }
}
