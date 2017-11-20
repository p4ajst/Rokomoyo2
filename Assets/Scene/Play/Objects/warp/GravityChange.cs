using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour {


    public GameObject[] warpParticle;        //パーティクル
    public Transform[] warpPoints;         // 地点
    public ParticleSystem warp;
    // Use this for initialization
    void Start () {
       // warp.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (Transform explosionPos in warpPoints)
            {
                GameObject warp = Instantiate(warpParticle[0],               // パーティクルオブジェクトの生成
                explosionPos.position, transform.rotation) as GameObject;
                Destroy(warp, 2f);
            }
        }
    }
}
