﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishButton : MonoBehaviour
{
    public void OnClickFinishButton()
    {
        SceneTransitionManager.isToExit = true;       // ボタンを押したらゲーム終了
    }
}
