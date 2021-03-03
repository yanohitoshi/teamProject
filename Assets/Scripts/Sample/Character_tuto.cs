using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_tuto : MonoBehaviour
{
    private Animator charaAnim;

    public void Init()
    {
        // アニメーション
        charaAnim = GetComponent<Animator>();
        charaAnim.SetBool("Move", true);
    }

    public void Run()
    {

    }
}
