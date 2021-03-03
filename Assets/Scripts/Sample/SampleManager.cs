using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleManager : MonoBehaviour
{
    // カウントダウン
    [SerializeField]
    private Countdown countdown;

    void Start()
    {
        countdown.Init();
    }

    void Update()
    {
        countdown.Run();
    }
}
