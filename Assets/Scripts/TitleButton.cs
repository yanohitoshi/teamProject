using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void OnClickTitleButton()
    {
        SceneTransitionManager.isToTitle = true;       // ボタンを押したらタイトルシーンに遷移
    }
}
