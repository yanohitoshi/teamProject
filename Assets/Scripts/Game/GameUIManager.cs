using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    public CompleteButton completeButton;
    [SerializeField]
    public SetUIActiveManager setUIActiveManager;

    public System.Action OnCompleteEvent;

    // Start is called before the first frame update
    public void Init()
    {
        setUIActiveManager.Init();
        completeButton.Init(OnCompleteEvent);
    }

    // Update is called once per frame
    public void Run()
    {
        setUIActiveManager.Run();
        completeButton.Run();
    }
}
