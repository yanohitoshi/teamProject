using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGameSceneButton : MonoBehaviour
{
    //private Animator buttonAnim;
    //public void Init()
    //{
    //    buttonAnim = GetComponent<Animator>();
    //    buttonAnim.SetBool("Move_Scale", true);
    //}

    public void OnClickToGameSceneButton()
    {
        SceneTransitionManager.isToGame = true;       // ボタンを押したら見本シーンに遷移
    }
}
