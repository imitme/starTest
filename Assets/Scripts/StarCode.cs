using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCode : MonoBehaviour {

    // 시작할때, 별의 색! 매니저에 보내기
    // 시작할떄, 별 메쉬 색 검정에서 시작!
    public Color rStarCode;
    public Color currentCode;
    public Color enteredCode;
    public Color mixAdditiveCode;
    public SSTATE sState;
    public GameObject correctEffects;

    private void Awake()
    {
    //    ManagerStar.instance.starCodes.Add(this);
      //  this.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    void Start ()
    {
        ManagerStar.instance.starCodes.Add(this);
        this.GetComponent<MeshRenderer>().material.color = Color.black;
        currentCode = this.GetComponent<MeshRenderer>().material.color;
        sState = SSTATE.INCORRECT;
        correctEffects.SetActive(false);
    }
    
    /*
    public bool IsRightStarCode(Color color)
    {
        return ;
    }
    */
	
}
