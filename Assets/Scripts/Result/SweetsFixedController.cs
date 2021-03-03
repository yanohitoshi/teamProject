using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetsFixedController : MonoBehaviour
{
    private bool activeFlag;


    private void Start()
    {
        //非アクティブ化
        gameObject.SetActive(false);
        //フラグの初期化
        activeFlag = true;
    }

    public void Run()
    { 
        if (activeFlag)
        {
            //アクティブ化
            gameObject.SetActive(true);
        }
       
    }

    public void SetActiveFlag(bool flag)
    {
        activeFlag = flag;
    }
}
