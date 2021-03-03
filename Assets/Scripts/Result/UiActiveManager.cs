using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActiveManager : MonoBehaviour
{
    //買い物ボタン
    [SerializeField]
    private GameObject shoppingButton;
    //タイトルボタン
    [SerializeField]
    private GameObject titleButton;
    //ランク
    //小盛
    [SerializeField]
    private GameObject syomori;
    //大盛
    [SerializeField]
    private GameObject oomori;
    //特盛
    [SerializeField]
    private GameObject tokumori;
    //人外
    [SerializeField]
    private GameObject zingai;
    //現代アート
    [SerializeField]
    private GameObject gendaiArt;
    //ボタンをアクティブにするフラグ
    public static bool buttonActiveFlag;
    //ランクをアクティブにするフラグ
    public static bool rankActiveFlag;

    //キャラクターを表示させる時間
    [SerializeField]
    private float characterActiveTime;
    //デルタタイム
    private float deltaTime;
    //キャラクターアクティブフラグ
    private bool characterActiveFlag;
    //ランクを表示させる時間
    [SerializeField]
    private float rankActiveTime;
    public void Init()
    {
        //非アクティブ化
        shoppingButton.SetActive(false);
        titleButton.SetActive(false);
        syomori.SetActive(false);
        tokumori.SetActive(false);
        oomori.SetActive(false);
        tokumori.SetActive(false);
        zingai.SetActive(false);
        gendaiArt.SetActive(false);
        //フラグ初期化
        buttonActiveFlag = false;
        rankActiveFlag = false;
        characterActiveFlag = true;
    }

    public void Run()
    {

        deltaTime += Time.deltaTime;

        if (deltaTime > rankActiveTime)
        {
            rankActiveFlag = true;
            buttonActiveFlag = true;
        }

        if (buttonActiveFlag)
        {
            //アクティブにする
            shoppingButton.SetActive(true);
            titleButton.SetActive(true);
        }
        if(rankActiveFlag)
        {
            rankActive();
        }
        if(characterActiveFlag)
        {
            characterActive();
        }
    }

    private void characterActive()
    {
        deltaTime += Time.deltaTime;

        if(deltaTime > characterActiveTime)
        {
            //deltaTime = 0;
            MoveSweetsGenerator.activeFlag = true;

            characterActiveFlag = true;
        }
    }

    private void rankActive()
    {
        //deltaTime += Time.deltaTime;

        //if (deltaTime > rankActiveTime)
        //{
        //    deltaTime = 0;

            if(SendRankState.isRankB)
            {
                syomori.SetActive(true);
            }
            else if (SendRankState.isRankA)
            {
                oomori.SetActive(true);
            }
            else if (SendRankState.isRankS)
            {
                tokumori.SetActive(true);
            }
            else if (SendRankState.isRankG)
            {
                gendaiArt.SetActive(true);
            }
            //zingai.SetActive(false);


        //}
    }

}
