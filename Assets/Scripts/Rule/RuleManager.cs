using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RuleManager : MonoBehaviour
{
    // チュートリアルキャラクター
    [SerializeField]
    private Character_tuto character_tuto;

    //// ボタン
    //[SerializeField]
    //private ToSampleButton toSampleButton;

    void Start()
    {
        character_tuto.Init();
        //toSampleButton.Init();
    }

    void Update()
    {
        character_tuto.Run();
    }

}
