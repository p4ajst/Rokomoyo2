using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClicker : MonoBehaviour
{

    bool flag = false;
    public void ClickObject(BaseEventData data)
    {
        var eventData = (PointerEventData)data;
        // クリックされた処理
        Debug.Log(gameObject.name);
        flag = !flag;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(flag);
	}
}
