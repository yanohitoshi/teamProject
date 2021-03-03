using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICompleteness : MonoBehaviour
{
    [SerializeField]
    private Image gageImg;

    //Textの変数
     Text text;

    //完成度(仮)
    //
    static public float completeness;
    private float score;
    private const float OVER_VALUE = 1200;
    private bool isCalculation;
    public void Init()
    {
        //TextMeshProUGUIを取得
        text = GetComponent<Text>();
        completeness = Score_Calculation.score;
        isCalculation = true;
        Calculation(completeness);
        completeness = score;
    }

    public void Run()
    {
        //描画処理
        Draw();
    }

    private void Draw()
    {
        score = (int)score;

        if (score <= 0)
        {
            score = 0;
        }
        text.text = score.ToString() + "%";
        gageImg.fillAmount = score / 100.0f;
    }

    private void Calculation(float completeness)
    {
        if (isCalculation)
        {
            float percent;
            percent = completeness / OVER_VALUE * 100.0f;
            score = 100.0f - percent;

            Debug.Log(percent);
            Debug.Log(score);
            isCalculation = false;
        }

    }
}
