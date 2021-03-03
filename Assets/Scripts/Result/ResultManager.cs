using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    //UIManagerの変数
    private GameObject UIManager;
    //ResultUIManagerの変数
    private ResultUIManager resultUIManager;
    //固定のお菓子を生成する工場
    [SerializeField]
    private FixedSweetsGenerator fixedSweetsGenerator;
    //動くお菓子を生成する工場
    [SerializeField]
    private MoveSweetsGenerator moveSweetsGenerator;
    //ランク別のキャラクターマネージャー
    [SerializeField]
    private RankCharacterManager rankCharacterManager;
    //UIの更新フラグ
    private  bool UIUpdateFlag;

    IEnumerator Start()
    {
        UIUpdateFlag = false;
        //UIシーンがロードされるまで待つ
        yield return SceneManager.LoadSceneAsync("ResultUI", LoadSceneMode.Additive);
        //UIManagerをResultUIシーンの1番目のオブジェクトから取得
        UIManager = SceneManager.GetSceneByName("ResultUI").GetRootGameObjects()[0];
 　　　 //resultUIManagerを取得
        resultUIManager = UIManager.GetComponent<ResultUIManager>();
        //初期化
        resultUIManager.Init();
        fixedSweetsGenerator.Init();
        moveSweetsGenerator.Init();
        rankCharacterManager.Init();
        //UIの更新許可
        UIUpdateFlag = true;

    }

    void Update()
    {
        if (UIUpdateFlag)
        {
            resultUIManager.Run();
        }
      
        fixedSweetsGenerator.Run();
        moveSweetsGenerator.Run();
        rankCharacterManager.Run();

        //お菓子の更新
        for(int i = 0; i < fixedSweetsGenerator.fixedSweetsList.Count;i++)
        {
            fixedSweetsGenerator.fixedSweetsList[i].Run();
        }
        for (int i = 0; i < moveSweetsGenerator.moveSweetsList.Count;i++)
        {
            moveSweetsGenerator.moveSweetsList[i].Run();
        }

    }
}
