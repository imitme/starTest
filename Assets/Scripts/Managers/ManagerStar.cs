using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SSTATE
{
    CORRECT = 0, INCORRECT,
};


public class ManagerStar : MonoBehaviour {

    public Text hintLable;
    public Text totalTargetNumLable;
    public static ManagerStar instance { get; private set; }
    public List<ColliderStar> starColliders;
    public List<StarCode> starCodes;
    public Material[] mats;
    private void Awake()    {  instance = this;     }

    public int totalTargetNum;

    float sumrR = 0;
    float sumgG = 0;
    float sumbB = 0;

    float currnetTR = 0;
    float currnetTG = 0;
    float currnetTB = 0;

    public bool RightAllCodes = false;

    void Start()
    {
        var tml = GameObject.Find("Text - TotalTargetNumLabel");
        totalTargetNumLable = tml.GetComponent<Text>();
        var hl = GameObject.Find("Text - HintLabel");
        hintLable = hl.GetComponent<Text>();

        SetStarCode();
        SumStarCode();
        ShowHintLable();
              
        totalTargetNum = starCodes.Count;
        ShowTotalTargetNum();
        
    }
    
    
    public void SetStarCode()
    {
        //시작할때, 정답세팅하기
        for (int i = 0; i < starCodes.Count; ++i)
        {
            starCodes[i].rStarCode = mats[Random.Range(0, mats.Length)].color;
            starCodes[i].rStarCode.a = 1.0f;
            Debug.Log("정답색은 " + i + " : " + starCodes[i].rStarCode );
        }
    }

   
     void SumStarCode()
    {
        //정답색합치기
        for (int i = 0; i < starCodes.Count; ++i)
        {
            sumrR += starCodes[i].rStarCode.r;
            sumgG += starCodes[i].rStarCode.g;
            sumbB += starCodes[i].rStarCode.b;
        }
    }

    public void ResetHintLabel()
    {
        hintLable.text = "( " + sumrR + " , " + sumgG + " , " + sumbB + " )";
    }


    //매 프레임마다??_사실 입력할 때 마다이긴 한데...
    //정답 힌트 표기하기 위해 정답색 합치고 표기하기
    public void OnHintLable()
    {
        SumEnterCode();
        ShowHintLable();
    }

    public void ShowTotalTargetNum()
    {
        
        totalTargetNumLable.text = "[ " + totalTargetNum + " ]";
    }

    void SumEnterCode()
    {
        currnetTR = 0;
        currnetTG = 0;
        currnetTB = 0;
   
        //들어있는색들합치기
        for (int i = 0; i < starCodes.Count; ++i)
        {
            currnetTR += starCodes[i].currentCode.r;
            currnetTG += starCodes[i].currentCode.g;
            currnetTB += starCodes[i].currentCode.b;
        }

    }
    void ShowHintLable()
    {
        //정답색 - 들어있는 색 표기하기
        float showR = sumrR - currnetTR;
        float showG = sumgG - currnetTG;
        float showB = sumbB - currnetTB;
        hintLable.text = "( " + showR + " , " + showG + " , " + showB + " )";
    }

    public void OffHintLable()
    {
        hintLable.text = "";
    }




        //정답과 현재식 비교하고 갯수 세고 알려주기. //다맞는지 확인하기
        public void CompareCountStarCodes()
    {
        int numRightCodes = 0;
        for (int i = 0; i < starCodes.Count; ++i)
        {
            if(starCodes[i].rStarCode == starCodes[i].currentCode)
            {
                ++numRightCodes;
                starCodes[i].sState = SSTATE.CORRECT;

                Debug.Log("정답이다 ! 정답은: " +starCodes[i].rStarCode + " -넣은것은 : " + starCodes[i].currentCode 
                    + " 맞은개수 : " + numRightCodes);
            }
            else
            {
                Debug.Log("틀림이다 ! 정답은: " + starCodes[i].rStarCode + " -넣은것은 : " + starCodes[i].currentCode
                    + " 맞은개수 : " + numRightCodes);
            }
                
        }
        ShowNumRightCodes(numRightCodes);
        CheckAllCodesRight(numRightCodes);
    }
    void ShowNumRightCodes(int numRights)
    {
        Debug.Log(" 맞은개수 : " + numRights + " / 총 별의 수 : " + starCodes.Count);
    }

    void CheckAllCodesRight(int numRights)
    {
        if(numRights == starCodes.Count)
        {
            RightAllCodes = true;
        }
    }



    // 코드입력기 숨기기
    public void HideAll()
    {
        for ( int i = 0; i< starColliders.Count; ++i)
        {
            starColliders[i].HideCodes();
        }
    }
    
    //가할 코드 가져오기
    public Color additiveCode;
    public void GetAdditiveCode(Color setAdditiveCode)
    {
        additiveCode = setAdditiveCode;
    }

    //코드 가하기 시작 (언제? 버튼눌렀을 때)
    public void OnMixAdditiveCodeAll()
    {
        //체크하고
        CheckNoCode();
        //코드 가할지 결정하고
        if (CheckNoCodeNum == 0)
        {
            //스크린 켜지고
            ShowScreen();
            //색 백업하고
            ProtectedEnteredCode();
            //색가하기
            OnMixAdditiveCodeAll(additiveCode);
            //별 색 비교
            CompareMixtoRCodesAll();
        }
        else
        {
            Debug.Log("모든 코드를 입력하셔야 합니다.");
            Debug.Log("미입력된 코드 수 : " + CheckNoCodeNum);
        }
        // 여튼 눌렀으면 역할끝났으니 UI 숨기기
        ManagerUI.instance.HideAllUI();

    }



    //스크린 켜기
    public GameObject addictiveScreen;
    public void GetAdditiveScreen(GameObject setAddictiveScreen)
    {
        addictiveScreen = setAddictiveScreen;
    }
    public void ShowScreen()
    {
        Debug.Log("스크린 켜짐");
        addictiveScreen.SetActive(true);
    }
    public void HideScreen()
    {
        addictiveScreen.SetActive(false);
    }
    

    // 코드 가하기 전에 백업해놓기 (언제? 버튼 누를 때)
    public void ProtectedEnteredCode()
    {
        for (int i = 0; i < starCodes.Count; i++)
        {
            starCodes[i].enteredCode = starCodes[i].GetComponent<MeshRenderer>().material.color;
            starCodes[i].enteredCode.a = 1.0f;
        }
    }

    // 코드 입력이 다 되었는지 체크. 안되면 실행 안되게
    public int CheckNoCodeNum;
    public void CheckNoCode()
    {
        int a = 0;
        for (int  i=0; i < starCodes.Count; ++i)
        {
            Color currentCode = starCodes[i].GetComponent<MeshRenderer>().material.color;
            if (currentCode == Color.black)
            {
                a += 1;
            }
        }
        CheckNoCodeNum = a;
    }

    // 코드 가하기
    public void OnMixAdditiveCodeAll(Color additiveCode)
    {
        for (int i = 0; i < starCodes.Count; i++)
        {
            Color currentCode = starCodes[i].GetComponent<MeshRenderer>().material.color;
            currentCode.r = Mathf.Clamp(currentCode.r + additiveCode.r, 0f, 1f);
            currentCode.g = Mathf.Clamp(currentCode.g + additiveCode.g, 0f, 1f);
            currentCode.b = Mathf.Clamp(currentCode.b + additiveCode.b, 0f, 1f);
            currentCode.a = 1.0f;
            Debug.Log("별의 예측 코드는 : " + currentCode + "// (별에 가해진 코드 : " + additiveCode + " )" );

            starCodes[i].mixAdditiveCode = currentCode;
            starCodes[i].GetComponent<MeshRenderer>().material.color = starCodes[i].mixAdditiveCode;
        }
    }

    public void EmptyMixCodeAll()
    {
        for (int i = 0; i < starCodes.Count; i++)
        {
            starCodes[i].mixAdditiveCode = Color.clear;
        }
    }

    //별 상태 체크 후 상태 변경
    public void CompareMixtoRCodesAll()
    {
        /// <summary>
        /// 이때, 
        /// 변경된 색이 기존색이랑 다른데, 정답이랑 같으면 > 정답이랑 같다는 표시해 주고 (코루틴?)
        /// 변경된 색이 기존색이랑 다른데, 정답이랑 다르면 > 아무변화 없고
        /// </summary>
        for (int i = 0; i < starCodes.Count; ++i)
        {
            var mixAdditiveCode = starCodes[i].mixAdditiveCode;
            var rStarCode = starCodes[i].rStarCode;

            if( mixAdditiveCode == rStarCode)
            {
                //TODO: 정답이랑 같다는 표시해주기
                TestCodeCorrectEffects(i, 1);
            }
        }
    }
    public void OffCorrectEffectAll()
    {
        for (int i = 0; i < starCodes.Count; ++i)
        {
            TestCodeCorrectEffects(i, 0);
        }
    }

    void TestCodeCorrectEffects(int i, int a)
    {
        if (a == 1)
        {
            starCodes[i].correctEffects.SetActive(true);
        }
        else
        {
            starCodes[i].correctEffects.SetActive(false);
        }
    }
    

    // 백업해둔 색(enteredCode)으로 되돌리기 ( 코드 가한 것 취소하기 (언제? UI꺼질 때))
    public void ResetMixAdditiveCodeAllToEnterdCode()
    {
        for (int i = 0; i < starCodes.Count; i++)
        {
            starCodes[i].GetComponent<MeshRenderer>().material.color = starCodes[i].enteredCode;
        }
    }

    // 모두 검정색으로!  ResetAllCodesToBlack //현재 색도 검정색으로 !!
    public void ResetAllCodesToBlack()
    {
        for (int i = 0; i < starCodes.Count; i++)
        {
            starCodes[i].GetComponent<MeshRenderer>().material.color = Color.black;
            starCodes[i].currentCode = starCodes[i].GetComponent<MeshRenderer>().material.color;
            starCodes[i].currentCode.a = 1.0f;
        }
    }


    public void ReCountTargetNum()
    {
        int countTargetNum = 0;
        for (int i = 0; i < starCodes.Count; i++)
        {
            if(starCodes[i].sState == SSTATE.INCORRECT)
            {
                ++countTargetNum;
            }
        }

        totalTargetNum = countTargetNum;
    }

}
