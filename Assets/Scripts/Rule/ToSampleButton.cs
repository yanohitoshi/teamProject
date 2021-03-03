using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSampleButton : MonoBehaviour
{
    //private Animator buttonAnim;
    //public void Init()
    //{
    //    buttonAnim = GetComponent<Animator>();
    //    buttonAnim.SetBool("Move_Scale", true);
    //}

    public void OnClickToSampleButton()
    {
        SceneTransitionManager.isToSample = true;       // ボタンを押したら見本シーンに遷移
    }
}
