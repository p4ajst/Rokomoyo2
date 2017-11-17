using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Trap {

    public bool flag = false;

    // Use this for initialization
    override protected void Start () {
        base.Start();
	}

    // Update is called once per frame
    override protected void Update () {
        base.Update();
        if (OnFloor())
            gameObject.SetActive(false);

        gameObject.transform.Rotate(new Vector3(0, -1, 0));
    }
}
