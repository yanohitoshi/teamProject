using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;

public class CompleteButton : MonoBehaviour
{
    private float time;

    public System.Action OnTouchEvent;
    //public System.Action<CompleteButton> b;
    //public System.Func<int, CompleteButton> hattori;

    public bool completeFlag;
    //public void Method()
    //{
    //    Fadeout fadeout = new Fadeout();
    //    fadeout.A += () => OnClickCompleteButton();
    //    fadeout.Method();
    //}

    //public bool GetCompleteFlag()
    //{
    //    return completeFlag;
    //}

    static private bool allFeadOutFlag;
    static public bool GetAllFeadOutFlag()
    {
        return allFeadOutFlag;
    }
    static public int feadOutCount;


    public void Init(System.Action touchEvent)
    {
        SetTouchEvent(touchEvent);
        completeFlag = false;
        time = 0.0f;
        feadOutCount = 0;
        allFeadOutFlag = false;
    }

    public void SetTouchEvent(System.Action touchEvent)
    {
        OnTouchEvent += touchEvent;
    }

    //public void SetTouchEvent(System.Action touchEvent)
    //{
    //    a = touchEvent;
    //}

    //public void SetTouchEventB(System.Action<float> touchEvent)
    //{
    //    b = touchEvent;
    //}

    //public void SetTouchEventC(System.Func<int, CompleteButton> touchEvent)
    //{
    //    hattori = touchEvent;
    //}

    public void Run()
    {
        if (feadOutCount >= 7)
        {
            allFeadOutFlag = true;
        }
        //if (completeFlag)
        //{
        //    time += Time.deltaTime;
        //}

        //if (completeFlag == true && time >= 3.0f)
        //{
        //    SceneTransitionManager.isComplete = true;       // ボタンを押したらリザルトシーンに遷移
        //}
    }

    public void OnClickCompleteButton()
    {
        OnTouchEvent();
        //b(this);
        //completeFlag = true;
        StartCoroutine(ToResultScene());
    }

    private IEnumerator ToResultScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneTransitionManager.isComplete = true;       // ボタンを押したらリザルトシーンに遷移
    }
}