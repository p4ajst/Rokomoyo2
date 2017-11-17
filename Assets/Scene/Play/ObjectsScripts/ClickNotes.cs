using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickNotes : MonoBehaviour
{
    public void OnObjectPointClick(BaseEventData data)
    {
        //クリックされたらの処理
        Debug.Log(gameObject.name);
        
    }


    private void Awake()
    {
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
