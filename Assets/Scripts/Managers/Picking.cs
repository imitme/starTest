using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.tag == "Star")
                {
                    //코드 입력기 다 숨기기 (초기화)
                    //코드 입력기 보이기
                    var starPick = hit.transform.GetComponent<ColliderStar>();
                    if (starPick != null)
                    {
                        ManagerStar.instance.HideAll();
                        starPick.ShowCodes();
                    }
                }

                else if (hit.transform.tag == "HideAllPlan")
                {
                    //코드 입력기 다 숨기기 (사용 중지)
                    var HidePlanPick = hit.transform.GetComponent<ManagerStar>();
                    if (HidePlanPick != null)
                    {
                        HidePlanPick.HideAll();
                    }
                    
                }

                else if (hit.transform.tag == "Code")
                {
                    // 누르면, ‘별 메쉬’의 색에 누른색 더하기. 변함. 
                    /* 
                     * 1. 누른 입력코드 확인.
                     * 2. 별 메쉬에 색에 입력코드 더하기.
                     * 3. ’코드입력기’ 다 숨기기 (사용 끝)
                     */
                    //&  힌트시스템 작동
                    var CodePick = hit.transform.GetComponent<ColliderCode>();
                    if (CodePick != null)
                    {
                        CodePick.EnterCode();
                        ManagerStar.instance.OnHintLable();     //힌트시스템부르기
                    }
                }

                else if (hit.transform.tag == "OnOffUI")
                {
                    //버튼 누르면, UI 꺼진상태이면, UI 다 켜주기
                    //버튼 누르면, UI 켜진상태이면, UI 다 꺼주기
                    var OnOffUIPick = hit.transform.GetComponent<ManagerUI>();
                    if (OnOffUIPick != null)
                    {
                        if (OnOffUIPick.CheckOnOff == false)
                        {
                            //UI 켜고, 켜기로 설정 변경
                            /* UI 켤때 색 백업 & UI 열기 & 코드입력기 끄기*/
                            OnOffUIPick.OOUIPick();
                        }
                        else
                        {
                            //UI 끄기 / 끄기로 설정 변경
                            OnOffUIPick.HideAllUI();
                        }
                    }
                }

                else if (hit.transform.tag == "AdditiveCode")
                {
                    //누르면, 별 메쉬의 색에 누른색 더하기.
                    /*
                     * 입력받은 색 보내고
                     * 기존색에 입력받은 색 합치기!
                     */
                    var AdditiveCodePick = hit.transform.GetComponent<ColliderAdditiveCode>();
                    if (AdditiveCodePick != null)
                    {
                        Debug.Log("가산코드입력기 " + AdditiveCodePick.additiveCode + " 눌림");
                        //색보내고 //스크린도 켜기도 보내기
                        AdditiveCodePick.OnMixAdditiveCode();
                        //색 백업하고/ 색 넣고/ UI 끄기 
                        ManagerStar.instance.OnMixAdditiveCodeAll();
                        //UI Text 힌트 레이블도 끄고!
                        ManagerStar.instance.OffHintLable();

                    }
                }
                else if (hit.transform.tag == "AdditiveScreen")
                {
                    // 누르면, 스크린 꺼지고, 원 상태로 돌아가기
                    /*
                     * 스크린 끄고
                     * 백업해둔 색으로 바꾸기!
                     * ----20190109
                     * UItext 힌트 레이블 다시 띄우기
                     */ 
                    var AdditiveScreenPick = hit.transform.GetComponent<ColliderScreen>();
                    if(AdditiveScreenPick != null)
                    {
                        //Debug.Log("스크린 pick");
                        AdditiveScreenPick.ASPick();
                        // UItext 힌트 레이블 다시 띄우기
                        ManagerStar.instance.OnHintLable();
                        //맞다는 표시-효과 꺼쥬고!
                        ManagerStar.instance.OffCorrectEffectAll();
                        //mixAdditiveCode 초기화해주기!
                        ManagerStar.instance.EmptyMixCodeAll();
                    }
                }

                else if (hit.transform.tag == "CheckAnswer")
                {
                    //누르면, 정답비교하고 맞은갯수 세서 보여주기까지 해야함.
                    var CheckAnswerPick = hit.transform.GetComponent<ColliderCheckAnswer>();
                    if(CheckAnswerPick != null)
                    {
                        CheckAnswerPick.OnCheckAnwer();
                    }
                }
                else if(hit.transform.tag == "ResetCode")
                {
                    var ResetCodePick = hit.transform.GetComponent<ColliderResetCode>();
                    if (ResetCodePick != null)
                    {
                        ResetCodePick.OnResetCodes();
                    }
                }

                else
                    Debug.Log("암것도 선택 안함");



            }
        }
    }
}
