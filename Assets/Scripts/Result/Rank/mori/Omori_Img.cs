using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (大盛)画像表示処理
public class Omori_Img : MonoBehaviour
{
    public void Init()
    {
        gameObject.SetActive(false);
    }

    public void Run()
    {
        // ランクがAだったら表示
        if (SendRankState.isRankA)
        {
            gameObject.SetActive(true);
        }
    }
}
