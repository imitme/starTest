using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderResetCode : MonoBehaviour {

    //1.색 다 검정색으로 만들기
    //2. UI 의 숫자도 현재 색으로 만들어 줘야 해!
    //3. UI 끄기!
    public void OnResetCodes()
    {
        ManagerStar.instance.ResetAllCodesToBlack();
        ManagerStar.instance.ResetHintLabel();
        ManagerUI.instance.HideAllUI();
    }
}
