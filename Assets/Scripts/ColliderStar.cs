using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStar : MonoBehaviour {

    //시작할때, 매니저에게 정보주기!
    //시작할때, Codes 숨기기.

    //누르면, ‘별빛코드입력기’ 보이기

    //’별빛코드N추측가하기’ 기능 다 되돌리기끄기!!!!!!!!!!!!!
    //(색은 기존색으로. 이펙트도 없고)
    // NScreen 숨기기

    public StarCode starcode;

    public GameObject[] codes;
    public Transform[] codesEffectEndPositions;
    public GameObject[] codesEffectEndPositionsMeshs;

    void Start()
    {
        ManagerStar.instance.starColliders.Add(this);

        HideCodes();
        for(int i = 0; i < codes.Length; ++i)
        {
            codesEffectEndPositionsMeshs[i].SetActive(false);
        }
    }

    //코드입력기 숨기기
    public void HideCodes()     {  FalseActiveCodes(); }
    // 코드입력기 위치랑 트윈모션!
    public void FalseActiveCodes()
    {
        for (int i = 0; i < codes.Length; ++i)
        {
            LeanTween.cancel(codes[i]);
            codes[i].transform.localPosition = Vector3.zero;
            codes[i].SetActive(false);
        }
    }


    public void ShowCodes()
    {
        if(starcode.sState == SSTATE.CORRECT)
        {
            return;
        }
        TrueActiveCodes();
        ShowCodesTweenMove();
    }



    public void TrueActiveCodes()
    {
        for (int i = 0; i < codes.Length; ++i)
        {
            codes[i].SetActive(true);
        }
    }

    private void ShowCodesTweenMove()
    {
        LeanTween.scale(codes[0], Vector3.one * 1f, 0.1f).setEase(LeanTweenType.easeInElastic);
        LeanTween.move(codes[0], codesEffectEndPositions[0], 1f).setEase(LeanTweenType.easeOutElastic);
        //Vector3 dirR = codesEffectEndPositions[0].position - transform.position;
        LeanTween.scale(codes[1], Vector3.one * 1f, 0.1f).setEase(LeanTweenType.easeInElastic);
        LeanTween.move(codes[1], codesEffectEndPositions[1], 1f).setEase(LeanTweenType.easeOutElastic);
        //Vector3 dirG = codesEffectEndPositions[1].position - transform.position;
        LeanTween.scale(codes[2], Vector3.one * 1f, 0.1f).setEase(LeanTweenType.easeInElastic);
        LeanTween.move(codes[2], codesEffectEndPositions[2], 1f).setEase(LeanTweenType.easeOutElastic);
        //Vector3 dirB = codesEffectEndPositions[2].position - transform.position;
        LeanTween.scale(codes[3], Vector3.one * 1f, 0.1f).setEase(LeanTweenType.easeInElastic);
        LeanTween.move(codes[3], codesEffectEndPositions[3], 1f).setEase(LeanTweenType.easeOutElastic);
        //Vector3 dirX = codesEffectEndPositions[3].position - transform.position;
    }
}
