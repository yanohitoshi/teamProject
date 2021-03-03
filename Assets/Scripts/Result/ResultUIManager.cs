using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField]
    private UICompleteness uiCompleteness;
    [SerializeField]
    private SendRankState  sendRankState;

    ////------------------------------------
    //// 特・大・小ランク
    ////------------------------------------
    //// 特盛
    //[SerializeField]
    //private Tmori_Img      t_mori_Img;
    //// 大盛
    //[SerializeField]
    //private Omori_Img      o_mori_Img;
    //// 小盛
    //[SerializeField]
    //private Smori_Img      s_mori_Img;

    //------------------------------------
    // その他ランク
    //------------------------------------
    //[SerializeField]
    //private Zingai_Img zingai_Img;
    //[SerializeField]
    //private GendaiArt_Img gendaiArt_Img;

    [SerializeField]
    private UIActiveManager uiActiveManager;

    public void Init()
    {
        uiCompleteness.Init();
        sendRankState.Init();

        //// 特・大・小ランク
        //t_mori_Img.Init();
        //o_mori_Img.Init();
        //s_mori_Img.Init();

        //// その他ランク
        //zingai_Img.Init();
        //gendaiArt_Img.Init();

        uiActiveManager.Init();
    }

    public void Run()
    {
        uiCompleteness.Run();

        //// 特・大・小ランク
        //t_mori_Img.Run();
        //o_mori_Img.Run();
        //s_mori_Img.Run();

        //// その他ランク
        //zingai_Img.Run();
        //gendaiArt_Img.Run();

        uiActiveManager.Run();
    }
}
