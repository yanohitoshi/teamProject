using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    [SerializeField]
    SE_Manager seManager;

    public void OnClickGameButton()
    {
        seManager.Init();
        seManager.PlayDrumSound();
        SceneTransitionManager.isToRule = true;       // ボタンを押したらルールシーンに遷移
    }
}
