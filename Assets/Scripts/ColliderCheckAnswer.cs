using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheckAnswer : MonoBehaviour {

	//정답체크 
    //0. 정답을 다 입력했는지 확인하기
    //1.정답과 현재색이 같은지 비교
    //1.1 다 같은지 확인하기
    //2. ui 비활성화 하기
    //3. 맞춰야 하는 개수 재 카운트
    //4. ㄴui 변경된 수 보여주기
    

    public void OnCheckAnwer()
    {
        CheckAnswer();
        OffUI();
        RecountTargetNum();
        ShowRecountTargetNum();
    }
    
    void CheckAnswer()
    {
        ManagerStar.instance.CompareCountStarCodes();
    }
    void OffUI()
    {
        ManagerUI.instance.HideAllUI();
    }
    void RecountTargetNum()
    {
        ManagerStar.instance.ReCountTargetNum();
    }
    void ShowRecountTargetNum()
    {
        ManagerStar.instance.ShowTotalTargetNum();
    }
}
