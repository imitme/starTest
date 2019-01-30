using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScreen : MonoBehaviour {

    
     /// <summary>
     /// -스크린 꺼지고(0)
     /// -모든 색 원상태로 돌아가기(0)
     /// -레이블 띄우고
     /// -정답효과도 지우고
     /// </summary>

    // 스크린 숨기기 & 색 리셋 // 
    public void ASPick()
    {
        HideScreen();
        ResetCodes();
    }
    
    //매니저에게 가져놨던 스크린 꺼달라고 하기
    void HideScreen()   {  ManagerStar.instance.HideScreen();  }
    //매니저에게 백업해둔 색으로 되돌려 달라고 하기
    void ResetCodes()   {  ManagerStar.instance.ResetMixAdditiveCodeAllToEnterdCode();}
    
    

}
