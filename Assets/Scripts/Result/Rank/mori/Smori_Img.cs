using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (小盛)画像表示処理
public class Smori_Img : MonoBehaviour
{
    public void Init()
    {
        gameObject.SetActive(false);
    }

    public void Run()
    {
        // ランクがBだったら表示
        if (SendRankState.isRankB)
        {
            gameObject.SetActive(true);
        }
    }
}
