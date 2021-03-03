using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // 円形ゲージ
    [SerializeField]
    private Image Countdown_circle;
    // カウントダウンの秒数
    [SerializeField]
    private float totalTime;

    // カウントダウン計算用(ゲージ計算で使用)
    private float totalNum;
    // 円形ゲージ用合計(キャスト無し計算で使用)
    private float CircleTotalTime;

    // カウントダウン文字
    public Text countdownText;

    // 計算用
    int seconds;
    float CircleSeconds;

    public void Init()
    {
        totalNum = totalTime;
        CircleTotalTime = totalTime;
    }

    public void Run()
    {
        // テキスト用カウントダウン
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        countdownText.text = seconds.ToString();

        // ゲージ用カウントダウン
        CircleTotalTime -= Time.deltaTime;
        CircleSeconds = CircleTotalTime;
        Countdown_circle.fillAmount = CircleSeconds / totalNum;

        if (CircleTotalTime <= 0.5f)
        {
            SceneTransitionManager.isToGame = true;       // ゲームシーンに遷移
        }
    }
}
