using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    BackgroundController backgroundController;
    [SerializeField]
    BackgroundController backgroundControllerMirror;
    [SerializeField]
    BGM_Manager bgmManager;

    void Start()
    {
        backgroundController.Init();
        backgroundControllerMirror.Init();
        bgmManager.Init();
    }

    void Update()
    {
        backgroundController.Run();
        backgroundControllerMirror.Run();
        //bgmManager.Run();
    }
}
