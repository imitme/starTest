using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColliderAdditiveCode : MonoBehaviour {


    /* 20180913_
     * 입력된 버튼의 색을 매니저에게 보내서
     * 매니저에게 색 섞어달라고 하기!?
     */
    


    public Color additiveCode;
    public GameObject additiveScreen;

    private void Start()
    {
        OffAdditiveScreen();
    }
    void OffAdditiveScreen()
    {
        additiveScreen.SetActive(false);
    }

    


    public void OnMixAdditiveCode()
    {
        //색 보내고
        SetAdditiveCode();
        //스크린 보내고
        SetAdditiveScreen();
    }

    // 메니저에게 색 보내기
    public void SetAdditiveCode()
    {
        Debug.Log(additiveCode + "색 보냄.");
        ManagerStar.instance.GetAdditiveCode(additiveCode);
    }

    //메니저에게 스크린 보내기
    void SetAdditiveScreen()
    {
        Debug.Log(additiveScreen + "스크린 보냄.");
        ManagerStar.instance.GetAdditiveScreen(additiveScreen);
    }

    
    
}
