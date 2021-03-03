using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// シーンをまたいでもオブジェクトを消さないようにする処理
// ※ゲームを2周目以降回したときにオブジェクトが増えないようにしてあります。
public class DontDestroySingleObject : MonoBehaviour
{
    public static DontDestroySingleObject Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
