using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManagement : MonoBehaviour
{

    public float fadeTime = 0.5f;
    private float outTime;
    private float inTime;
    private int fadeCount;
    private Color color;

    private SpriteRenderer render;
    private Material material;
    //フェード切り替えが発生したか
    //trueだったらフェードアウトしてる時, falseだったらフェードインしてる時
    private bool fadeSwitchFlag;
    private bool fadeStartFlag;
    //カウントが発生したか
    private bool isCountFlag;
    //フェードを終了させるか
    private bool fadeEndFlag;

    public bool GetFadeEndFlag() { return fadeEndFlag; }

    // Start is called before the first frame update
    public void Init()
    {
        inTime = 0;
        outTime = 0;
        fadeCount = 0;
        render = GetComponent<SpriteRenderer>();
        material = GetComponent<SpriteRenderer>().material;
        fadeSwitchFlag = true;
        fadeStartFlag = false;
        isCountFlag = false;
        color = new Color(material.color.r, material.color.g, material.color.b, 1.0f);
        fadeEndFlag = false;
    }

    // Update is called once per frame
    public void IsRangeAndIsFade(bool _isRange, bool _isFadeOut)
    {
        if (_isRange == true && _isFadeOut == true)
        {
            fadeStartFlag = true;
        }
        else
        {
            fadeStartFlag = false;
        }

        if (fadeStartFlag)
        {
            if (fadeSwitchFlag)
            {
                FadeOut();
                Debug.Log("out");
            }
            else if (fadeSwitchFlag == false && fadeCount <= 2)
            {
                FadeIn();
                Debug.Log("in");
            }
        }

        if (fadeCount >= 3)
        {
            fadeEndFlag = true;
            ++CompleteButton.feadOutCount;
        }

    }

    public void Complete(bool _complete)
    {
        if (_complete)
        {
            if (fadeSwitchFlag == false)
            {
                FadeIn();
            }
        }
    }
    public void FadeOut()
    {
        // フェードアウト
        outTime += Time.deltaTime;

        if (outTime < fadeTime)
        {
            float alpha = 1.0f - outTime / fadeTime;
            color.a = alpha;
            material.color = color;

            if (material.color.a <= 0.1f)
            {
                color.a = 0.0f;
                material.color = color;
            }

        }

        if (material.color.a <= 0.1f)
        {
            fadeSwitchFlag = false;
            fadeCount++;
            outTime = 0.0f;

        }
    }
    public void FadeIn()
    {
        //フェードイン処理
        inTime += Time.deltaTime;

        // フェードイン
        if (inTime < fadeTime)
        {
            float alpha = 0.0f + inTime / fadeTime;
            Color color = render.color;
            color.a = alpha;
            material.color = new Color(color.r, color.g, color.b, alpha);

            if (material.color.a >= 0.9f)
            {
                color.a = 1.0f;
                material.color = color;
            }

            //if (material.color.a >= 1.0f)
            //{
            //    fadeSwitchFlag = true;
            //    inTime = 0.0f;
            //}
        }

        if (material.color.a >= 0.9f)
        {
            fadeSwitchFlag = true;
            inTime = 0.0f;
        }

    }

}
