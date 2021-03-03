using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Rank_Img : MonoBehaviour
{
    public void Init()
    {
        gameObject.SetActive(false);
    }

    public void Run()
    {
        if (SendRankState.isRankA)
        {
            gameObject.SetActive(true);
        }
    }
}
