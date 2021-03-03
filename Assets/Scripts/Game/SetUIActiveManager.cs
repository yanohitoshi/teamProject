using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUIActiveManager : MonoBehaviour
{

    [SerializeField]
    private GameObject completeButton;

    public void Init()
    {
        completeButton.SetActive(false);

    }

    public void Run()
    {
        if (CompleteButton.GetAllFeadOutFlag())
        {
            completeButton.SetActive(true);
        }
    }
}
