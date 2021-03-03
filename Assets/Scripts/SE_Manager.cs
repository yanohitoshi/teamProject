using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SE_Manager : MonoBehaviour
{
    // AudioSource
    public AudioSource audioSource;

    // AudioClip（効果音のリスト）
    public AudioClip[] audios;

    public void Init()
    {
        // 使用するオーディオソースの取得
        audioSource = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }

    // 太鼓の効果音を再生
    public void PlayDrumSound()
    {
        audioSource.PlayOneShot(audios[0]);
    }
}
