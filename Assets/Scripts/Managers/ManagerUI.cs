using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerUI : MonoBehaviour {

    public static ManagerUI instance { get; private set; }

    public bool CheckOnOff;
    public GameObject[] Screens;
    public GameObject[] buttons;
    

    private void Awake()    { instance = this; }
    void Start()
    {
        SetOffUICheck();
        HideAllUI();
        HideAllScreens();
    }

    /* UI 켜고 & 색 백업 하고 & 입력기 숨기기*/
    public void OOUIPick()
    {
        ShowAllUI();
        BackUpCodes();
        HideAllEnterCode();
    }

    //코드 백업!
    void BackUpCodes()
    {
        Debug.Log("매니저에게 백업기능 호출");
        ManagerStar.instance.ProtectedEnteredCode();
    }

    //(세팅) 스크린 끄기
    void HideAllScreens()
    {
        for (int i = 0; i < Screens.Length; i++)
        {
            Screens[i].SetActive(false);
        }
    }
    //코드입력기 다 끄기
    void HideAllEnterCode()  {  ManagerStar.instance.HideAll();  }

    //UI off상태 설정 & 버튼 숨기기 //
    public void HideAllUI()
    {
        SetOffUICheck();
        HideButtons();
    }

    //UI on상태 설정 & 버튼 보이기 //
    void ShowAllUI()
    {
        SetOnUICheck();
        ShowButtons();
    }
    
    //UI _끄기 설정
    void SetOffUICheck()   {   CheckOnOff = false;  }
    //UI _켜기 설정
    void SetOnUICheck()    {   CheckOnOff = true;   }


    //버튼 켜고 끄기
    void HideButtons()     // 버튼 다 지우기
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }
    void ShowButtons()      // 버튼 다 켜기
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    

}
