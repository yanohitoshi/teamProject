using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToShoppingButton : MonoBehaviour
{
    private Animator shopButtonAnim;

    public void Init()
    {
        shopButtonAnim = GetComponent<Animator>();
        shopButtonAnim.SetBool("Move_Rota", true);
    }

    public void Run()
    {
        
    }
}
