using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_Manager : MonoBehaviour
{
    // AudioSource
    public AudioSource audioSource;

    // AudioClip（曲のリスト）
    public AudioClip[] audios;

    // ひとつ前のシーン
    private string beforeScene;

    public void Init()
    {
        beforeScene = "Title";
        
        // 使用するオーディオソースの取得
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audios[0];
        audioSource.Play();

        DontDestroyOnLoad(gameObject);

        //シーンが切り替わったときに呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    // シーンが切り替わったときに呼ばれるメソッド
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        // タイトルからルール
        if (beforeScene == "Title" && nextScene.name == "Rule")
        {
            // 曲の停止
            audioSource.Stop();
            // 流す曲の切り替え
            audioSource.clip = audios[1];
            // 曲の再生
            audioSource.Play();
        }
        // ルールからゲーム
        else if(beforeScene == "Game" && nextScene.name == "Result")
        {
            // 曲の停止
            audioSource.Stop();
            // 流す曲の切り替え
            audioSource.clip = audios[2];
            // 曲の再生
            audioSource.Play();

        }
        // リザルトからタイトル
        else if (beforeScene == "Result" && nextScene.name == "Title")
        {
            // 曲の停止
            audioSource.Stop();
            // 流す曲の切り替え
            audioSource.clip = audios[0];
            // 曲の再生
            audioSource.Play();

        }


        // 遷移後のシーン名を「１つ前のシーン名」として保持
        beforeScene = nextScene.name;
    }
}
