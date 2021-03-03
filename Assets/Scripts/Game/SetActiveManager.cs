using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveManager : MonoBehaviour
{
    [SerializeField]
    private GameObject sampleImg;
    [SerializeField]
    private GameObject frameL;
    [SerializeField]
    private GameObject frameR;
    public void Init()
    {
        sampleImg.SetActive(false);
        frameL.SetActive(true);
        frameR.SetActive(true);
    }

    public void Run(bool _complete)
    {
        if (_complete)
        {
            sampleImg.SetActive(true);
            frameL.SetActive(false);
            frameR.SetActive(false);
        }
    }
}
