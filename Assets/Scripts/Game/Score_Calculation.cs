using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Calculation : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> parts;
    [SerializeField]
    private List<GameObject> calculationParts;

    private float total;
    private bool calculation;
    public static float score;

    // Start is called before the first frame update
    void Awake()
    {
        // パーツがなければ
        if (parts == null || parts.Count <= 0)
        {
            Debug.LogWarning("[parts] パーツが設定されていません");
            return;
        }
        // パーツがなければ
        if (calculationParts == null || calculationParts.Count <= 0)
        {
            Debug.LogWarning("[calculationParts] パーツが設定されていません");
            return;
        }

    }

    public void Init()
    {
        var partsList = new List<GameObject>(parts);
        var calculationPartsList = new List<GameObject>(calculationParts);
        score = 0.0f;
        calculation = false;
    }

    public void Run(bool _complete)
    {
        if (_complete)
        {
            calculation = true;
        }

        if (calculation)
        {
            total = Calculation();
            score = total;
        }

        //Debug.Log(total);
    }

    private float Calculation()
    {
        float total = 0.0f;
        for (int i = 0; i < 7; i++)
        {
            GameObject partObjects = parts[i];
            GameObject calculationPartsObjects = calculationParts[i];
            float resultX;
            float resultY;
            resultX = partObjects.transform.position.x - calculationPartsObjects.transform.position.x;
            resultX = Mathf.Abs(resultX);
            resultY = partObjects.transform.position.y - calculationPartsObjects.transform.position.y;
            resultY = Mathf.Abs(resultY);
            total += resultX + resultY;
        }

        return total * 100.0f;

        //ランク付け
        //100以下でSランク
        //500以下でAランク
        //1000以下でBランク
    }
}
