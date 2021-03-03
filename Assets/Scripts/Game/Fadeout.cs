using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Fadeout : MonoBehaviour
{
    public float fadeTime = 0.5f;
    private float time;
    private SpriteRenderer render;
    private Material material;
    //透過を戻すタイミング用のカウント
    private int count;
    //フェードアウトされているかどうか
    private bool visibleFlag;
    //フェードアウト可能かどうか
    public bool isVisibleFlag;
    //フェードインされているかどうか
    private bool reVisibleFlag;
    //フェードイン可能かどうか
    private bool isReVisibleFlag;

    //private bool chackComplete;

    public void SetVisible(bool _isVisibleFlag) { isVisibleFlag = _isVisibleFlag; }

    //public event Action A = null;
    //public void Method()
    //{
    //    //処理
    //    if (A != null)
    //    {
    //        A();
    //    }
    //}

    public void Init()
    {
        render = GetComponent<SpriteRenderer>();
        material = GetComponent<SpriteRenderer>().material;
        visibleFlag = false;
        reVisibleFlag = false;
        isReVisibleFlag = false;
        isVisibleFlag = false;
        count = 0;
    }

    public void Run()
    {
     

        // 左クリックを離したとき
        //if (Input.GetMouseButtonUp(0))          
        //{
        //    Debug.Log("左クリック離した");
        //    isVisibleFlag = true;
        //}

        //フェードアウト処理
        if (isVisibleFlag == true && visibleFlag == false)
        {
           time += Time.deltaTime;
           // フェードアウト
           if (time < fadeTime)
           {
               float alpha = 1.0f - time / fadeTime;
               Color color = render.color;
               color.a = alpha;
               material.color = new Color(color.r, color.g, color.b, alpha);
           }

           if(material.color.a <= 0.01f)
           {
               visibleFlag = true;
                isVisibleFlag = false;
            }
        }

        //フェードインするタイミングをはかる処理（完成ボタンを押したらに変える）
        if(visibleFlag == true && reVisibleFlag == false)
        {
            ++count;
            if(count >= 120)
            {
                time = 0.0f;
                //isReVisibleFlag = true;
            }
        }

    //    if (CompleteButton.completeFlag)
    //    {
    //        //フェードイン処理
    //        if (isReVisibleFlag == true && reVisibleFlag == false)
    //        {
    //            time += Time.deltaTime;
    //            // フェードイン
    //            if (time < fadeTime)
    //            {
    //                float alpha = material.color.a + time / fadeTime;
    //                Color color = render.color;
    //                color.a = alpha;
    //                material.color = new Color(color.r, color.g, color.b, alpha);
    //            }
    //            if (material.color.a >= 0.99f)
    //            {
    //                reVisibleFlag = true;
    //                isReVisibleFlag = false;
    //            }
    //        }
    //    }
    }
}
