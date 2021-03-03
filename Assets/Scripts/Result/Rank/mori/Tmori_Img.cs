using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (特盛)画像表示処理
public class Tmori_Img : MonoBehaviour
{
    public void Init()
    {
        gameObject.SetActive(false);
    }

    public void Run()
    {
        // ランクがSだったら表示
        if (SendRankState.isRankS)
        {
            gameObject.SetActive(true);
        }
    }
}
