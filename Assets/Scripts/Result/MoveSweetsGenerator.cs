using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSweetsGenerator : MonoBehaviour
{ 
    //動くお菓子プレハブ
    [SerializeField]
    private GameObject moveSweetsPrefab;
    //お菓子を生成するエリア
    [SerializeField]
    private BoxCollider2D sweetsArea;
    //固定のお菓子を生成するジェネラーター
    [SerializeField]
    private FixedSweetsGenerator fixedSweetsGenerator;
    //キャラクターのマネージャー
    [SerializeField]
    private RankCharacterManager rankCharacterManager;
    //Sランクのお菓子の個数
    [SerializeField]
    private int sRankSweetsIndex;
    //Aランクのお菓子の個数
    [SerializeField]
    private int aRankSweetsIndex;
    //Bランクのお菓子の個数
    [SerializeField]
    private int bRankSweetsIndex;
    [SerializeField]
    private float sRankCreateSpan;
    [SerializeField]
    private float aRankCreateSpan;
    [SerializeField]
    private float bRankCreateSpan;
    private float actualCreateSpan;
    [SerializeField]
    private float createFixedSweetsTime;
    //動くお菓子を作るジェネラーターの変数
    private MoveSweetsGenerator moveSweetsGenerator;
    //デルタタイム
    private float deltaTime;
    //実際に動くお菓子を生成する個数
    private int actualSweetsIndex;
    //生成開始フラグ
    private bool createSweetsFlag;
    //アクティブフラグ
    static public bool activeFlag;
    //お菓子のリスト
    public List<SweetsMoveController> moveSweetsList;

    public void Init()
    {
        //お菓子を生成するフラグの初期化
        createSweetsFlag = true;
        //アクティブフラグ初期化
        activeFlag = false;
        moveSweetsGenerator = GetComponent<MoveSweetsGenerator>();
        //お菓子のリストを作成
        moveSweetsList = new List<SweetsMoveController>();
        //ランダム生成の種の変更
        Random.InitState(System.DateTime.Now.Millisecond);
        //デルタタイム初期化
        deltaTime = 0;
        //お菓子の個数をセットする
        SetSweetIndexFromRank();
        //生成スパンをセットする
        SetCreateSpan();
        //コンポーネントの有効化
        moveSweetsGenerator.enabled = moveSweetsGenerator.enabled;
    }

    public void Run()
    {
        if (createSweetsFlag && moveSweetsList.Count < actualSweetsIndex)
        {
            deltaTime += Time.deltaTime;
            if (deltaTime >= actualCreateSpan)
            {
                deltaTime = 0;
                var newSweets = Instantiate(moveSweetsPrefab);
                var sprite = newSweets.GetComponent<SpriteRenderer>();
                var halfSize = Mathf.Max(sprite.size.x, sprite.size.y) / 2;
                newSweets.transform.SetParent(sweetsArea.transform);
                var min = sweetsArea.bounds.min;
                var max = sweetsArea.bounds.max;
                var x = Random.Range(min.x + halfSize, max.x - halfSize);
                var y = Random.Range(min.y + halfSize, max.y - halfSize);
                newSweets.transform.position = new Vector3(x, y, 0);

                moveSweetsList.Add(newSweets.GetComponent<SweetsMoveController>());
            }

        }

       
    }

    private void SetSweetIndexFromRank()
    {
        if (SendRankState.isRankA)
        {
            actualSweetsIndex = aRankSweetsIndex;
        }
        else if (SendRankState.isRankS)
        {
            actualSweetsIndex = sRankSweetsIndex;
        }
        else
        {
            actualSweetsIndex = bRankSweetsIndex;
        }
    }

    private void SetCreateSpan()
    {

        if (SendRankState.isRankA)
        {
            actualCreateSpan = aRankCreateSpan;
        }
        else if (SendRankState.isRankS)
        {
            actualCreateSpan = sRankCreateSpan;
        }
        else
        {
            actualCreateSpan = bRankCreateSpan;
        }
    }
    

}
