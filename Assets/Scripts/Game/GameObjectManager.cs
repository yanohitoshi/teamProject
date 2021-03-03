using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField]
    private Parts cheek_L;
    [SerializeField]
    private Parts cheek_R;
    [SerializeField]
    private Parts eye_L;
    [SerializeField]
    private Parts eye_R;
    [SerializeField]
    private Parts eyeBrow_L;
    [SerializeField]
    private Parts eyeBrow_R;
    [SerializeField]
    private Parts nose;

    [SerializeField]
    private Score_Calculation score_Calculation;

    [SerializeField]
    private List<MoveFlower> moveflowers; 

    // 初期化
    public void Init()
    {
        // 各パーツの初期化
        cheek_L.Init();
        cheek_R.Init();
        eye_L.Init();
        eye_R.Init();
        eyeBrow_L.Init();
        eyeBrow_R.Init();
        nose.Init();
        score_Calculation.Init();

        foreach (var obj in moveflowers)
        {
            obj.Init();
        }

    }

    // 更新
    public void Run(bool _complete)
    {
        // 各パーツの更新
        cheek_L.Run(_complete);
        cheek_R.Run(_complete);
        eye_L.Run(_complete);
        eye_R.Run(_complete);
        eyeBrow_L.Run(_complete);
        eyeBrow_R.Run(_complete);
        nose.Run(_complete);
        score_Calculation.Run(_complete);

        foreach (var obj in moveflowers)
        {
            obj.Run();
        }
        
    }
}
