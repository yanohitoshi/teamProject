using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    static public bool isShow;

    public void Init()
    {
        isShow = false;
    }

    // Update is called once per frame
    public void Run()
    {
        if (isShow)
        {
            gameObject.SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
