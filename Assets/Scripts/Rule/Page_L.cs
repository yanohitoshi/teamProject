using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_L : MonoBehaviour
{
    // ルールテキスト
    [SerializeField]
    private GameObject ruleTextImg;
    [SerializeField]
    private GameObject ruleTextImg2;

    // ページ表示
    [SerializeField]
    private GameObject pageNum1;
    [SerializeField]
    private GameObject pageNum2;

    public void OnClickPageLeftButton()
    {
        if (ruleTextImg.activeSelf)
        {
            ruleTextImg.SetActive(false);
            ruleTextImg2.SetActive(true);

            pageNum1.SetActive(false);
            pageNum2.SetActive(true);
        }
        else
        {
            ruleTextImg.SetActive(true);
            ruleTextImg2.SetActive(false);

            pageNum1.SetActive(true);
            pageNum2.SetActive(false);
        }
    }
}
