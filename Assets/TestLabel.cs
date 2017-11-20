using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLabel : MonoBehaviour
{

    string str = "あいうえおかきくけこ";
    private void OnGUI()
    {
        // ラベルを表示
        GUI.Label(new Rect(100, 625, 200, 100), str);
        // ラベルを表示
        GUI.Label(new Rect(500, 625, 200, 100), str);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
