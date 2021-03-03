using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankCharacterManager : MonoBehaviour
{
    //Sランクのキャラクター
    [SerializeField]
    GameObject SRankCharacter;
    //Aランクのキャラクター
    [SerializeField]
    GameObject ARankCharacter;
    //Bランクのキャラクター
    [SerializeField]
    GameObject BRankCharacter;
    //アクティブフラグ
    private bool onActive;


    public void Init()
    {
        SRankCharacter.SetActive(false);
        ARankCharacter.SetActive(false);
        BRankCharacter.SetActive(false);
        onActive = true;
    }

    public void Run()
    {
        if (onActive)
        {
            onActive = false;
            if (SendRankState.isRankA)
            {
                ARankCharacter.SetActive(true);
            }
            else if (SendRankState.isRankS)
            {
                SRankCharacter.SetActive(true);
            }
            else
            {
                BRankCharacter.SetActive(true);
            }

        }
    }

    public void setActive(bool activeFlag)
    {
        onActive = activeFlag;
    }

}
