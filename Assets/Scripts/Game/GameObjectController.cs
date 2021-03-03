using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    // パーツリスト
    [SerializeField]
    private List<GameObject> Parts;
 
    // クリックしたオブジェクト
    private GameObject clickedGameObject;

    void Awake()
    {
        // パーツがなければ
        if(Parts == null || Parts.Count <= 0)
        {
            Debug.LogWarning("[GameCountroller] パーツが設定されていません");
            return;
        }
    }

    private void Start()
    {
        // パーツをリストに格納
        var partsList = new List<GameObject>(Parts);
    }

    void Update()
    {
        if (clickedGameObject != null)
        {
            clickedGameObject = null;
        }

        // 左クリックを離したら
        if (Input.GetMouseButtonUp(0))
        {
            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hit2d = Physics2D.RaycastAll((Vector2)ray.origin, (Vector2)ray.direction);
            int index = hit2d.Length;
            for (int i = 0; i < index; i++)
            {
                if (hit2d[i].transform.gameObject.tag == "parts")
                {
                    clickedGameObject = hit2d[i].transform.gameObject;

                    if (clickedGameObject != null)
                    {
                        Parts parts = clickedGameObject.GetComponent<Parts>();

                        if (parts.GetIsRangeFlag() == true)
                        {
                            parts.SetIsfadeOutFlag(true);

                            // パーツ選択アニメーション再生
                            clickedGameObject.GetComponent<Animator>().SetBool("Select", false);
                        }
                    }

                }

            }
        }
    }
}
