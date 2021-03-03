using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class FixedSweetsGenerator : MonoBehaviour
{
    //固定のお菓子プレハブ
    [SerializeField]
    private GameObject fixedSweetsPrefab;
    //お菓子を生成する始点(Sランク)
    [SerializeField]
    private GameObject sweetsStartPointS;
    //お菓子を生成する始点(Aランク)
    [SerializeField]
    private GameObject sweetsStartPointA;
    //お菓子を生成する始点(Bランク)
    [SerializeField]
    private GameObject sweetsStartPointB;
    //固定のお菓子のスプライト
    private SpriteRenderer sweetsSprite;
    //位置
    Vector2 pos;
    //位置修正
    [SerializeField]
    private Vector2 bias;
    //お菓子のピラミッドの段数
    private int sweetsPyramidStagesIndex;
    //生成開始フラグ
    private bool createSweetsFlag;
    //デルタタイム
    private float deltaTime;
    //実際の一段を作るスパン
    private float actualCreateOneStepTime;
    //Sランクの時の一段を作るスパン
    [SerializeField]
    private float sRankCreateOneStepTime;
    //Aランクの時の一段を作るスパン
    [SerializeField]
    private float aRankCreateOneStepTime;
    //Bランクの時の一段を作るスパン
    [SerializeField]
    private float bRankCreateOneStepTime;
    //お菓子のリスト
    public List<SweetsFixedController> fixedSweetsList;

    public void Init()
    {
        //お菓子のスプライトの取得
        sweetsSprite = fixedSweetsPrefab.GetComponent<SpriteRenderer>();
        //お菓子を生成するフラグの初期化
        createSweetsFlag = true;
        //デルタタイム
        deltaTime = 0;
        //お菓子のリストを作成
        fixedSweetsList = new List<SweetsFixedController>();
    }

    public void Run()
    {
        if (createSweetsFlag)
        {
            //お菓子を並べるときの高さのセット
            SetSweetsPyramidStagesIndex();
            //ピラミッドの一段を作る時間のセット
            SetCreateOneStepTime();

            if (SendRankState.isRankA)
            {
                StartCoroutine(CreateSweets(sweetsStartPointA));
            }
            else if (SendRankState.isRankS)
            {
                StartCoroutine(CreateSweets(sweetsStartPointS));
            }
            else
            {
                StartCoroutine(CreateSweets(sweetsStartPointB));
            }

            createSweetsFlag = false;

        }

    
    }

    private void SetSweetsPyramidStagesIndex()
    {
        //if(SendRankState.isRankB)
        //{
        //    Debug.Log("B");
        //}
        if(SendRankState.isRankA)
        {
            sweetsPyramidStagesIndex = 5;
            Debug.Log("A");
        }
        else if(SendRankState.isRankS)
        {
            sweetsPyramidStagesIndex = 7;
            Debug.Log("S");
        }
        else
        {
            sweetsPyramidStagesIndex = 3;
        }
    }

    private void SetCreateOneStepTime()
    {
        //if (SendRankState.isRankB)
        //{
        //    actualCreateOneStepTime = bRankCreateOneStepTime;
        //}
        if (SendRankState.isRankA)
        {
            actualCreateOneStepTime = aRankCreateOneStepTime;
        }
        else if (SendRankState.isRankS)
        {
            actualCreateOneStepTime = sRankCreateOneStepTime;
        }
        else
        {
            actualCreateOneStepTime = bRankCreateOneStepTime;
        }
    }

    private IEnumerator CreateSweets(GameObject startPoint)
    {
        //前の位置
        var prePos = new Vector2(0, 0);
        //レイヤーのオーダー
        var layerOrder = 3;
        //for (int i = 0; i < sweetsIndex; i++)
        //{

        //    if (fixedSweetsList.Count % 7 == 0 && fixedSweetsList.Count != 0)
        //    {
        //        pos = prePos;
        //        pos.y += sweetsSprite.bounds.size.y - bias.y;
        //        prePos = pos;
        //    }

        //    if (i == 0)
        //    {
        //        pos = new Vector2(startPoint.transform.localPosition.x, startPoint.transform.localPosition.y);
        //        prePos = pos;
        //    }
        //    else if (fixedSweetsList.Count % 7 != 0)
        //    {
        //        pos.x += sweetsSprite.bounds.size.x + bias.x;
        //    }
            
            

        //    GameObject newSweets = Instantiate(fixedSweetsPrefab);
        //    newSweets.transform.SetParent(startPoint.transform);
        //    newSweets.transform.position = pos;

        //    fixedSweetsList.Add(newSweets.GetComponent<SweetsFixedController>());

        //}
        //ピラミッドのようにお菓子を積み上げる処理
        for (int i = 0; i < sweetsPyramidStagesIndex; i++)
        {
            yield return new WaitForSeconds(actualCreateOneStepTime);

            if (i == 0)
            {
                pos = new Vector2(startPoint.transform.localPosition.x, startPoint.transform.localPosition.y);
                prePos = pos;
            }
            else
            {
                pos = prePos;
                pos.x += (sweetsSprite.bounds.size.x + bias.x) / 2.0f;
                pos.y += sweetsSprite.bounds.size.y - bias.y;
                prePos = pos;
            }

            

            for (int j = 0; j < sweetsPyramidStagesIndex - i; j++)
            {
                deltaTime++;

                pos.x += sweetsSprite.bounds.size.x + bias.x;

                GameObject newSweets = Instantiate(fixedSweetsPrefab);
                newSweets.transform.SetParent(startPoint.transform);
                newSweets.transform.position = pos;
                newSweets.GetComponent<SortingGroup>().sortingOrder = layerOrder;

                layerOrder++;

                fixedSweetsList.Add(newSweets.GetComponent<SweetsFixedController>());

            }

        }

    }

}
