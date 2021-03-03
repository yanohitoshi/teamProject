using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendRankState : MonoBehaviour
{
    //Aランクのボーダーライン
    private const float BORDER_A_RANK = 75.0f;
    //Sランクのボーダーライン
    private const float BORDER_S_RANK = 85.0f;
    //Bランクのボーダーライン
    private const float BORDER_B_RANK = 60.0f;

    //ランクSフラグ
    static public bool isRankS;
    //ランクAフラグ
    static public bool isRankA;
    //ランクBフラグ
    static public bool isRankB;
    //現代アートランクフラグ
    static public bool isRankG;
    //人外ランクフラグ
    static public bool isRankZ;
    private float rank;
    public void Init()
    {
        //フラグの初期化
        isRankS = false;
        isRankA = false;
        isRankB = false;
        isRankG = false;
        isRankZ = false;

        //どのランクかを調べる
        CheckRankState(UICompleteness.completeness);
    }

    private void CheckRankState(float completeness)
    {
        rank = completeness;
        if (rank <= 0)
        {
            rank = 0;
        }
        if(BORDER_A_RANK <= rank && rank < BORDER_S_RANK)    //BORDER_A_RANKよりも大きくBORDER_S_RANK以下の時
        {
            isRankA = true;
        }
        else if(BORDER_S_RANK <= rank)    //BORDER_S_RANKよりも大きいとき
        {
            isRankS = true;
        }
        else if (BORDER_B_RANK <= rank && rank < BORDER_A_RANK)
        {
            isRankB = true;
        }
        else if (rank < BORDER_B_RANK)
        {
            isRankG = true;
        }
        //else if (rank < BORDER_G_RANK)   //それ以外の時
        //{
        //    isRankZ = true;
        //}
    }
}
