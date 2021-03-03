using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    //[SerializeField]
    //BGM_Manager bgm_Manager;
    
    //タイトル遷移フラグ
    static public bool isToTitle;
    //ルールシーンフラグ
    static public bool isToRule;
    //見本シーン遷移フラグ
    static public bool isToSample;
    //ゲーム遷移フラグ
    static public bool isToGame;
    //完成ボタン
    static public bool isComplete;
    //ゲーム終了フラグ
    static public bool isToExit;
    //購入画面遷移フラグ
    static public bool isToShopping;
    //リザルト遷移フラグ
    static public bool isToResult;

    //Scene preScene, scene;

    public void Start()
    {
        //それぞれのフラグの初期化
        isToTitle = false;
        isToRule = false;
        isToSample = false;
        isToExit = false;
        isComplete = false;
        isToShopping = false;
        isToResult = false;
        isToGame = false;
        //scene = SceneManager.GetActiveScene();
        //preScene = scene;
    }

    public void Update()
    {
        //preScene  
        //isToTitleがtrueの時
        if (isToTitle)
        {
            //ボタンを押した処理を一回だけにしたいのでfalseにする
            isToTitle = false;
            //タイトルシーンに移動する
            SceneManager.LoadScene("Title");
        }
        //isToRuleがtrueの時
        if (isToRule)
        {
            //ボタンを押した処理を一回だけにしたいのでfalseにする
            isToRule = false;
            //ルールシーンに移動する
            SceneManager.LoadScene("Rule");
            //scene = SceneManager.GetActiveScene();
        }
        //isToSampleがtrueの時
        else if (isToSample)
        {
            //処理を一回だけにしたいのでfalseにする
            isToSample = false;
            //見本シーンに移動する
            SceneManager.LoadScene("Sample");
            //scene = SceneManager.GetActiveScene();
        }
        //isToGameがtrueの時
        else if(isToGame)
        {
            //ボタンを押した処理を一回だけにしたいのでfalseにする
            isToGame = false;
            //ゲームシーンに移動する
            SceneManager.LoadScene("Game");
            //scene = SceneManager.GetActiveScene();
        }
        //isToExitがtrueの時
        else if(isToExit)
        {
            //ボタンを押した処理を一回だけにしたいのでfalseにする
            isToExit = false;
            //ゲームを終了する
            Quit();
        }
        //isCompleteがtrueの時
        else if(isComplete)
        {
            //ボタンを押した処理を一回だけにしたいのでfalseにする
            isComplete = false;
            //リザルトシーンに移動する
            SceneManager.LoadScene("Result");
            //scene = SceneManager.GetActiveScene();
        }
        //isToShoppingがtrueの時
        else if(isToShopping)
        {
            //ボタンを押した処理を一回だけにしたいのでfalseにする
            isToShopping = false;
            //指定したURLを開く
            Application.OpenURL("http://www.saemon.jp/shopping/detail_a02.html");
        }

        //if (preScene.name != scene.name)
        //{
        //    bgm_Manager.OnActiveSceneChanged(preScene, scene);
        //    scene = preScene;
        //}

        //preScene = scene;
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
