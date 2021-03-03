using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetsMoveController : MonoBehaviour
{
    //落下速度
    [SerializeField]
    float fallSpeed;
    //回転スピード
    [SerializeField]
    float rotateSpeed;
    //オブジェクトのtransformの変数
    [SerializeField]
    private Transform transform;
    //方向ベクトル
    Vector3 direction;
    //生成位置
    Vector3 spawnPos;
    
    //スクリプトのアタッチの時に自動で変数に代入する
    private void Reset()
    {
        if (transform == null)
        {
            transform = gameObject.GetComponent<Transform>();
        }
    }
    private void Start()
    {
        spawnPos = transform.position;
        //正規化
        direction = Vector3.Normalize((new Vector3(spawnPos.x, -spawnPos.y, spawnPos.z) - spawnPos));
        
    
    }

    public void Run()
    {
        if (transform == null)
        {
            return;
        }

        //回転処理
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);

        //移動処理
        if (spawnPos.y > 0)
        {
            transform.Translate(direction * fallSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(-direction * fallSpeed * Time.deltaTime, Space.World);
        }

        //破壊処理
        if (transform.position.y < - spawnPos.y + 20)
        {
            Destroy(gameObject);
        }
    }
}
