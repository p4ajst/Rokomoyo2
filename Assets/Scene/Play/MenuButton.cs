using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {


    //Image images;
    private RectTransform images_rect;
    private GameObject Retrun_Button;
    private GameObject How_to_Play_Button;
    private GameObject Retrun_Title_Button;
    private float x, y;
    private bool OnOff;
	// Use this for initialization
	void Start () {
        //images = GetComponent<Image>();
        images_rect = GameObject.Find("Image").GetComponent<RectTransform>();
        Retrun_Button = GameObject.Find("Restart_Button");
        How_to_Play_Button = GameObject.Find("How_to_Play_Button");
        Retrun_Title_Button = GameObject.Find("Retrun_Title_Button");
        if (images_rect == null)
        {
            print("Imageが見つかりません");
        }
        //全部見えなくする
        //Retrun_Button.SetActive(false);
        GameObject.Find("Restart_Button").gameObject.SetActive(false);
        GameObject.Find("How_to_Play_Button").gameObject.SetActive(false);
        GameObject.Find("Retrun_Title_Button").gameObject.SetActive(false);

        OnOff = false;
    }

   
    // Update is called once per frame
    void Update ()
    {
        ImageReSize();

    }
    public  void onClick()
    {
        
        if (OnOff == false)
        {
            OnOff = true;
            //ボタン召喚
            //Retrun_Button.SetActive(true);
            //How_to_Play_Button.SetActive(true);
            //Retrun_Title_Button.SetActive(true);
            ButtonOutput();
            return;
        }
        if (OnOff == true)
        {
            OnOff = false;
            //ボタン帰還
            //Retrun_Button.SetActive(false);
            //How_to_Play_Button.SetActive(false);
            //Retrun_Title_Button.SetActive(false);
            ButtonOutput();
            return;
        }
       
    }

    void ImageReSize()
    {
        if (OnOff == false)
        {
            images_rect.sizeDelta = new Vector2(10000,0);
            //print("縮小");
        }
        if (OnOff == true)
        {
            images_rect.sizeDelta = new Vector2(10000, 10000);
            //print("拡大");
        }
    }
    void ButtonOutput()
    {
        if (OnOff == false)
        {
            
            //ボタン召喚
            Retrun_Button.SetActive(false);
            How_to_Play_Button.SetActive(false);
            Retrun_Title_Button.SetActive(false);
            return;
        }
        if (OnOff == true)
        {
            
            //ボタン帰還
            Retrun_Button.SetActive(true);
            How_to_Play_Button.SetActive(true);
            Retrun_Title_Button.SetActive(true);
            return;
        }
    }

}
