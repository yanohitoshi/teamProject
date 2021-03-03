using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    // オブジェクトが移動可能か
    private bool fadeOutFlag;
    public void SetIsfadeOutFlag(bool _set) { fadeOutFlag = _set; }
    public bool GetIsfadeOutFlag()
    {
        return fadeOutFlag;
    }

    private bool isRange;

    public void SetIsRangeFlag(bool _set) { isRange = _set; }
    public bool GetIsRangeFlag()
    {
        return isRange;
    }

    private bool moveFlag;
    public bool GetMove()
    {
        return moveFlag;
    }
    public void SetMove(bool _set) { moveFlag = _set; }

    private FadeManagement fadeManagement;

    public void Init()
    {
        fadeManagement = gameObject.GetComponent<FadeManagement>();

        moveFlag = true;
        isRange = false;
        fadeOutFlag = false;
        fadeManagement.Init();
    }

    public void Run(bool _complete)
    {
        if (fadeManagement.GetFadeEndFlag() == false)
        {
            fadeManagement.IsRangeAndIsFade(isRange, fadeOutFlag);
        }

        if (_complete == true)
        {
            fadeManagement.Complete(_complete);
        }
    }

}
