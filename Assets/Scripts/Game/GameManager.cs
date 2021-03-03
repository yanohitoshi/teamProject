using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameUIManager gameUIManager;

    [SerializeField]
    private GameObjectManager gameObjectManager;
    [SerializeField]
    private SetActiveManager setActiveManager;


    //アップデート可能かどうか
    private bool updateFlag;

    private bool completeFlag;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        completeFlag = false;
        //UI
        updateFlag = false;
        yield return SceneManager.LoadSceneAsync("GameUI", LoadSceneMode.Additive);
        var UIManager = SceneManager.GetSceneByName("GameUI").GetRootGameObjects()[0];
        if (UIManager.TryGetComponent<GameUIManager>( out var uiManager ))
        {
            gameUIManager = uiManager;
            gameUIManager.OnCompleteEvent += OnCompleteReceiver;
        }

        // UIの初期化
        gameUIManager.Init();
        // objectの初期化
        gameObjectManager.Init();
        //パーツフレームと見本画像初期化
        setActiveManager.Init();
        updateFlag = true;
    }

    private void OnDestroy()
    {
        gameUIManager.OnCompleteEvent -= OnCompleteReceiver;
    }

    // Update is called once per frame
    void Update()
    {
        if(!updateFlag)
        {
            return;
        }
        // UIの更新等
        gameUIManager.Run();
        //objectの更新処理
        gameObjectManager.Run(completeFlag);
        //パーツフレームと見本画像更新
        setActiveManager.Run(completeFlag);
    }

    private void OnCompleteReceiver()
    {
        completeFlag = true;
    }
}
