using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GState
{
    Ready = 0, Play, Success
}
public class GameController : MonoBehaviour {
    

    GState gState;
   // public Text progressLabel;
    public Text stateLabel;

	// Use this for initialization
	void Start () {
        Ready();
	}
    void LateUpdate()
    {
        switch (gState)
        {
            case GState.Ready:
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;
            case GState.Play:
                if(ManagerStar.instance.RightAllCodes == true) Success();
                break;
            case GState.Success:
                if (Input.GetButtonDown("Fire1")) Reload();
                break;
        }
    }

    void Ready()
    {
        gState = GState.Ready;
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "시좍";
    }	
    void GameStart()
    {
        gState = GState.Play;
        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";
    }
    void Success()
    {
        gState = GState.Success;
        stateLabel.gameObject.SetActive(true);
        
        stateLabel.text = " 다 맞음!! " + " / 총 별의 수 : " + ManagerStar.instance.starCodes.Count;
    }

    void Reload()
    {

    }
}
