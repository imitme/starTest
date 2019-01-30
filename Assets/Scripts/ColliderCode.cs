using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCode : MonoBehaviour {

    // 누르면, ‘별 메쉬’의 색에 누른색 더하기. 변함. 
    /* 
     * 1. 누른 입력코드 확인.
     * 2. 별 메쉬에 색에 입력코드색 더하기.
     * 3. ’코드입력기’ 다 숨기기 (사용 끝)
     */
    public Color code;
    public GameObject starObj;
    public void EnterCode()
    {
        Color currentCode = starObj.GetComponent<MeshRenderer>().material.color;
        if (code == Color.black)
        {
            Debug.Log("코드 빼기");
            starObj.GetComponent<MeshRenderer>().material.color = code;
            starObj.GetComponent<StarCode>().currentCode = code;
            ManagerStar.instance.OnHintLable(); //힌트시스템 부르기
        }
        else if (currentCode == Color.white)
        {
            Debug.Log("코드 못 넣음");
            ManagerStar.instance.HideAll();
        }
        else
        {
            MixtureCode();
            ManagerStar.instance.HideAll();
        }
    }

    
    public void MixtureCode()
    {
        Color currentCode = starObj.GetComponent<MeshRenderer>().material.color;

        currentCode.r = Mathf.Clamp(currentCode.r + code.r, 0f, 1f);
        currentCode.g = Mathf.Clamp(currentCode.g + code.g, 0f, 1f);
        currentCode.b = Mathf.Clamp(currentCode.b + code.b, 0f, 1f);
        currentCode.a = 1.0f;
        Debug.Log("별에 입력한 코드는 : " + currentCode);
        //색 변경 하고 색 저장하고
        starObj.GetComponent<MeshRenderer>().material.color = currentCode;
        starObj.GetComponent<StarCode>().currentCode = currentCode;
        
    }
    
}
